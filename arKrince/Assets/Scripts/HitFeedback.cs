using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class HitFeedback : MonoBehaviour
{
    [SerializeField]
    private Volume globalVolume;

    [SerializeField]
    private float shadowTimer;

    public float maxShadowTimer = 1.5f;
    public float maxIntensity;
    public bool callVignette;

    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            callVignette = false;
            shadowTimer = 0;
            return;
        }

        Vignette();
        
        if(callVignette)
        {
            if(shadowTimer <= maxShadowTimer)
            {
                shadowTimer += Time.deltaTime;
            }
        }
        else
        {
            if(shadowTimer <= 0)
            {
                shadowTimer = 0;
            }
            else
            {
                shadowTimer -= Time.deltaTime;
            }
        }
    }

    public void Vignette()
    {
        Vignette vignette;
        if (globalVolume.profile.TryGet(out vignette))
        {
            float rateShadowTime = Mathf.Clamp01(shadowTimer/ maxShadowTimer);    
            vignette.intensity.value = Mathf.Lerp(0, maxIntensity, rateShadowTime);
        }
    }
}
