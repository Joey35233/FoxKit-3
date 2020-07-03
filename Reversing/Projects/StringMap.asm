; Structure StringMap<int> 
; {
;    0	  uint*                   4    vfptr
;    4	  undefined4              4    unknown 		
;    8	  uint                    4    count
;    12	  uint                    4    capacity
;    16	  StringMap<int>::Cell**  4    cells	
;    20   StringMap<int>::Cell*   4    smUnknown0
;    24   StringMap<int>::Cell*   4    smUnknown1	
; }

; Structure StringMap<int>::Cell 
; {
;    0    String*                 4   key
;    4    StringMap<int>::Cell*   4   cUnknown0
;    8    StringMap<int>::Cell*   4   cUnknown1
;    12   StringMap<int>::Cell*   4   cUnknown2
;    16   int                     4   value
; }

; *************************************************************
; * fox::StringMap<int>::Insert(fox::String const&, int const&)
; *************************************************************
; void __thiscall Insert(StringMap<int> *this, String *key, int* value)
; assume LRset = 0x0
; assume TMode = 0x1

; void              <VOID>         <RETURN>
; StringMap<int>    r0:4 (auto)    this
; String *          r1:4           key
; int*              r2:4           value
; undefined4        r0:4           keyCString                              XREF[1]:     066c402e (W)   
; StringMap<int>    r0:4           local_r0_94                             XREF[1]:     066c4066 (W)   
; StringMap<int>    r0:4           local_r0_100                            XREF[1]:     066c406c (W)

