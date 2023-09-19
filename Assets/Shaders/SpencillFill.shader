Shader "Custom/SpencillFill"
{
		Properties
		{
			_Color("Tint", Color) = (0, 0, 0, 1)
			_MainTex("Texture", 2D) = "white" {}
			_Smoothness("Smoothness", Range(0, 1)) = 0
			_Metallic("Metalness", Range(0, 1)) = 0
			[HDR]_Emission("Emission", color) = (0,0,0)

			[HDR]_CutoffColor("Cutoff Color", Color) = (1,0,0,0)
		}
		SubShader
		{
			Tags { "RenderType" = "Opaque" "Queue" = "Geometry+2" "ForceNoShadowCasting" = "True"}

			LOD 200
			ColorMask RGB
			Cull Front
			ZTest Always

			CGINCLUDE
			sampler2D _MainTex;
			fixed4 _Color;

			half _Smoothness;
			half _Metallic;
			half3 _Emission;

			//float4 _Plane;

			float4 _CutoffColor;

			//input struct which is automatically filled by unity
			struct Input {
				float2 uv_MainTex;
				float3 worldPos;
				float facing : VFACE;
			};

			//////


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
				Cull Off
				ZTest Always
				ZWrite Off
				Stencil
				{
					Ref 0 // Set the stencil reference value to 1
					Comp Always // Always pass the stencil test
					Pass Replace
				}
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


			Stencil
			{
				Ref 1
				Comp Less
				Pass IncrSat
			}

			// render faces regardless if they point towards the camera or away from it
			//Cull Off

			CGPROGRAM
			//the shader is a surface shader, meaning that it will be extended by unity in the background
			//to have fancy lighting and other features
			//our surface shader function is called surf and we use our custom lighting model
			//fullforwardshadows makes sure unity adds the shadow passes the shader might need
			//vertex:vert makes the shader use vert as a vertex shader function
			#pragma surface surf Standard fullforwardshadows
			#pragma target 3.0

			//the surface shader function which sets parameters the lighting function then uses
			void surf(Input i, inout SurfaceOutputStandard o) {
				o.Albedo = fixed4(1, 1, 1, 1);
				////calculate signed distance to plane
				//float distance = dot(i.worldPos, _Plane.xyz);
				//distance = distance + _Plane.w;
				////discard surface above plane
				//clip(-distance);

				float facing = i.facing * 0.5 + 0.5;

				////for regular color + color inside (back)
				fixed4 col = tex2D(_MainTex, i.uv_MainTex);
				col *= _Color;
				o.Albedo = col.rgb * facing;
				o.Metallic = _Metallic * facing;
				o.Smoothness = _Smoothness * facing;
				o.Emission = lerp(_CutoffColor, _Emission, facing);
			}
			ENDCG

						Pass
			{
				ColorMask 0
				Cull Off
				ZTest Always
				ZWrite Off
				Stencil
				{
					Ref 0 // Set the stencil reference value to 1
					Comp Always // Always pass the stencil test
					Pass Replace
				}
			}
		}
			FallBack "Diffuse" //fallback adds a shadow pass so we get shadows on other objects
}