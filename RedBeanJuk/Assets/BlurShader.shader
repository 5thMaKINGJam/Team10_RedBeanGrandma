Shader "Custom/GaussianBlur"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BlurRadius ("Blur Radius", Range(0.0, 10.0)) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
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
            
            sampler2D _MainTex;
            float _BlurRadius;
            float _BlurTexelSize;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            
            // Function to calculate Gaussian weight
            float Gaussian(float x, float deviation)
            {
                return exp(-(x * x) / (2 * deviation * deviation)) / (deviation * sqrt(2 * UNITY_PI));
            }

            float4 frag(v2f i) : SV_Target
            {
                // Compute the texel size for blurring
                float2 texelSize = 1.0 / _ScreenParams.xy;

                // Gaussian blur calculation
                float4 color = float4(0, 0, 0, 0);
                float totalWeight = 0.0;

                // Horizontal blur pass
                for (int x = -5; x <= 5; x++)
                {
                    float2 offset = float2(x, 0) * texelSize * _BlurRadius;
                    color += tex2D(_MainTex, i.uv + offset) * Gaussian(x, _BlurRadius);
                    totalWeight += Gaussian(x, _BlurRadius);
                }

                // Normalize color
                color /= totalWeight;

                return color;
            }
            ENDCG
        }
    }
}