push       { r4, r5, r6, r7, r8, r9, r10 , lr  } ; do stack stuff
sub        sp, #0x10                             ; more stack stuff
mov        r10 , r0                              ; copy StringMap<int>* this {r0} to r10_this
mov        r6, r1                                ; copy String* key {r1} to r6_pKey
ldr        r0, [r0,#0x8 ]                        ; load uint this->count {r0 + 0x8} to r0_count
mov        r8, r2                                ; copy int* value {r2} to r8_pValue
ldr.w      r1, [r10 ,#0xc ]                      ; load uint this->capacity {r10 + 0xc} to r1_workingCapacity
cmp        r0, r1                                ; 
bcc        LAB_066c402c                          ; if (!(r1_workingCapacity <= r0_count)) 
                                                 ;      jump to LAB_066c402c
; ELSE
lsl        r1, r0, #0x1                          ; r1_workingCapacity = r0_count << 1
cmp        r0, #0x0                              ; 
it         eq                                    ; if (r0_count == 0)
mov.eq     r1, #0x10                             ;      copy 0x10 to r1_workingCapacity
mov        r0, r10                               ; copy StringMap<int>* r10_this to r0_this
blx        ChangeHashSize                        ; ChangeHashSize(r0_this, r1_workingCapacity)
; ENDELSE

LAB_066c402c:
mov        r0, r6                                ; copy String* r6_pKey to r0_pKey
blx        CString                               ; copy char* key->CString() to r0_pKeyCString
blx        FoxStrHash                            ; copy uint64_t FoxStrHash(char* r0_pKeyCString) into r0_hash0, r1_hash1
ldrd       r2, r4, [r10 ,#0xc ]                  ; load this->capacity {r10_this + 0xc} to r2_capacity0, load Cell** this->cells {r10 + 0xc + 0x4} to r4_ppCells
mov        r3, #0x0                              ; copy 0 to r3_capacity1
blx        __aeabi_uldivmod                      ; copy __aeabi_uldivmod(r0_hash0, r1_hash0, r2_capacity0, r3_capacity1) into r0_quo0, r1_quo0 and r2_rem0, r3_rem1
ldr.w      r5,[  r4, r2, lsl #0x2 ]              ; load r4_ppCells[r2_rem0] {r4_ppCells + r2_rem0 << 2} into r5_pIndexedCell
mov        r9, r2                                ; copy r2_rem0 to r9_idx
cbz        r5, LAB_066c4062                      ; if (r5_pIndexedCell == 0)
                                                 ;      jump to LAB_066c4062
; ELSE
add        r7, sp,#0x8                           ; copy String** &key {address of r6 (sp + 0x8)} into r7
mov        r4, sp                                ; copy Cell*** &this->cells {address of r4} into r4

// Whole label: ????????????????????????????????????????????????????????????? (most parts of this are likely wrong)
LAB_066c404c:
mov        r0, r7                                ; copy r7_ppKey into r0_ppKey
mov        r1, r6                                ; copy r6_pKey into r1_pKey
blx        operator.cast.to.StringId             ; copy StringId operator.cast.to.String to address of r0 (r0 == &key, so basically: key.hash = r6.GetHash())
mov        r0, r4                                ; copy &this->cells {r4} into r0
mov        r1, r5                                ; copy Cell* r6->data {r5}
blx        operator.cast.to.StringId             ; copy StringId operator.cast.to.String to address of r0 (r0 == &this->cells, so basically: )
ldr        r5, [r5,#0xc ]                        ; 
cmp        r5, #0x0
bne        LAB_066c404c
; ENDELSE

LAB_066c4062:
mov        r0, #0x14                             ; copy 0x14 to r0_cellSize
mov        r1, #0x0                              ; copy 0x0 to r1_alignmentSize
blx        BasicMalloc                           ; copy Cell* BasicMalloc(r0_cellSize, r1_alignmentSize) to r0_pNewCell
mov        r4, r0                                ; copy r0_pNewCell to r4_pNewCell
blx        String                                ; undefined String(String * this)
mov        r1, r6                                ; copy r6_pKey to r1_pKey
blx        operator=                             ; r0_pNewCell->key operator= r1_pKey
ldr.w      r0, [r10 ,#0x10 ]                     ; load Cell** this->cells {r10_this + 0x10} into r0_ppCells
ldr.w      r0,[  r0, r9,lsl #  0x2 ]             ; load r0_ppCells[r9_idx] {r0_ppCells + r9_idx << 2} into r0_pIndexedCell
str        r0, [r4,#0xc ]                        ; store r0_pIndexedCell in r4_pNewCell->pCUnknown2 {r4_pNewCell + 0x12}
ldr.w      r0, [r8,#0x0 ]                        ; load r8_pValue {r8} into uint r0_value
str        r0, [r4,#0x10 ]                       ; store r0_value in r4_pNewCell->value {r4_pNewCell + 0x10}
ldr.w      r0, [r10 ,#0x10 ]                     ; load Cell** this->cells {r10_this + 0x10} into r0_ppCells
str.w      r4,[  r0, r9,lsl #  0x2 ]             ; load r0_ppCells[r9_idx] {r0_ppCells + r9_idx << 2} into r4_pIndexedCell
add.w      r0, r10 , #0x14                       ; copy &r10_this->smUnknown0 {r10_this + 0x14} to r0_ppSmUnknown0 @ NOTE: This "pointer retargeting" definitely suggests that it's some sort of inline struct
str        r0, [r4,#0x8 ]                        ; store r0_ppSmUnknown0 in r4_pIndexedCell->pCUnknown1 {r4_pIndexedCell + 0x8}
ldr.w      r0, [r10 ,#0x18 ]                     ; load r10_this->smUnknown1 {r10_this + 0x18} to r0_pSmUnknown1
str        r0, [r4,#0x4 ]                        ; store r0_pSmUnknown1 in r4_pIndexedCell->pCUnknown0 {r4_pIndexedCell + 0x4}
ldr.w      r0, [r10 ,#0x18 ]                     ; load r10_this->smUnknown1 {r10_this + 0x18} to r0_pSmUnknown1
str        r4, [r0,#0x8 ]                        ; store r4_pIndexedCell in r0_pSmUnknown1
ldr.w      r0, [r10 ,#0x8 ]                      ; load r10_this->count {r10_this + 0x8} to r0_count
str.w      r4, [r10 ,#0x18 ]                     ; store r4_pIndexedCell in r10_this->smUnknown1 {r10_this + 0x18}
add        r0, #0x1                              ; copy r0_count + 1 to r0_newCount
str.w      r0, [r10 ,#0x8 ]                      ; store r0_newCount in r10_this->count {r10_this + 0x8}
add        sp, #0x10                             ; stack stuff
pop.w      { r4, r5, r6, r7, r8, r9, r10 , pc }  ; more stack stuff

; *************************************************************
; * fox::String::CString() const                               
; *************************************************************
; char* __thiscall CString (String* this )
; assume LRset = 0x0
; assume TMode = 0x1

; char *            r0:4           <RETURN>
; String *          r0:4 (auto)    this

ldr        r0, [r0,#0x0 ]
ldr        r0, [r0,#0x0 ]
bx         lr

; *************************************************************
; * fox::FoxStrHash(char const*)                               
; *************************************************************
; uint64_t __stdcall FoxStrHash (char* str )
; assume LRset = 0x0
; assume TMode = 0x1

; uint64_t          r0:4,r1:4      <RETURN>
; char *            r0:4           str

push       { r4, lr }
mov        r4, r0
blx        strlen                                           ; size_t strlen(char * __s)
mov        r1, r0
mov        r0, r4
pop.w      { r4, lr }
b.w        ghidra_fox_hash                                  ; uint64_t ghidra_fox_hash(char *

; *************************************************************
; * FUNCTION                          
; *************************************************************
; undefined  __aeabi_uldivmod ()

; undefined         r0:1           <RETURN>
; undefined4        Stack[-0x8]:4  local_8                                 XREF[1]:     05e0b110 (*)   
; undefined4        Stack[-0xc]:4  local_c                                 XREF[1]:     05e0b108 (R)   
; undefined4        Stack[-0x10]:4 local_10                                XREF[1]:     05e0b100 (*)

cmp        r3, #0x0
cmpeq      r2, #0x0
bne        LAB_05e0b0fc
cmp        r1, #0x0
cmpeq      r0, #0x0
mvnne      r1, #0x0
mvnne      r0, #0x0
b          LAB_060881bc

LAB_05e0b0fc:
sub        sp, sp, #0x8
stmdb      sp!,{ sp lr }=>local_10
bl         __gnu_uldivmod_helper                            ; undefined __gnu_uldivmod_helper(
ldr        lr, [sp,#0x4 ]=>local_c
add        sp, sp, #0x8
ldmia      sp!,{ r2 r3 }=>local_8
bx         lr

; *************************************************************
; * fox::String::operator fox::StringId() const
; *************************************************************
; StringId __thiscall operator.cast.to.StringId(String *this,uint *param_1)
; assume LRset = 0x0
; assume TMode = 0x1
; 
; StringId          r0:4           <RETURN>
; String *          r0:4 (auto)    this
; uint *            r1:4           param_1

ldr        r1, [r1,#0x0 ]
ldrd       r1, r2, [r1,#0x8 ]
strd       r1, r2, [r0,#0x0 ]
bx         lr