Shader "Custom/CheckersShader"
{
    Properties
    {
        _Scale ("Pattern Size", Range(1, 10)) = 1
        _EvenColor ("Color 1", Color) = (0,0,0,1)
        _OddColor ("Color 2", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Geometry"}
        

        Pass{
            CGPROGRAM
            #include "UnityCG.cginc"

            #pragma vertex vert
            #pragma fragment frag

            float _Scale;

            float4 _EvenColor;
            float4 _OddColor;

            struct appdata{
                float4 vertex : POSITION;
            };

            struct v2f{
                float4 position : SV_POSITION;
                float3 worldPos : TEXCOORD0;
            };

            v2f vert(appdata v){
                v2f o;

                // Calculate the position in clip space to render the object
                o.position = UnityObjectToClipPos(v.vertex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_TARGET{
                // Scale the position to adjust for shader input and floor the values so we have whole numbers
                float3 adjustedWorldPos = floor(i.worldPos / _Scale);
                // Add different dimensions

                float chessboard = adjustedWorldPos.x + adjustedWorldPos.y + adjustedWorldPos.z;
                // Divide it by 2 and get the fractional part, resulting in a value of 0 for even and 0.5 for odd parts
                chessboard = frac(chessboard * 0.5);
                // Multiply it by 2 to make odd values white instead of grey

                chessboard *= 2;

                // Interpolate between colors for even and odd fields

                float4 color = lerp(_EvenColor, _OddColor, chessboard);

                return color;
            }

            ENDCG
        }
    }
    FallBack "Standard"
}
