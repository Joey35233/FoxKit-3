#	define REGISTERMAP(_type, _name, _register) cbuffer c##_type : _register { _type _name; }

void ps_main(

	in	float4	inVPos	: VPOS,
	in	float4	inColor : COLOR0,
	in	float2	inBaseUV : TEXCOORD0,
	in	float2	inSubUV : TEXCOORD1,
	in	float3	inViewDir : TEXCOORD4,
	in	HTANGENT2VIEW	inTangentToView : TEXCOORD5,
	out	half4	outColor0 : OUT_COLOR0,
	out	half4	outColor1 : OUT_COLOR1,
	out	half4	outColor2 : OUT_COLOR2
)
{
}