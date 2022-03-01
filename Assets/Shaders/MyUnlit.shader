Shader "MyUnlit"
{
    Properties
    {
        _Color ( "My Color" , Color ) = ( 1,1,1,1)
    }
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            uniform float4 _Color;
            uniform float4 _LightColor0;

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float4 color : COLOR;
            };

            v2f vert (appdata v)
            {
                v2f o;
                float3 normalDirection = (mul(float4(v.normal, 0.0), unity_WorldToObject).xyz);
                float3 lightDirection;
                float atten = 1.0;

                lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 diffuseReflection = atten * _LightColor0.xyz * _Color.rgb * max(0.0, dot(normalDirection, lightDirection));
                
                //o.color.rgb = v.normal.xyz;
                o.color = float4(diffuseReflection, 1.0);
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return i.color;
            }
            ENDCG
        }
    }
}
