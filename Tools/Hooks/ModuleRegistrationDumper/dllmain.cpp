#define WIN32_LEAN_AND_MEAN
#include <windows.h>

#include <cstdint>
#include <fstream>

HMODULE g_thisModule;
extern HMODULE origDll; // DInputProxy.cpp

static const uintptr_t Base_Address              = 0x140000000;
static const uintptr_t Module_AddDependencyModule_Address  = 0x140024980;
static const uintptr_t Framework_InitModules_Address = 0x14001d960;

constexpr size_t Module_AddDependencyModule_OverwrittenByteCount = 15;
constexpr size_t Module_AddDependencyModule_PatchSize = 14;

// Framework::InitModules is fully re-implemented in Hook_InitModules rather than
// trampolined back into, so only the redirect jump's byte count matters here.
constexpr size_t Framework_InitModules_PatchSize = 14;

static const uint8_t FileStream_Open_JZ_PatchInstr[6] = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };

struct KernelString
{
    union
    {
        char buf[16];
        char* ptr;
    } data;
    size_t length;
    size_t capacity;

    const char* c_str() const
    {
        return capacity > 15 ? data.ptr : data.buf;
    }
};

static void Log(std::string_view string)
{
    static std::ofstream logStream("HookLog.txt", std::ios::out | std::ios::trunc);

    if (logStream)
        logStream << string << std::endl;
}

static void LogInitOrder(std::string_view string)
{
    static std::ofstream initOrderStream("ModuleInitOrder.txt", std::ios::out | std::ios::trunc);

    if (initOrderStream)
        initOrderStream << string << std::endl;
}

using AddDependencyModuleFn = void(__fastcall*)(void* thisPtr, const char* dependencyName, bool unusedFlag);
using ModuleInitFn = void(__fastcall*)(void* modulePtr);

AddDependencyModuleFn OriginalFunction = nullptr;

void __fastcall Hook_AddDependencyModule(void* thisPtr, const char* dependencyName, bool unusedFlag)
{
    const KernelString* moduleName = reinterpret_cast<const KernelString*>(reinterpret_cast<const uint8_t*>(thisPtr) + 0x8);
    Log(std::string(moduleName->c_str()) + " -> " + dependencyName);
    OriginalFunction(thisPtr, dependencyName, unusedFlag);
}

// Re-implementation of fox::Framework::InitModules (14001d960). The original loops over a
// Module* array at [this+0x20, this+0x28) and calls each module's virtual Init (vtable slot 2,
// i.e. offset 0x10) in order. This mirrors that loop so we can log each module's name (Module::Name,
// a KernelString at Module+0x8) immediately before its Init is invoked. The per-iteration
// Tick::Get/GetAllocSize profiling calls in the original are omitted; their results aren't
// otherwise used and dropping them doesn't affect module initialization.
void __fastcall Hook_InitModules(void* thisPtr)
{
    uint8_t* framework = static_cast<uint8_t*>(thisPtr);
    int32_t* state = reinterpret_cast<int32_t*>(framework + 0x8);
    if (*state != 1)
    {
        *state = 2;
        return;
    }

    void** current = *reinterpret_cast<void***>(framework + 0x20);
    void** end = *reinterpret_cast<void***>(framework + 0x28);
    if (current == end)
    {
        *state = 2;
        return;
    }

    do
    {
        void* module = *current;
        const KernelString* moduleName = reinterpret_cast<const KernelString*>(static_cast<const uint8_t*>(module) + 0x8);
        LogInitOrder(moduleName->c_str());

        void** vtable = *reinterpret_cast<void***>(module);
        reinterpret_cast<ModuleInitFn>(vtable[2])(module);

        ++current;
    } while (current != end);

    *state = 2;
}

