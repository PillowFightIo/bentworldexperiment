#ifndef DLS_GLOBALS_INCLUDED
#define DLS_GLOBALS_INCLUDED

float _HORIZON;
float _SPREAD;
float _ATTENUATE;
float _CURVATURE;
float4 _PLAYERWORLDPOS;

void GetGlobalCurvature_float(out float globalCurvature) { globalCurvature = _CURVATURE;  }
void GetGlobalHorizon_float(out float globalHorizon) { globalHorizon = _HORIZON; }
void GetGlobalSpread_float(out float globalSpread) { globalSpread = _SPREAD; }
void GetGlobalAttenuate_float(out float globalAttenuate) { globalAttenuate = _ATTENUATE; }
void GetGlobalPlayerWorldPos_float(out float3 globalPlayerWorldPos) { globalPlayerWorldPos = _PLAYERWORLDPOS.xyz; }
void GetGlobalAll_float(out float globalHorizon, out float globalSpread, out float globalAttenuate) {
	globalHorizon = _HORIZON;
	globalSpread = _SPREAD; 
	globalAttenuate = _ATTENUATE;
}
void DoBendZ_float(float3 objWorldPos, float3 refWorldPos, out float3 offset) {
	float3 vv = objWorldPos - refWorldPos;
	offset = float3(0.0f, (vv.z * vv.z) * -_CURVATURE, 0.0f);
}
void DoBendXZ_float(float3 objWorldPos, float3 refWorldPos, out float3 offset) {
	float3 vv = objWorldPos - refWorldPos;
	offset = float3(0.0f, ((vv.z * vv.z) + (vv.x * vv.x)) * -_CURVATURE, 0.0f);
}

#endif
