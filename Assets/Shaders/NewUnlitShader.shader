Shader "Unlit/NewUnlitShader"
{
	Properties
	{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Color("Tint", Color) = (1, 1, 1, 1)
	}

		SubShader
		{
			LOD 100

			Pass
			{
				ZWrite On
				Cull Off // Update Cull setting to Off to render from both sides

				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"

				struct appdata
				{
					float4 vertex : POSITION;
					float2 uv : TEXCOORD0;
				};

				struct v2f
				{
					float2 uv : TEXCOORD0;
					float4 vertex : SV_POSITION;
				};

				sampler2D _MainTex;
				float4 _MainTex_ST;
				float4 _Color;

				v2f vert(appdata v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = v.uv;
					return o;
				}

				fixed4 frag(v2f i) : SV_Target
				{
					// Sample the texture from both sides of the object
					float4 col1 = tex2D(_MainTex, i.uv);
					float4 col2 = tex2D(_MainTex, 1 - i.uv);

					// Blend the colors based on face orientation
					float4 col = lerp(col1, col2, i.uv.x);

					// Apply the tint color
					col.rgb *= _Color.rgb;
					col.a *= _Color.a;

					return col;
				}
				ENDCG
			}
		}
}