bool InstallHook(uint8_t* target, void* detour, AddDependencyModuleFn* outOriginalFunction)
{
    uint8_t* trampoline = static_cast<uint8_t*>(VirtualAlloc(nullptr, Module_AddDependencyModule_OverwrittenByteCount + Module_AddDependencyModule_PatchSize, MEM_COMMIT | MEM_RESERVE, PAGE_EXECUTE_READWRITE));
    if (trampoline == nullptr)
        return false;

    memcpy(trampoline, target, Module_AddDependencyModule_OverwrittenByteCount);

    uint8_t* returnJump = trampoline + Module_AddDependencyModule_OverwrittenByteCount;
    uintptr_t returnAddress = reinterpret_cast<uintptr_t>(target + Module_AddDependencyModule_OverwrittenByteCount);
    returnJump[0] = 0xFF;
    returnJump[1] = 0x25;
    *reinterpret_cast<uint32_t*>(returnJump + 2) = 0;
    memcpy(returnJump + 6, &returnAddress, sizeof(returnAddress));

    DWORD oldProtect = 0;
    if (!VirtualProtect(target, Module_AddDependencyModule_OverwrittenByteCount, PAGE_EXECUTE_READWRITE, &oldProtect))
    {
        VirtualFree(trampoline, 0, MEM_RELEASE);
        return false;
    }

    uintptr_t detourAddress = reinterpret_cast<uintptr_t>(detour);
    target[0] = 0xFF;
    target[1] = 0x25;
    *reinterpret_cast<uint32_t*>(target + 2) = 0;
    memcpy(target + 6, &detourAddress, sizeof(detourAddress));

    DWORD ignored = 0;
    VirtualProtect(target, Module_AddDependencyModule_OverwrittenByteCount, oldProtect, &ignored);
    FlushInstructionCache(GetCurrentProcess(), target, Module_AddDependencyModule_OverwrittenByteCount);

    *outOriginalFunction = reinterpret_cast<AddDependencyModuleFn>(trampoline);
    return true;
}

// Simple non-trampolined redirect: overwrites the target's entry point with a jump to detour and
// never resumes into the target's original bytes. Suitable when detour fully re-implements the
// target function itself, as Hook_InitModules does.
bool InstallReplaceHook(uint8_t* target, void* detour, size_t patchSize)
{
    DWORD oldProtect = 0;
    if (!VirtualProtect(target, patchSize, PAGE_EXECUTE_READWRITE, &oldProtect))
        return false;

    uintptr_t detourAddress = reinterpret_cast<uintptr_t>(detour);
    target[0] = 0xFF;
    target[1] = 0x25;
    *reinterpret_cast<uint32_t*>(target + 2) = 0;
    memcpy(target + 6, &detourAddress, sizeof(detourAddress));

    DWORD ignored = 0;
    VirtualProtect(target, patchSize, oldProtect, &ignored);
    FlushInstructionCache(GetCurrentProcess(), target, patchSize);
    return true;
}

bool APIENTRY DllMain(HMODULE hinstDLL, DWORD fdwReason, LPVOID lpvReserved)
{
    if (fdwReason == DLL_PROCESS_ATTACH)
    {
        DisableThreadLibraryCalls(hinstDLL);
        g_thisModule = hinstDLL;

        HMODULE exeModule = GetModuleHandleW(nullptr);
        intptr_t offset = reinterpret_cast<intptr_t>(exeModule) - static_cast<intptr_t>(Base_Address);

        uint8_t* funcAddr = reinterpret_cast<uint8_t*>(Module_AddDependencyModule_Address + offset);

        InstallHook(funcAddr, reinterpret_cast<void*>(&Hook_AddDependencyModule), &OriginalFunction);

        uint8_t* initModulesAddr = reinterpret_cast<uint8_t*>(Framework_InitModules_Address + offset);

        InstallReplaceHook(initModulesAddr, reinterpret_cast<void*>(&Hook_InitModules), Framework_InitModules_PatchSize);
    }
    else if (fdwReason == DLL_PROCESS_DETACH)
    {
        FreeLibrary(origDll);
    }

    return true;
}
