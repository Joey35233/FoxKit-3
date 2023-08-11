{
#if defined(SHADER_STAGE_VERTEX)
	// SYSTEM 0
	g_vsSystem.m_param = UnityPatch_g_sSystem_m_param; // w = alpha test threshold
	g_vsSystem.m_renderInfo = UnityPatch_g_sSystem_m_renderInfo; //float4(_ScreenParams.xy, 0, 0);
	g_vsSystem.m_renderBuffer = UnityPatch_g_sSystem_m_renderBuffer; //float4(g_vsSystem.m_renderInfo.xy, 1 / g_vsSystem.m_renderInfo.xy);
	g_vsSystem.m_dominantLightDir = UnityPatch_g_sSystem_m_dominantLightDir; //ApplyMatrixT(GetTranspose(unity_MatrixV), _WorldSpaceLightPos0);

	// SCENE 2
	g_vsScene.m_projectionView = UnityPatch_g_sScene_m_projectionView;
	g_vsScene.m_projection = UnityPatch_g_sScene_m_projection;
	g_vsScene.m_view = UnityPatch_g_sScene_m_view;
	g_vsScene.m_shadowProjection = UnityPatch_g_sScene_m_shadowProjection;
	g_vsScene.m_shadowProjection2 = UnityPatch_g_sScene_m_shadowProjection2;
	g_vsScene.m_eyepos = UnityPatch_g_sScene_m_eyepos;
	g_vsScene.m_projectionParam = UnityPatch_g_sScene_m_projectionParam;
	g_vsScene.m_viewportSize = UnityPatch_g_sScene_m_viewportSize;
	g_vsScene.m_exposure = UnityPatch_g_sScene_m_exposure;
	g_vsScene.m_fogParam[0] = UnityPatch_g_sScene_m_fogParam_0;
	g_vsScene.m_fogParam[1] = UnityPatch_g_sScene_m_fogParam_1;
	g_vsScene.m_fogParam[2] = UnityPatch_g_sScene_m_fogParam_2;
	g_vsScene.m_fogColor = UnityPatch_g_sScene_m_fogColor;
	g_vsScene.m_cameraCenterOffset = UnityPatch_g_sScene_m_cameraCenterOffset;
	g_vsScene.m_shadowMapResolutions = UnityPatch_g_sScene_m_shadowMapResolutions;

	// RENDERBUFFER 1

	// LIGHTS 3
	g_vsLight.m_lightParams[0] = UnityPatch_g_sLights_m_lightParams_0;
	g_vsLight.m_lightParams[1] = UnityPatch_g_sLights_m_lightParams_1;
	g_vsLight.m_lightParams[2] = UnityPatch_g_sLights_m_lightParams_2;
	g_vsLight.m_lightParams[3] = UnityPatch_g_sLights_m_lightParams_3;
	g_vsLight.m_lightParams[4] = UnityPatch_g_sLights_m_lightParams_4;
	g_vsLight.m_lightParams[5] = UnityPatch_g_sLights_m_lightParams_5;
	g_vsLight.m_lightParams[6] = UnityPatch_g_sLights_m_lightParams_6;
	g_vsLight.m_lightParams[7] = UnityPatch_g_sLights_m_lightParams_7;
	g_vsLight.m_lightParams[8] = UnityPatch_g_sLights_m_lightParams_8;
	g_vsLight.m_lightParams[9] = UnityPatch_g_sLights_m_lightParams_9;
	g_vsLight.m_lightParams[10] = UnityPatch_g_sLights_m_lightParams_10;

	// MATERIAL 4
	g_vsMaterial.m_materials[0] = UnityPatch_g_sMaterial_m_materials_0;
	g_vsMaterial.m_materials[1] = UnityPatch_g_sMaterial_m_materials_1;
	g_vsMaterial.m_materials[2] = UnityPatch_g_sMaterial_m_materials_2;
	g_vsMaterial.m_materials[3] = UnityPatch_g_sMaterial_m_materials_3;
	g_vsMaterial.m_materials[4] = UnityPatch_g_sMaterial_m_materials_4;
	g_vsMaterial.m_materials[5] = UnityPatch_g_sMaterial_m_materials_5;
	g_vsMaterial.m_materials[6] = UnityPatch_g_sMaterial_m_materials_6;
	g_vsMaterial.m_materials[7] = UnityPatch_g_sMaterial_m_materials_7;

	// OBJECT 5
	g_vsObject.m_viewWorld = mul(GetTranspose(unity_ObjectToWorld), g_vsScene.m_view);
	g_vsObject.m_world = GetTranspose(unity_ObjectToWorld);
	g_vsObject.m_useWeightCount = float4(UnityPatch_g_sObject_m_useWeightCount.x, 0, 0, unity_LODFade.x > 0 ? unity_LODFade.x : 1 + unity_LODFade.x);
	g_vsObject.m_localParam[0] = UnityPatch_g_sObject_m_localParam_0;
	g_vsObject.m_localParam[1] = UnityPatch_g_sObject_m_localParam_1;
	g_vsObject.m_localParam[2] = UnityPatch_g_sObject_m_localParam_2;
	g_vsObject.m_localParam[3] = UnityPatch_g_sObject_m_localParam_3;

	// BONE 6

	// WORK 7
#if defined(UNITYPATCH_WORK_TYPE_SPHEREMAP)
#elif defined(UNITYPATCH_WORK_TYPE_SHLIGHT)
#elif defined(UNITYPATCH_WORK_TYPE_VECTORS)
#else
	g_vsWork.m_viewInverse = m_viewInverse;
	g_vsWork.m_matrix = UnityPatch_g_sWork_m_matrix;
#endif

#endif
		
#if defined(SHADER_STAGE_FRAGMENT)
	// SYSTEM 0
	g_psSystem.m_param = UnityPatch_g_sSystem_m_param; // w = alpha test threshold
	g_psSystem.m_renderInfo = UnityPatch_g_sSystem_m_renderInfo; //float4(_ScreenParams.xy, 0, 0);
	g_psSystem.m_renderBuffer = UnityPatch_g_sSystem_m_renderBuffer; //float4(g_psSystem.m_renderInfo.xy, 1 / g_psSystem.m_renderInfo.xy);
	g_psSystem.m_dominantLightDir = UnityPatch_g_sSystem_m_dominantLightDir; //ApplyMatrixT(GetTranspose(unity_MatrixV), _WorldSpaceLightPos0);

	// SCENE 2
	g_psScene.m_projectionView = UnityPatch_g_sScene_m_projectionView;
	g_psScene.m_projection = UnityPatch_g_sScene_m_projection;
	g_psScene.m_view = UnityPatch_g_sScene_m_view;
	g_psScene.m_shadowProjection = UnityPatch_g_sScene_m_shadowProjection;
	g_psScene.m_shadowProjection2 = UnityPatch_g_sScene_m_shadowProjection2;
	g_psScene.m_eyepos = UnityPatch_g_sScene_m_eyepos;
	g_psScene.m_projectionParam = UnityPatch_g_sScene_m_projectionParam;
	g_psScene.m_viewportSize = UnityPatch_g_sScene_m_viewportSize;
	g_psScene.m_exposure = UnityPatch_g_sScene_m_exposure;
	g_psScene.m_fogParam[0] = UnityPatch_g_sScene_m_fogParam_0;
	g_psScene.m_fogParam[1] = UnityPatch_g_sScene_m_fogParam_1;
	g_psScene.m_fogParam[2] = UnityPatch_g_sScene_m_fogParam_2;
	g_psScene.m_fogColor = UnityPatch_g_sScene_m_fogColor;
	g_psScene.m_cameraCenterOffset = UnityPatch_g_sScene_m_cameraCenterOffset;
	g_psScene.m_shadowMapResolutions = UnityPatch_g_sScene_m_shadowMapResolutions;

	// RENDERBUFFER 1

	// LIGHTS 3
	g_psLight.m_lightParams[0] = UnityPatch_g_sLights_m_lightParams_0;
	g_psLight.m_lightParams[1] = UnityPatch_g_sLights_m_lightParams_1;
	g_psLight.m_lightParams[2] = UnityPatch_g_sLights_m_lightParams_2;
	g_psLight.m_lightParams[3] = UnityPatch_g_sLights_m_lightParams_3;
	g_psLight.m_lightParams[4] = UnityPatch_g_sLights_m_lightParams_4;
	g_psLight.m_lightParams[5] = UnityPatch_g_sLights_m_lightParams_5;
	g_psLight.m_lightParams[6] = UnityPatch_g_sLights_m_lightParams_6;
	g_psLight.m_lightParams[7] = UnityPatch_g_sLights_m_lightParams_7;
	g_psLight.m_lightParams[8] = UnityPatch_g_sLights_m_lightParams_8;
	g_psLight.m_lightParams[9] = UnityPatch_g_sLights_m_lightParams_9;
	g_psLight.m_lightParams[10] = UnityPatch_g_sLights_m_lightParams_10;

	// MATERIAL 4
	g_psMaterial.m_materials[0] = UnityPatch_g_sMaterial_m_materials_0;
	g_psMaterial.m_materials[1] = UnityPatch_g_sMaterial_m_materials_1;
	g_psMaterial.m_materials[2] = UnityPatch_g_sMaterial_m_materials_2;
	g_psMaterial.m_materials[3] = UnityPatch_g_sMaterial_m_materials_3;
	g_psMaterial.m_materials[4] = UnityPatch_g_sMaterial_m_materials_4;
	g_psMaterial.m_materials[5] = UnityPatch_g_sMaterial_m_materials_5;
	g_psMaterial.m_materials[6] = UnityPatch_g_sMaterial_m_materials_6;
	g_psMaterial.m_materials[7] = UnityPatch_g_sMaterial_m_materials_7;

	// OBJECT 5
	g_psObject.m_viewWorld = mul(GetTranspose(unity_ObjectToWorld), g_psScene.m_view);
	g_psObject.m_world = GetTranspose(unity_ObjectToWorld);
	g_psObject.m_useWeightCount = float4(UnityPatch_g_sObject_m_useWeightCount.x, 0, 0, unity_LODFade.x > 0 ? unity_LODFade.x : 1 + unity_LODFade.x);
	g_psObject.m_localParam[0] = UnityPatch_g_sObject_m_localParam_0;
	g_psObject.m_localParam[1] = UnityPatch_g_sObject_m_localParam_1;
	g_psObject.m_localParam[2] = UnityPatch_g_sObject_m_localParam_2;
	g_psObject.m_localParam[3] = UnityPatch_g_sObject_m_localParam_3;

	// BONE 6

	// WORK 7
#if defined(UNITYPATCH_WORK_TYPE_SPHEREMAP)
	g_psParamSH.m_matrix[0] = UnityPatch_g_psParamSH_m_matrix_0;
	g_psParamSH.m_matrix[1] = UnityPatch_g_psParamSH_m_matrix_1;
	g_psParamSH.m_matrix[2] = UnityPatch_g_psParamSH_m_matrix_2;
	g_psParamSH.m_matrix[3] = UnityPatch_g_psParamSH_m_matrix_3;
	g_psParamSHSky.m_matrix[0] = UnityPatch_g_psParamSHSky_m_matrix_0;
	g_psParamSHSky.m_matrix[1] = UnityPatch_g_psParamSHSky_m_matrix_1;
	g_psParamSHSky.m_matrix[2] = UnityPatch_g_psParamSHSky_m_matrix_2;
#elif defined(UNITYPATCH_WORK_TYPE_SHLIGHT)
	g_psLightSH.m_projectionPlanes[0] = UnityPatch_g_psLightSH_m_projectionPlanes_0;
	g_psLightSH.m_projectionPlanes[1] = UnityPatch_g_psLightSH_m_projectionPlanes_1;
	g_psLightSH.m_projectionPlanes[2] = UnityPatch_g_psLightSH_m_projectionPlanes_2;
#elif defined(UNITYPATCH_WORK_TYPE_VECTORS)
	g_psWork.m_vectors = UnityPatch_g_sWork_m_vectors;
#else
#endif

#endif
}