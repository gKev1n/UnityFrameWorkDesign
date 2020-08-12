# Shader 学习（二）

## **一、卡通着色（二）**

### 1、目标

将（一）中的球变成立体的。

### 2、准备

先看下目前我们的“纸片球”的效果是这样的：

![image](https://i.loli.net/2019/07/11/5d26b405a697090913.png)

那么怎么完成立体的球呢？实现的思路就是让这个球有明暗的对比，这就要通过计算光的处理进行实现明暗对比这一效果。

### 3、 操作

那么为了让这个球有明暗对比，则需要在 Shader 中对光进行处理，就会达到我们想要的 “立体球” 了。

接下来我们需要更改 Shader 代码即可实现：

``` shaderlab
Shader "Master/Toon"
{
    Properties
    {
        _Diffuse("Diffuse",Color) = (1,1,1,1)
    }
    SubShader
    {
        Pass
        {
            Tags { "LightMode" = "ForwardBase"}

            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "Lighting.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal:NORMAL;
            };

            struct v2f
            {
                float4 pos: SV_POSITION; 
                float3 color : Color;
            };

            float4 _Diffuse;

            v2f vert (appdata v)
            {
                v2f o;

                o.pos = UnityObjectToClipPos(v.vertex);

                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz;

                fixed3 worldNormal = normalize(mul(v.normal,(float3x3)unity_WorldToObject));

                fixed3 worldLight = normalize(_WorldSpaceLightPos0.xyz);

                fixed3 diffuse = _LightColor0.rgb * _Diffuse.rgb * saturate(dot(worldNormal, worldLight));

                o.color = ambient + diffuse;

                return o;
            }


            float4 frag (v2f i) : SV_Target
            {
                return fixed4(i.color,1.0);
            }
            ENDCG
        }
    }
}
```

编译之后就可以得到一个立体的球了。

### 4、效果

![image](https://i.loli.net/2019/07/16/5d2de177a2cfd67333.png)

### 5、解释

#### ***Properties***

首先看一下 Properties 部分，代码如下：

```shaderlab
Properties
{
    _Diffuse("Diffuse", Color) = (1,1,1,1) // 基础色值
}
```

在 Properties 中，定义了一个 Diffuse 的属性。Diffuse在英文中是散射、扩散的意思，在 Shader（图形学）术语中，叫做漫反射，
但是这里的 Diffuse 属性并不属于漫反射本身，而是一个基础颜色，我们的漫反射计算是在这个颜色上叠加而成的。

#### ***SubShader***

##### ***Pass***

在这个 Shader 代码中有一个 SubShader，而这个 SubShader 中有一个Pass，即含有一个通道。

在这个 Pass 中的：

```shaderlab
// 片元着色器(像素着色器）
// 逐像素计算颜色，输出到屏幕上（或帧缓冲里）
float4 frag (v2f i) : SV_Target
{
    return fixed4(i.color,1.0);
}
```

试着解读一下这个代码。

很明显这个代码是一个方法/函数。方法名为 frag， 返回值为 float4 类型，接受的参数是 v2f 类型。

首先方法名 frag 是 fragment 的缩写，fragment 的英文意思是片段、碎片的意思。而在图形学术语中， fragment叫做片元，
所以 fragment shader 就是片元着色器，而片元着色器所做的操作就是处理片元。

片元着色器有个别名，又称像素着色器， 片元（ fragment ）是 OpenGL 的GLSL（OpenGL着色语言）中的一个概念。
也就是说，frag 方法做的事情就是每个像素都计算（返回）一遍颜色，并输出（返回）给屏幕即可。
