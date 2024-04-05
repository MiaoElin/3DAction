Shader "Unlit/Shader_Sample"
{
    Properties
    {
        _Zengqiang ("ZengQ", float) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 uv : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 normal : NORMAL;
            };

            float _Zengqiang;

            // 顶点(Vertex) Shader
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = float2(1, 1) - v.uv;
                o.normal = v.normal;
                return o;
            }

            // 像素(片元fragment) Shader
            fixed4 frag (v2f i) : SV_Target
            {
                // float3 light = UNITY_LIGHT;
                float4 color = float4(i.uv.x, 0, 0, 1) * (1 + _Zengqiang);

                return color;
            }
            ENDCG
        }
    }
}
