Shader "Custom/SpencillClear"
{
	SubShader
	{
		Tags { "RenderType" = "Opaque" "Queue" = "Geometry+1" "ForceNoShadowCasting" = "True"}

		CGINCLUDE
		struct appdata
		{
			float4 vertex : POSITION;
		};

		struct v2f
		{
			float4 pos : SV_POSITION;
		};

		ENDCG

		Pass
		{
			ColorMask 0
			ZWrite off

			Stencil
			{
				Comp always
				Pass IncrSat
			}

			Cull Front //Remove Front
			Ztest Greater //and keep pixels from the back that are in front of everything else (e.x sides of cube in front of plane)

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			
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
		}

		Pass
		{
			ColorMask 0
			ZWrite off

			Stencil
			{
				Comp always
				Pass IncrSat
			}

			Cull Back //Remove back
			ZTest Less //and keep pixels from the front that are behind something else ()

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			
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
		}
	}
}