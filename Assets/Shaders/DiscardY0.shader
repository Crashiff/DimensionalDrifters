Shader "Custom/SphereCircle"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_CircleCenter("Circle Center", Vector) = (0, 0, 0, 0)
		_CircleRadius("Circle Radius", Range(0, 1)) = 0.5
	}

		SubShader
		{
			Tags { "RenderType" = "Opaque" }

			CGPROGRAM
			#pragma surface surf Lambert vertex:vert

			sampler2D _MainTex;
			float4 _CircleCenter;
			float _CircleRadius;

			struct Input
			{
				float2 uv_MainTex;
				float3 worldPos;
			};

			void vert(inout appdata_full v, out Input o)
			{
				v.vertex = UnityObjectToClipPos(v.vertex);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				o.uv_MainTex = v.texcoord.xy;
			}

			void surf(Input IN, inout SurfaceOutput o)
			{
				// Sample the main texture
				fixed4 c = tex2D(_MainTex, IN.uv_MainTex);

				// Calculate the distance from the fragment to the circle center
				float3 dist = IN.worldPos - _CircleCenter.xyz;
				float distanceToCenter = length(dist);

				// Discard the fragments inside the circle radius
				if (distanceToCenter < _CircleRadius)
					discard;

				// Output the final color
				o.Albedo = c.rgb;
				o.Alpha = c.a;
			}

			ENDCG
		}
}