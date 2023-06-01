Shader "Custom/FlattenZ"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_FlattenValue("Flatten Value", Range(0, 1)) = 0.5
		_CornerIndex("Corner Index", Range(0, 7)) = 0
	}

		SubShader
		{
			Tags { "RenderType" = "Opaque" }

			CGPROGRAM
			#pragma surface surf Lambert vertex:vert

			sampler2D _MainTex;
			float _FlattenValue;
			int _CornerIndex;

			struct Input
			{
				float2 uv_MainTex;
			};

			void vert(inout appdata_full v)
			{
				if (_CornerIndex == 0) // Flatten bottom-left corner
				{
					if (v.vertex.x <= 0 && v.vertex.y <= 0 && v.vertex.z <= 0)
					{
						float3 center = float3(0, 0, 0); // Center position
						float3 corner = float3(0, 0, 0); // Corner position

						// Calculate the direction from the corner to the center
						float3 direction = normalize(center - corner);

						// Calculate the flatten position based on the direction and flatten value
						float3 flattenPos = corner + direction * _FlattenValue;

						// Update the vertex position
						v.vertex.x = flattenPos.x;
						v.vertex.y = flattenPos.y;
						v.vertex.z = flattenPos.z;
					}
				}
				// Add similar conditions for other corners

				// Apply the default flatten operation for non-corner vertices
				if (v.vertex.z < _FlattenValue)
					v.vertex.z = _FlattenValue;
			}

			void surf(Input IN, inout SurfaceOutput o)
			{
				// Sample the main texture
				fixed4 c = tex2D(_MainTex, IN.uv_MainTex);

				// Output the final color
				o.Albedo = c.rgb;
				o.Alpha = c.a;
			}

			// Optional: Add a custom tessellation function to create new faces or triangulate existing faces in the flattened corner
			// This function is responsible for generating additional vertices and triangles to create the desired surface.
			// You can implement your own tessellation logic based on your requirements.
			//void tessellate(Args...)
			//{
			//    // Tessellation logic goes here
			//}

			ENDCG
		}
}
