// #line 5 "..\Gr\Dg\shader\Common.h.hlsl"
#ifndef COMMON_H_
#define COMMON_H_

// J - Shader stages
#if defined(SHADER_STAGE_VERTEX)
REGISTERMAP(VSScene, g_vsScene, VS_REGISTER(SCENE));
REGISTERMAP(VSObject, g_vsObject, VS_REGISTER(OBJECT));
REGISTERMAP(VSLight, g_vsLight, VS_REGISTER(LIGHT));
REGISTERMAP(VSMaterial, g_vsMaterial, VS_REGISTER(MATERIAL));
# ifndef DISABLE_BONE_REGISTERS
#  ifdef USE_CONSTANTBUFFER
cbuffer VSBones : VS_REGISTER(BONES)
{
	static VSBone g_vsBone;
	static VSBone g_vsPrevBone;
}
#  else
REGISTERMAP(VSBone, g_vsBone, VS_REGISTER(BONES));

// #line 28 "..\Gr\Dg\shader\Common.h.hlsl"
#  endif
# endif 
REGISTERMAP(VSWork, g_vsWork, VS_REGISTER(WORK));

REGISTERMAP(VSSystem, g_vsSystem, VS_REGISTER(SYSTEM));


// J - Shader stages
#elif defined(SHADER_STAGE_FRAGMENT)


REGISTERMAP(PSScene, g_psScene, PS_REGISTER(SCENE));
REGISTERMAP(PSObject, g_psObject, PS_REGISTER(OBJECT));
REGISTERMAP(PSLight, g_psLight, PS_REGISTER(LIGHT));
REGISTERMAP(PSMaterial, g_psMaterial, PS_REGISTER(MATERIAL));
REGISTERMAP(PSWork, g_psWork, PS_REGISTER(WORK));
REGISTERMAP(PSSystem, g_psSystem, PS_REGISTER(SYSTEM));

#	ifndef USE_CONSTANTBUFFER
REGISTERMAP(PSTiling, g_psTiling, PS_REGISTER(TILING));
#	endif

// J - Shader stages
#endif // ifdef SHADER_STAGE_VERTEX

// J - include
#include "shadowDefine.h.hlsl"



// #line 55 "..\Gr\Dg\shader\Common.h.hlsl"



// #line 68 "..\Gr\Dg\shader\Common.h.hlsl"



// #line 71 "..\Gr\Dg\shader\Common.h.hlsl"


// J - Aliases
#ifdef SHADER_STAGE_VERTEX
#define g_psScene g_vsScene
#endif


// #line 76 "..\Gr\Dg\shader\Common.h.hlsl"

float3 GetEyePosition() {
	return g_psScene.m_eyepos.xyz;
}

// #line 81 "..\Gr\Dg\shader\Common.h.hlsl"



// #line 3 "..\Gr\Dg\shader\Common.shdr.hlsl"



#endif	// ifndef COMMON_H_