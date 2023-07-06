Shader "Custom/SpencillClear"
{
	SubShader
	{
		Tags { "RenderType" = "Opaque" "Queue" = "Geometry+1" "ForceNoShadowCasting" = "True"}
		ColorMask 0
		//ZWrite off
		Stencil
		{
			Ref 1
			Comp always
			Pass replace
		}

		CGINCLUDE
		struct appdata
		{
			float4 vertex : POSITION;
		};

		struct v2f
		{
			float4 pos : SV_POSITION;
		};

		v2f vert(appdata v)
		{
			v2f o;
			o.pos = UnityObjectToClipPos(v.vertex);
			return o;
		}

		half4 frag(v2f i) : SV_TARGET
		{
			return half4(1, 1, 0, 1);
		}
			ENDCG

		Pass
		{
			Cull Front
			Ztest Less

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			ENDCG
		}

		Pass
		{
			Cull Back
			ZTest Greater

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			ENDCG
		}
	}
}