Shader "Custom/Waves"{
	Properties{
		_Color("Color", Color) = (0, 0, 0, 1)
		_Strength("Strength", Range(0,1)) = 0.5
		_Speed("Speed", Range(-200, 200)) = 100.0
		_ZSpeed("ZSpeed", Range(-200, 200)) = 50.0
	}

	SubShader{
		Tags{
			"RenderType" = "tranparent"
		}
		Pass
		{

			Cull Off

			CGPROGRAM

			#pragma vertex vertexFunc
			#pragma fragment fragmentFunc
			float4 _Color;
			float _Strength;
			float _Speed;
			float _ZSpeed;

			struct vertexInput {
				float4 vertex : POSITION;
			};

			struct vertexOutput {
				float4 pos : SV_POSITION;
			};

			vertexOutput vertexFunc(vertexInput IN) {
				vertexOutput o;

				float4 worldPos = mul(unity_ObjectToWorld, IN.vertex);

				float4 displacement = (cos(worldPos.y) + cos(worldPos.x + (_Speed * _Time)) + cos(worldPos.z + (_ZSpeed * _Time)));
				worldPos.y = worldPos.y + (displacement * _Strength);
				o.pos = mul(UNITY_MATRIX_VP, worldPos);

				return o;
			}

			float4 fragmentFunc(vertexOutput IN) : COLOR{
				return _Color;
			}

			ENDCG
		}
	}
}

