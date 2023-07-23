{
#if defined(SHADER_STAGE_VERTEX)
	// SYSTEM 0
	g_vsSystem.m_param = UnityPatch_g_sSystem_m_param; // w = alpha test threshold
	g_vsSystem.m_renderInfo = UnityPatch_g_sSystem_m_renderInfo; //float4(_ScreenParams.xy, 0, 0);
	g_vsSystem.m_renderBuffer = UnityPatch_g_sSystem_m_renderBuffer; //float4(g_vsSystem.m_renderInfo.xy, 1 / g_vsSystem.m_renderInfo.xy);
	g_vsSystem.m_dominantLightDir = UnityPatch_g_sSystem_m_dominantLightDir; //ApplyMatrixT(GetTranspose(unity_MatrixV), _WorldSpaceLightPos0);

	// SCENE 2
	g_vsScene.m_projectionView = GetTranspose(unity_MatrixVP);
	g_vsScene.m_projection = GetTranspose(glstate_matrix_projection);
	g_vsScene.m_view = GetTranspose(unity_MatrixV);
	g_vsScene.m_shadowProjection = UnityPatch_g_sScene_m_shadowProjection;
	g_vsScene.m_shadowProjection2 = UnityPatch_g_sScene_m_shadowProjection2;
	g_vsScene.m_eyepos = float4(_WorldSpaceCameraPos, 1);
	g_vsScene.m_projectionParam = UnityPatch_g_sScene_m_projectionParam;
	g_vsScene.m_viewportSize = float4(_ScreenParams.xy, _ProjectionParams.yz);
	g_vsScene.m_exposure = UnityPatch_g_sScene_m_exposure;
	g_vsScene.m_fogParam = UnityPatch_g_sScene_m_fogParam;
	g_vsScene.m_fogColor = UnityPatch_g_sScene_m_fogColor;
	g_vsScene.m_cameraCenterOffset = UnityPatch_g_sScene_m_cameraCenterOffset;
	g_vsScene.m_shadowMapResolutions = UnityPatch_g_sScene_m_shadowMapResolutions;

	// RENDERBUFFER 1

	// LIGHTS 3
	g_vsLight.m_lightParams = UnityPatch_g_sLights_m_lightParams;

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
	g_vsObject.m_viewWorld = mul(GetTranspose(unity_ObjectToWorld), GetTranspose(unity_MatrixV));
	g_vsObject.m_world = GetTranspose(unity_ObjectToWorld);
	g_vsObject.m_useWeightCount = float4(UnityPatch_g_sObject_m_useWeightCount.x, 0, 0, unity_LODFade.x > 0 ? unity_LODFade.x : 1 + unity_LODFade.x);
	g_vsObject.m_localParam = UnityPatch_g_sObject_m_localParam;

	// BONE 6

	// WORK 7
	g_vsWork.m_viewInverse = GetTranspose(unity_MatrixInvV);
	g_vsWork.m_matrix = UnityPatch_g_sWork_m_matrix;
#endif
		
#if defined(SHADER_STAGE_FRAGMENT)
	// SYSTEM 0
	g_psSystem.m_param = UnityPatch_g_sSystem_m_param; // w = alpha test threshold
	g_psSystem.m_renderInfo = UnityPatch_g_sSystem_m_renderInfo; //float4(_ScreenParams.xy, 0, 0);
	g_psSystem.m_renderBuffer = UnityPatch_g_sSystem_m_renderBuffer; //float4(g_psSystem.m_renderInfo.xy, 1 / g_psSystem.m_renderInfo.xy);
	g_psSystem.m_dominantLightDir = UnityPatch_g_sSystem_m_dominantLightDir; //ApplyMatrixT(GetTranspose(unity_MatrixV), _WorldSpaceLightPos0);

	// SCENE 2
	g_psScene.m_projectionView = GetTranspose(unity_MatrixVP);
	g_psScene.m_projection = GetTranspose(glstate_matrix_projection);
	g_psScene.m_view = GetTranspose(unity_MatrixV);
	g_psScene.m_shadowProjection = UnityPatch_g_sScene_m_shadowProjection;
	g_psScene.m_shadowProjection2 = UnityPatch_g_sScene_m_shadowProjection2;
	g_psScene.m_eyepos = float4(_WorldSpaceCameraPos, 1);
	g_psScene.m_projectionParam = UnityPatch_g_sScene_m_projectionParam;
	g_psScene.m_viewportSize = float4(_ScreenParams.xy, _ProjectionParams.yz);
	g_psScene.m_exposure = UnityPatch_g_sScene_m_exposure;
	g_psScene.m_fogParam = UnityPatch_g_sScene_m_fogParam;
	g_psScene.m_fogColor = UnityPatch_g_sScene_m_fogColor;
	g_psScene.m_cameraCenterOffset = UnityPatch_g_sScene_m_cameraCenterOffset;
	g_psScene.m_shadowMapResolutions = UnityPatch_g_sScene_m_shadowMapResolutions;

	// RENDERBUFFER 1

	// LIGHTS 3
	g_psLight.m_lightParams = UnityPatch_g_sLights_m_lightParams;

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
	g_psObject.m_viewWorld = mul(GetTranspose(unity_ObjectToWorld), GetTranspose(unity_MatrixV));
	g_psObject.m_world = GetTranspose(unity_ObjectToWorld);
	g_psObject.m_useWeightCount = float4(UnityPatch_g_sObject_m_useWeightCount.x, 0, 0, unity_LODFade.x > 0 ? unity_LODFade.x : 1 + unity_LODFade.x);
	g_psObject.m_localParam = UnityPatch_g_sObject_m_localParam;

	// BONE 6

	// WORK 7
	g_psWork.m_vectors = UnityPatch_g_sWork_m_vectors;
#endif
}