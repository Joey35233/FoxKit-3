#include "GBuffersBase.shdr.hlsl"




// #line 6 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// J - include
#include "GammaTransformation.h.hlsl"


// #line 7 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// J - include
#include "NormalBlend.h.hlsl"

// #line 8 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// J - include
#include "Common.h.hlsl"


// #line 9 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"



// #line 15 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 21 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 25 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"












// #line 53 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 125 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"







// #line 138 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 160 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"



// #line 164 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 173 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 177 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 187 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"



// #line 191 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 201 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"



// #line 205 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 214 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"



// #line 221 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 235 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"







// #line 242 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"



// #line 506 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"





Texture2D g_tex_srm			: TEXUNIT2;
Texture2D g_tex_materialmap	: TEXUNIT3;
SamplerState g_sampler_srm			: SAMPLERUNIT2 ;
SamplerState g_sampler_materialmap	: SAMPLERUNIT3 ;

Texture2D g_MaterialTexture	: TEXUNIT10 ;		
TextureCube g_ReflectionTexture : TEXUNIT11 ;		


// #line 521 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 534 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"




// #line 543 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 558 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"



// #line 562 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 579 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 582 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 591 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"



// #line 595 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 607 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 610 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 621 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"



// #line 627 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 639 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"




// #line 644 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 664 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"





// #line 677 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 737 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"




// #line 744 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"



// #line 756 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"




// #line 764 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"



// #line 786 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"




// #line 793 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 806 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"



// #line 814 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 828 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"



// #line 830 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 866 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"



// #line 868 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 880 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"





// #line 887 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 900 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"



// #line 922 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 930 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 941 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"




// #line 950 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 962 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"





// #line 972 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"



// #line 988 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"





// #line 996 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 1015 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"




// #line 1071 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"



// #line 1075 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 1085 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"




// #line 1090 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 1100 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"



// #line 1104 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"


// #line 1115 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"



// #line 1118 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"




// #line 1555 "..\Gr\Dg\shader\fox3ddf_blin.shdr.hlsl"