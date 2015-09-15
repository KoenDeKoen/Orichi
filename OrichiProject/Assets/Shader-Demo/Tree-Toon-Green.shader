// Shader created with Shader Forge v1.17 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.17;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:9361,x:33209,y:32712,varname:node_9361,prsc:2|custl-5670-OUT;n:type:ShaderForge.SFN_LightVector,id:6869,x:31932,y:33050,varname:node_6869,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:9684,x:31932,y:33185,prsc:2,pt:False;n:type:ShaderForge.SFN_Multiply,id:8979,x:32891,y:32917,varname:node_8979,prsc:2|A-5377-OUT,B-6931-OUT;n:type:ShaderForge.SFN_Multiply,id:5377,x:32744,y:32797,varname:node_5377,prsc:2|A-8200-RGB,B-5904-OUT;n:type:ShaderForge.SFN_Multiply,id:6931,x:32766,y:33030,varname:node_6931,prsc:2|A-650-RGB,B-4394-RGB;n:type:ShaderForge.SFN_LightColor,id:8200,x:32561,y:32700,varname:node_8200,prsc:2;n:type:ShaderForge.SFN_LightAttenuation,id:5904,x:32561,y:32819,varname:node_5904,prsc:2;n:type:ShaderForge.SFN_VertexColor,id:650,x:32425,y:32972,varname:node_650,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:4394,x:32507,y:33263,ptovrint:False,ptlb:Ramp 2,ptin:_Ramp2,varname:node_4394,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:bb179db00762e93418a89de817fd4221,ntxv:0,isnm:False|UVIN-6913-OUT;n:type:ShaderForge.SFN_Append,id:6913,x:32283,y:33209,varname:node_6913,prsc:2|A-6608-OUT,B-5886-OUT;n:type:ShaderForge.SFN_Vector1,id:5886,x:32037,y:33405,varname:node_5886,prsc:2,v1:0;n:type:ShaderForge.SFN_Dot,id:6608,x:32101,y:33076,varname:node_6608,prsc:2,dt:0|A-6869-OUT,B-9684-OUT;n:type:ShaderForge.SFN_Add,id:6258,x:33041,y:32819,varname:node_6258,prsc:2|A-2660-RGB,B-8979-OUT;n:type:ShaderForge.SFN_Multiply,id:5670,x:33001,y:32620,varname:node_5670,prsc:2|A-2660-RGB,B-8979-OUT;n:type:ShaderForge.SFN_Color,id:4304,x:32964,y:33152,ptovrint:False,ptlb:node_4304,ptin:_node_4304,varname:node_4304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Color,id:2660,x:32561,y:32539,ptovrint:False,ptlb:node_2660,ptin:_node_2660,varname:node_2660,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.1313797,c2:0.5955882,c3:0.1922071,c4:1;proporder:4394-2660;pass:END;sub:END;*/

Shader "Shader Forge/Tree-Toon-Green" {
    Properties {
        _Ramp2 ("Ramp 2", 2D) = "white" {}
        _node_2660 ("node_2660", Color) = (0.1313797,0.5955882,0.1922071,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _Ramp2; uniform float4 _Ramp2_ST;
            uniform float4 _node_2660;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(2,3)
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float2 node_6913 = float2(dot(lightDirection,i.normalDir),0.0);
                float4 _Ramp2_var = tex2D(_Ramp2,TRANSFORM_TEX(node_6913, _Ramp2));
                float3 node_8979 = ((_LightColor0.rgb*attenuation)*(i.vertexColor.rgb*_Ramp2_var.rgb));
                float3 finalColor = (_node_2660.rgb*node_8979);
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _Ramp2; uniform float4 _Ramp2_ST;
            uniform float4 _node_2660;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(2,3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float2 node_6913 = float2(dot(lightDirection,i.normalDir),0.0);
                float4 _Ramp2_var = tex2D(_Ramp2,TRANSFORM_TEX(node_6913, _Ramp2));
                float3 node_8979 = ((_LightColor0.rgb*attenuation)*(i.vertexColor.rgb*_Ramp2_var.rgb));
                float3 finalColor = (_node_2660.rgb*node_8979);
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
