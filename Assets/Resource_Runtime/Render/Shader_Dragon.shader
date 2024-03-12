Shader "Unlit/Shader_Dragon"
{
    Properties
    {
    }
    SubShader
    {
        Pass
        {
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

            float4 _MainTex_ST;

            // Shader 是
            //  1. TA(Tech Artist) 技术美术
            //  2. 图程(图形程序)

            // 顶点阶段
            // 1865 次
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            // 120000 像素阶段
            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;
                // fixed4 col = tex2D(_MainTex, i.uv);
                fixed4 color = fixed4((uv.x + uv.y) /2.0, 0.0, 0.0, 1.0); // r g b a
                return color;
            }
            ENDCG
        }
    }
}
