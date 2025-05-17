// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "FK/EFF_Particle_CZSM01_gai"
{
	Properties
	{
		[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		[HideInInspector] _EmissionColor("Emission Color", Color) = (1,1,1,1)
		[HideInInspector] _AlphaCutoff("Alpha Cutoff ", Range(0, 1)) = 0.5
		[ASEBegin][Toggle(_USE_SHADERMODE)]_ShaderMode("粒子模式", Float) = 1
		[Enum(UnityEngine.Rendering.BlendMode)]_BlendMode("混合模式", Float) = 10
		[Enum(UnityEngine.Rendering.CompareFunction)]_ZTest("深度模式", Float) = 4
		_alpha("Alpha强度", Float) = 1
		[Toggle(_USE_DEPTHMODE)]_DepthMode("开启剪切模式", Float) = 0
		_CUTOUT("剪切", Range( 0 , 1)) = 0.5
		[Enum(UnityEngine.Rendering.CullMode)]_CullMode("剔除模式开启正反面", Float) = 0
		_Brightness("主图亮度", Float) = 1
		_Contrast("主图对比度", Float) = 1
		[Toggle]_Tex91("贴图旋转90度", Float) = 0
		_TextureS("主贴图", 2D) = "white" {}
		[HDR]_Color4("主贴图颜色", Color) = (1,1,1,1)
		[Enum(R,0,Alpha,1)]_AlphaR("使用A通道或者R通道", Float) = 0
		_Float0("贴图去色", Range( 0 , 1)) = 0
		_MainPannerX("贴图U方向移动", Float) = 0
		_MainPannerY("贴图V方向移动", Float) = 0
		[Enum(R,0,Alpha,1)]_Alpha_R_Mask("MASK使用A通道或者R通道", Float) = 0
		[Toggle(_USE_MASK)]_UseMask("开启遮罩", Range( 0 , 1)) = 0
		_TextureZZ("遮罩贴图", 2D) = "white" {}
		[Toggle(_USE_FLOAT1)]_Float1("开启扰动", Float) = 0
		_NoiseSpeed("遮罩速度", Vector) = (0,0,0,0)
		_Noise("扰动溶解贴图", 2D) = "white" {}
		_DistortPower("扰动强度", Float) = 0
		_PowerU("U方向扰动速度", Float) = 0
		_PowerV("V方向扰动速度", Float) = 0
		[Toggle(_USE_CLIP)]_UseClip("开启溶解 xxxx", Range( 0 , 1)) = 0
		_Dissolve2("溶解强度", Range( 0 , 1)) = 0
		_Float2("溶解软硬边缘", Range( 0 , 1)) = 0
		_EdgeWidth("溶解边缘宽度", Range( 0 , 1)) = 0
		[HDR]_Widthcolor("溶解边缘颜色", Color) = (7.167322,7.167322,7.167322,1)
		[Toggle(_USE_MASK1)]_UseMask1("开启主图2", Range( 0 , 1)) = 0
		_TextureS1("主贴图2", 2D) = "white" {}
		[Enum(R,0,Alpha,1)]_AlphaR1("主图2使用A通道或者R通道", Float) = 0
		[ASEEnd]_NoiseSpeed1("主图2速度", Vector) = (0,0,0,0)
		[Toggle(_USE_POLAR1)]_polar1("开启极坐标", Range( 0 , 1)) = 0
		_TlingOffset3("极坐标UV重复度", Vector) = (1,1,0,0)
		_Vector2("极坐标偏移数值", Vector) = (0,0,0,0)
		//_UseClipRect("Use Clip Rect", Float) = 0.0
        //_ClipRect("Clip Rect", Vector) = (0,0,0,0)

		// #### required for Mask ####
		_StencilComp ("Stencil Comparison", Float) = 8
        _Stencil ("Stencil ID", Float) = 0
        _StencilOp ("Stencil Operation", Float) = 0
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilReadMask ("Stencil Read Mask", Float) = 255
        _ColorMask ("Color Mask", Float) = 15
        //[Toggle(UNITY_UI_ALPHACLIP)] _UseUIAlphaClip ("Use Alpha Clip", Float) = 0
	}

	SubShader
	{
		LOD 0

		

		Tags { "RenderPipeline"="UniversalPipeline" "RenderType"="Transparent" "Queue"="Transparent" }

		// #### required for Mask ####
		Stencil
        {
            Ref [_Stencil]
            Comp [_StencilComp]
            Pass [_StencilOp]
            ReadMask [_StencilReadMask]
            WriteMask [_StencilWriteMask]
        }
        ColorMask [_ColorMask]
		
		Cull [_CullMode]
		HLSLINCLUDE
		#pragma target 3.0
		ENDHLSL

		
		Pass
		{
			Name "Unlit"
			

			Blend SrcAlpha [_BlendMode], One OneMinusSrcAlpha
			ZTest [_ZTest]
			ZWrite Off
			Offset 0 , 0
			ColorMask RGBA
			

			HLSLPROGRAM
			#define ASE_SRP_VERSION 999999

			#pragma prefer_hlslcc gles
			#pragma exclude_renderers d3d11_9x
			#pragma shader_feature _ _USE_CLIP
			#pragma shader_feature _ _USE_MASK1
			#pragma shader_feature _ _USE_MASK
			#pragma shader_feature _ _USE_POLAR1
			#pragma shader_feature _ _USE_FLOAT1
			#pragma shader_feature _ _USE_DEPTHMODE
			#pragma shader_feature _ _USE_SHADERMODE

			#pragma vertex vert
			#pragma fragment frag

			#pragma multi_compile _ ETC1_EXTERNAL_ALPHA

			#define _SURFACE_TYPE_TRANSPARENT 1
			#define SHADERPASS_SPRITEUNLIT

			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"

			#define ASE_NEEDS_FRAG_COLOR

			//#### required for RectMask2D ####
            //#pragma multi_compile __ UNITY_UI_CLIP_RECT
            //float4 _ClipRect;

			// #### required for Mask ####
            //#pragma multi_compile __ UNITY_UI_ALPHACLIP


			sampler2D _TextureS;
			sampler2D _Noise;
			sampler2D _TextureS1;
			sampler2D _TextureZZ;
			CBUFFER_START( UnityPerMaterial )
			float4 _Color4;
			float4 _TextureS1_ST;
			float4 _Widthcolor;
			float4 _TextureS_ST;
			float4 _TextureZZ_ST;
			float4 _NoiseSpeed;
			float4 _NoiseSpeed1;
			float4 _Noise_ST;
			float4 _Vector2;
			half4 _TlingOffset3;
			//float _UseMask1;
			half _EdgeWidth;
			float _Float2;
			half _alpha;
			half _AlphaR;
			half _Alpha_R_Mask;
			//float _UseMask;
			half _AlphaR1;
			//half _UseClip;
			float _ZTest;
			half _Contrast;
			half _CUTOUT;
			float _Float0;
			float _Tex91;
			//float _Float1;
			half _PowerV;
			half _PowerU;
			half _DistortPower;
			half _Dissolve2;
			half _MainPannerY;
			half _MainPannerX;
			//half _ShaderMode;
			half _BlendMode;
			half _CullMode;
			half _Brightness;
			//half _DepthMode;
			//half _polar1;
			//float _UseClipRect;
			//float4 _ClipRect;
			CBUFFER_END

 
			struct VertexInput
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 tangent : TANGENT;
				float4 uv0 : TEXCOORD0;
				float4 color : COLOR;
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_texcoord1 : TEXCOORD1;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 clipPos : SV_POSITION;
				float4 texCoord0 : TEXCOORD0;
				float4 color : TEXCOORD1;
				float4 ase_texcoord2 : TEXCOORD2;
				float4 ase_texcoord3 : TEXCOORD3;
				float4 worldPosition : TEXCOORD4;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			#if ETC1_EXTERNAL_ALPHA
				TEXTURE2D( _AlphaTex ); SAMPLER( sampler_AlphaTex );
				float _EnableAlphaTexture;
			#endif

			float4 _RendererColor;

			
			VertexOutput vert( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID( v );
				UNITY_TRANSFER_INSTANCE_ID( v, o );
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( o );

				o.ase_texcoord2 = v.ase_texcoord2;
				o.ase_texcoord3 = v.ase_texcoord1;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.vertex.xyz;
				#else
					float3 defaultVertexValue = float3( 0, 0, 0 );
				#endif
				float3 vertexValue = defaultVertexValue;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.vertex.xyz = vertexValue;
				#else
					v.vertex.xyz += vertexValue;
				#endif
				v.normal = v.normal;

				VertexPositionInputs vertexInput = GetVertexPositionInputs( v.vertex.xyz );

				o.texCoord0 = v.uv0;
				o.color = v.color;
				o.clipPos = vertexInput.positionCS;
				o.worldPosition = v.vertex;

				return o;
			}

			float UnityGet2DClipping(in float2 position, in float4 clipRect)
			{
				float2 inside = step(clipRect.xy, position.xy) * step(position.xy, clipRect.zw);
				return inside.x * inside.y;
			}

			half4 frag( VertexOutput IN  ) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID( IN );
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( IN );
		 
				float2 uv_TextureS = IN.texCoord0.xy * _TextureS_ST.xy + _TextureS_ST.zw;
#if _USE_SHADERMODE
				//float4 texCoord61 = IN.ase_texcoord2;
				//texCoord61.xy = IN.ase_texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
				float2 appendResult141 = (float2(1.0 , 1.0));
				float4 lerpResult143 =  float4(appendResult141, 0.0 , 0.0 );
				float4 break144 = lerpResult143;
				float2 appendResult292 = (float2(break144.x , break144.y));
				half2 UV3379 = appendResult292;
				float2 temp_output_63_0 = ( UV3379 + float2( -1,-1 ) );
				//float4 texCoord19 = IN.ase_texcoord3;
				//texCoord19.xy = IN.ase_texcoord3.xy * float2( 1,1 ) + float2( 0,0 );
				float4 appendResult137 = (float4(( _MainPannerX * ( _TimeParameters.x ) ) , ( ( _TimeParameters.x ) * _MainPannerY ) , _Dissolve2 , _DistortPower));
				float4 lerpResult497 =  appendResult137;
#else
				float4 texCoord61 = IN.ase_texcoord2;
				texCoord61.xy = IN.ase_texcoord2.xy * float2(1, 1) + float2(0, 0);
				float4 break144 = texCoord61;
				float2 appendResult292 = (float2(break144.x, break144.y));
				half2 UV3379 = appendResult292;
				float2 temp_output_63_0 = (UV3379 + float2(-1, -1));
				float4 texCoord19 = IN.ase_texcoord3;
				texCoord19.xy = IN.ase_texcoord3.xy * float2(1, 1) + float2(0, 0);
				float4 lerpResult497 = texCoord19;
#endif
		
		
				float4 break128 = lerpResult497;
				float2 appendResult21 = (float2(break128.x , break128.y));
				half2 uv2474 = appendResult21;

				float2 uv_Noise = IN.texCoord0.xy * _Noise_ST.xy + _Noise_ST.zw;
				float2 appendResult36 = (float2(_PowerU, _PowerV));
				half Distort_02478 = tex2D(_Noise, (uv_Noise + (appendResult36 * (_TimeParameters.x)))).r;
		
#ifdef _USE_FLOAT1
				
				half Distort148 = break128.w;
				float lerpResult485 = ( ( Distort_02478 - 0.5 ) * Distort148 );
				half Distort_01484 = lerpResult485;
#else 
				half Distort_01484 = 0.0;
#endif
		
		

#ifdef _USE_POLAR1
				float2 UV_main383 = ( ( ( uv_TextureS * temp_output_63_0 ) + ( temp_output_63_0 * float2( -0.5,-0.5 ) ) ) + uv_TextureS + uv2474 + Distort_01484 );
				float2 temp_output_363_0 = (UV_main383*2.0 + -1.0);
				float2 break358 = temp_output_363_0;
				float2 appendResult362 = (float2(length( temp_output_363_0 ) , (0.0 + (atan2( break358.y , break358.x ) - 0.0) * (1.0 - 0.0) / (3.141593 - 0.0))));
				float2 lerpResult357 = appendResult362;
#else
				float2 lerpResult357 = (((uv_TextureS * temp_output_63_0) + (temp_output_63_0 * float2(-0.5, -0.5))) + uv_TextureS + uv2474 + Distort_01484);
#endif
		
		
				float2 jzb02389 = lerpResult357;
				float2 appendResult365 = (float2(_TlingOffset3.x , _TlingOffset3.y));
				float2 appendResult405 = (float2(_Vector2.x , _Vector2.y));
				float2 panner406 = ( 1.0 * _Time.y * appendResult405 + float2( 0,0 ));
				half2 edgebrightness152 = panner406;
				float2 temp_output_378_0 = ( (jzb02389*appendResult365 + 0.0) + edgebrightness152 );
				float2 appendResult594 = (float2(temp_output_378_0));
				float2 appendResult598 = (float2((appendResult594).y , (appendResult594).x));
				float2 lerpResult599 = lerp( temp_output_378_0 , appendResult598 , _Tex91);
		
		
				float2 JZB385 = lerpResult599;
				float4 tex2DNode3 = tex2D( _TextureS, JZB385 );
				float3 desaturateInitialColor271 = tex2DNode3.rgb;
				float desaturateDot271 = dot( desaturateInitialColor271, float3( 0.299, 0.587, 0.114 ));
				float3 desaturateVar271 = lerp( desaturateInitialColor271, desaturateDot271.xxx, _Float0 );
				float3 temp_cast_2 = (max( _Contrast , 0.01 )).xxx;
		
#ifdef _USE_MASK1
				//float4 temp_cast_4 = (1.0).xxxx;
				float2 appendResult645 = (float2(_NoiseSpeed1.x , _NoiseSpeed1.y));
				float2 uv_TextureS1 = IN.texCoord0.xy * _TextureS1_ST.xy + _TextureS1_ST.zw;
				float2 panner646 = ( 1.0 * _Time.y * appendResult645 + uv_TextureS1);
				float4 tex2DNode637 = tex2D( _TextureS1, panner646 );
				float4 lerpResult647 = tex2DNode637;
#else
				float4 lerpResult647 = (1.0).xxxx;
#endif
		
#ifdef _USE_CLIP
				//float2 temp_cast_5 = (1.0).xx;
				float temp_output_87_0 = ( Distort_02478 + 1.0 );
				half dissolve146 = break128.z;
				float temp_output_116_0 = ( dissolve146 * ( 1.0 + _EdgeWidth ) );
				float temp_output_469_0 = (0.0 + (_Float2 - 0.0) * (1.0 - 0.0) / (1.0 - 0.0));
				float HA471 = temp_output_469_0;
				float temp_output_91_0 = ( 1.0 - HA471 );
				float2 appendResult158 = (float2(saturate( ( ( ( temp_output_87_0 - ( temp_output_116_0 * ( 1.0 + temp_output_91_0 ) ) ) - temp_output_469_0 ) / ( 1.0 - temp_output_469_0 ) ) ) , saturate( ( ( ( temp_output_87_0 - ( ( temp_output_116_0 - _EdgeWidth ) * ( 1.0 + temp_output_91_0 ) ) ) - temp_output_469_0 ) / ( 1.0 - temp_output_469_0 ) ) )));
				float2 lerpResult468 = appendResult158;
				float2 break159 = lerpResult468;
#else
				float2 break159 = (1.0).xx;
#endif
		
		
				float lerpResult652 = lerp( 1.0 , break159.x , _Widthcolor.a);
				float4 lerpResult109 = lerp(_Widthcolor, (float4(pow(abs(desaturateVar271), temp_cast_2), 0.0) * _Brightness * _Color4 * IN.color * lerpResult647), lerpResult652);
				float lerpResult392 = lerp( tex2DNode3.r , tex2DNode3.a , _AlphaR);
#if _USE_MASK
				float2 appendResult608 = (float2(_NoiseSpeed.x , _NoiseSpeed.y));
				float2 uv_TextureZZ = IN.texCoord0.xy * _TextureZZ_ST.xy + _TextureZZ_ST.zw;
				float2 panner607 = ( 1.0 * _Time.y * appendResult608 + uv_TextureZZ);
				float4 tex2DNode24 = tex2D( _TextureZZ, panner607 );
				float lerpResult555 = lerp( tex2DNode24.r , tex2DNode24.a , _Alpha_R_Mask);
				float lerpResult496 = lerpResult555;
				float MASK395 = lerpResult496;
#else
				float MASK395 = 1.0;
#endif
		
#if _USE_MASK1
				float lerpResult638 = lerp( tex2DNode637.r , tex2DNode637.a , _AlphaR1);
				float lerpResult640 = lerpResult638;
#else
				float lerpResult640 = 1.0;
#endif
				
				float temp_output_74_0 = min( ( IN.color.a * lerpResult392 * _alpha * MASK395 * break159.y * lerpResult640 * _Color4.a ) , 1.0 );
				float4 appendResult173 = (float4(lerpResult109.rgb , temp_output_74_0));
#if _USE_DEPTHMODE
				clip( temp_output_74_0 - min( _CUTOUT , 1 ));
				float3 appendResult171 = (float3(lerpResult109.rgb));
				float4 appendResult172 = (float4(appendResult171 , 1.0));
				float4 lerpResult170 = appendResult172;
#else
				float4 lerpResult170 = appendResult173;
#endif
				
				float4 Color = lerpResult170;

				#if ETC1_EXTERNAL_ALPHA
					float4 alpha = SAMPLE_TEXTURE2D( _AlphaTex, sampler_AlphaTex, IN.texCoord0.xy );
					Color.a = lerp( Color.a, alpha.r, _EnableAlphaTexture );
				#endif

				// #### required for RectMask2D ####
                //#ifdef UNITY_UI_CLIP_RECT
                   //Color.a *= UnityGet2DClipping(IN.worldPosition.xy, _ClipRect);
                //#endif

				Color *= IN.color;
				//float c = UnityGet2DClipping(IN.worldPosition.xy, _ClipRect); // 2D Mask 剪裁
				//Color.a = lerp(Color.a, c * Color.a, _UseClipRect);
				//Color.a = lerp(Color.a, Color * Color.a, _UseClipRect);

				// #### required for Mask ####
                //#ifdef UNITY_UI_ALPHACLIP
                    //clip (Color.a - 0.001);
                //#endif

				return Color;
			}

			ENDHLSL
		}
	}
	//CustomEditor "UnityEditor.ShaderGraph.PBRMasterGUI"
	Fallback "Hidden/InternalErrorShader"
	
}