Shader "Custom/TronGeometryShader"
 {
     Properties
     {
         _Color("Color", Color) = (1,1,1,1)
         _Size("Size", float) = 0.5
     }
     SubShader
     {    
         Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
 
         LOD 100
         Blend SrcAlpha OneMinusSrcAlpha
         ZWrite Off
         Cull Off
 
         Pass
         {
             CGPROGRAM
             #pragma target 5.0
             #pragma vertex vert
             #pragma geometry geom
             #pragma fragment frag
             #include "UnityCG.cginc"
 
             // Vars
             float4 _Color;
             float _Size;
             float3 _worldPos;
 
             struct data
             {
                 float4 pos0;
             };
     
             StructuredBuffer<data> buf_Points;
 
             struct input
             {
                 float4 pos : SV_POSITION;
                 float4 color: COLOR;
             };
 
             input vert(uint id : SV_VertexID)
             {
                 input o;
             
                 o.pos = float4(buf_Points[id].pos0 + _worldPos, 1.0f);
 
                 return o;
             }
             
             [maxvertexcount(8)]
             void geom(line input p[2], inout TriangleStream<input> triStream)
             {
                 float4 s[2];
 
                 s[0] = mul(UNITY_MATRIX_VP, p[0].pos);
                 s[1] = mul(UNITY_MATRIX_VP, p[1].pos);
             
                 s[0].x /= s[0].w;
                 s[0].y /= s[0].w;
                 s[1].x /= s[1].w;
                 s[1].y /= s[1].w;
 
                 s[0].z = s[1].z = 0.1;
                 s[0].w = s[1].w = 1;
 
 
                 float4 ab = s[1] - s[0];
                 float4 normal = float4(-ab.y, ab.x, 0, 0);
                 normal = normalize(normal);
 
                 normal.x /= (_ScreenParams.x / _ScreenParams.y);
         
                 input pIn;
                 pIn.pos = s[0] - normal * _Size;
                 pIn.color = float4(1.0, 0.0, 0.0, 1.0);
                 triStream.Append(pIn);
 
                 pIn.pos = s[0] + normal * _Size;
                 pIn.color = float4(1.0, 0.0, 0.0, 1.0);
                 triStream.Append(pIn);
 
                 pIn.pos = s[1] - normal * _Size;
                 pIn.color = float4(0.0, 1.0, 0.0, 1.0);
                 triStream.Append(pIn);
 
                 pIn.pos = s[1] + normal * _Size;
                 pIn.color = float4(0.0, 1.0, 0.0, 1.0);
                 triStream.Append(pIn);                        
             }
             
             float4 frag(input i) : COLOR
             {
                 return i.color;
             }
 
             ENDCG
         }
     }
 
 FallBack "Diffuse"
 }