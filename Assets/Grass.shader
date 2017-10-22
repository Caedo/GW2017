Shader "Custom/Grass" {


    Properties {
        _Texture ("Texture", 2D) = "white" {}
		_Wind("Wind", Vector) = (1, 0, 0, 0)
		_BendScale("BendScale", float) = 1
		_Frequency("Frequency", float) = 4
		_LocalStrength("Local Strength", float) = 1
		_LocalPhase("Local Phase", float) = 3
		_LocalFreq("Local Frequency", float) = 1
			_Modifier("Modifier", Range(0,1)) = 1
    }
    SubShader {
    	

        Tags {
            "Queue"="Geometry"
            "RenderType"="Opaque"
            "DisableBatching"="True"
        }
        Pass {
        	
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows

            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float4 _Wind;
            uniform float _BendScale;

            uniform float _Frequency;
            uniform float _Speed;
            uniform float _LocalStrength;
            uniform float _LocalPhase;
            uniform float _LocalFreq;

       		uniform float4x4 _Matrix;
			uniform float _Modifier;


            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;

     
            };


            VertexOutput vert (VertexInput v) {
            	float4 worldPos = mul (unity_ObjectToWorld,v.vertex);

					

				float modifier = _Modifier;


                VertexOutput o = (VertexOutput)0;
              
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;		
				
                float4 t = _Time + _TimeEditor;
                float4 vert = v.vertex;
                float flength = length(vert.xyz);
                float globalPhase = dot(worldPos, 1);
                //local bending
                float phase =  v.vertexColor.g;

                float f = v.vertex.z * _BendScale;
                f += 1;
                f *= f;
                f = f * f - f;


               	float3 offs = (sin( (t.g + phase * _LocalPhase + globalPhase) * _LocalFreq) + 1) / 2 * v.normal * v.vertex.z * _LocalStrength;
                offs.xy += sin((t.g + globalPhase) * _Frequency ) * _Wind.xy * f;
                v.vertex.xyz = normalize(vert.xyz + offs.xyz * modifier) * flength;				
               
                o.pos = UnityObjectToClipPos(v.vertex );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
 
            	float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(i.uv0, _Texture));

                return fixed4(_Texture_var.rgb, 1);
				//return i.vertexColor  * 0.5 + 0.5;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
