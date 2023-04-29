Shader "Unlit/NewUnlitShader"
{
	Properties{
		_MainTex("Texture", 2D) = "white" {}
		_SlicePosition("Slice Position", Range(0, 1)) = 0.5
		_SliceThickness("Slice Thickness", Range(0, 1)) = 0.1
	}

		SubShader{
			Tags {"Queue" = "Transparent" "RenderType" = "Transparent"}
			LOD 100

			Pass {
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"

				struct appdata {
					float4 vertex : POSITION;
					float2 uv : TEXCOORD0;
				};

				struct v2f {
					float2 uv : TEXCOORD0;
					float4 vertex : SV_POSITION;
				};

				sampler2D _MainTex;
				float _SlicePosition;
				float _SliceThickness;

				v2f vert(appdata v) {
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = v.uv;
					return o;
				}

				fixed4 frag(v2f i) : SV_Target {
					// Calculate distance from the slice position
					float dist = abs(i.vertex.y - _SlicePosition) - _SliceThickness * 0.5;

				// If inside the slice, render with the main texture
				if (dist < 0) {
					return tex2D(_MainTex, i.uv);
				}
 else {
					// Otherwise, make it transparent
					return float4(0, 0, 0, 0);
				}
			}
			ENDCG
		}
		}
}