using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraPostProEffects : MonoBehaviour {

    [Header("PostPro Settings Normal")]
    public PostProcessVolume postProNormal;
    public float normalPostWeightNormal;
    public float normalPostWeightDreamworld;
    public float normalPostWeightFear;
    public float normalPostChangeTime;
    [Header("PostPro Settings Dreamworld")]
    public PostProcessVolume postProDreamworld;
    public float dreamworldPostWeightNormal;
    public float dreamworldPostWeightDreamworld;
    public float dreamworldPostWeightFear;
    public float dreamworldPostChangeTime;
    [Header("PostPro Settings Fear")]
    public PostProcessVolume postProFear;
    public float fearPostWeightNormal;
    public float fearPostWeightDreamworld;
    public float fearPostWeightFear;
    public float fearPostChangeTime;

    private float currentNormalWeight;
    private float currentDreamworldWeight;
    private float currentFearWeight;

    public void ChangeToNormalState()
    {
        LeanTween.value(gameObject, UpdateNormal,       postProNormal.weight,       normalPostWeightNormal,     normalPostChangeTime).setEaseInOutQuad();
        LeanTween.value(gameObject, UpdateDreamworld,   postProDreamworld.weight,   normalPostWeightDreamworld, normalPostChangeTime).setEaseInOutQuad();
        LeanTween.value(gameObject, UpdateFear,         postProFear.weight,         normalPostWeightFear,       normalPostChangeTime).setEaseInOutQuad();
    }
    
    public void ChangeToDreamworldState()
    {
        Debug.Log("Dreamworld Raised");
        LeanTween.value(gameObject, UpdateNormal,       postProNormal.weight,       dreamworldPostWeightNormal,     dreamworldPostChangeTime).setEaseInOutQuad();
        LeanTween.value(gameObject, UpdateDreamworld,   postProDreamworld.weight,   dreamworldPostWeightDreamworld, dreamworldPostChangeTime).setEaseInOutQuad();
        LeanTween.value(gameObject, UpdateFear,         postProFear.weight,         dreamworldPostWeightFear,       dreamworldPostChangeTime).setEaseInOutQuad();
    }

    public void ChangeToFearState()
    {
        Debug.Log("Event Raised");
        LeanTween.value(gameObject, UpdateNormal,       postProNormal.weight,       fearPostWeightNormal,       fearPostChangeTime).setEaseInOutQuad();
        LeanTween.value(gameObject, UpdateDreamworld,   postProDreamworld.weight,   fearPostWeightDreamworld,   fearPostChangeTime).setEaseInOutQuad();
        LeanTween.value(gameObject, UpdateFear,         postProFear.weight,         fearPostWeightFear,         fearPostChangeTime).setEaseInOutQuad();
    }

    private void UpdateNormal(float value)
    {
        postProNormal.weight = value;
    }
    
    private void UpdateDreamworld(float value)
    {
        postProDreamworld.weight = value;
    }
    
    private void UpdateFear(float value)
    {
        postProFear.weight = value;
    }
}
