# Shader 学习（一）

## **一、卡通着色**

### 1、目标

将Unity提供的默认球体加上Toon Shading（卡通着色）就可以了。

### 2、准备

+ 创建场景；

![image](https://i.loli.net/2019/07/11/5d26b4057bcae71068.png)

+ 在场景创建球;

![image](https://i.loli.net/2019/07/11/5d26b4055bcd640441.png)

+ 在 Assets 目录中创建材质；

+ 在 Assets 目录中创建Shader；

![image](https://i.loli.net/2020/07/17/VupfEharjk2GStx.png)

+ 把 Shader 贴到材质上；

![image](https://i.loli.net/2020/07/17/hjAbL32yR9lJIDU.png)

+ 把材质贴到球上;

![image](https://i.loli.net/2019/07/11/5d26b405a697090913.png)

### 3、材质

材质的本质对于笔者来说就是 Shader + Texture（贴图）.一个材质就是由 Shader 和 Texture 组成的.

这一句适用于通常情况下，有的时候，材质只有 Shader，并没有 Texture，而是需要我们调整一些参数。所以“材质由 Shader 和 Texture 组成”这句话，更准确地说应该是“材质由 Shader 和 数据组成”。

### 4、Shader代码

``` C
Shader "Master/Toon"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        // No culling or depth
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

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;

            float4 frag (v2f i) : SV_Target
            {
                // 图片上每个像素的颜色值
                float4 color = tex2D(_MainTex, i.uv);

                color.r = 0;

                // 返回颜色，表示将改像素的颜色值输出到屏幕上
                return color;
            }
            ENDCG
        }
    }
}
```


