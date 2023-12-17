using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class HitFeedback : MonoBehaviour
{
    [SerializeField]
    private Volume globalVolume;

    [SerializeField]
    private float shadowTimer;

    private float maxShadowTimer = 1.5f;

    public bool callVignette;

    void Update()
    {
        if(callVignette)
        {
            Vignette();
            shadowTimer += Time.deltaTime;
            if(shadowTimer >= maxShadowTimer)
            {
                shadowTimer = 0;
            }            
        }
    }

    public void Vignette()
    {
        Vignette vignette;
        if (globalVolume.profile.TryGet(out vignette))
        {
            Debug.Log("Vignette Working");
            float rateShadowTime = Mathf.Clamp01(shadowTimer/ maxShadowTimer);    
            vignette.intensity.value = Mathf.Lerp(0, 0.35f, rateShadowTime);
        }

    }
}
