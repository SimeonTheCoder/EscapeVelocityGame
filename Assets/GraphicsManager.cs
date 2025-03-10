using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;

public class GraphicsManager : MonoBehaviour
{
    public VolumeProfile volumeProfile;

    public Toggle toggle;

    // References to Ray Tracing settings
    private ScreenSpaceAmbientOcclusion rayTracingAO;
    private ScreenSpaceReflection rayTracingSSR;
    private GlobalIllumination rayTracingSSGI;

    private bool enabled;

    void Start()
    {
        volumeProfile.TryGet(out rayTracingAO);
        volumeProfile.TryGet(out rayTracingSSR);
        volumeProfile.TryGet(out rayTracingSSGI);

        bool rt = (PlayerPrefs.GetInt("RT") == 1);

        SetRaytracing(rt);
        this.toggle.isOn = rt;
    }

    public void Enable()
    {
        this.enabled = true;
        SetRaytracing(this.enabled);
    }

    public void Disable()
    {
        this.enabled = false;
        SetRaytracing(this.enabled);
    }

    public void SetEnabled(bool value)
    {
        this.enabled = value;
        SetRaytracing(this.enabled);
    }

    public void Toggle()
    {
        SetEnabled(toggle.isOn);
        PlayerPrefs.SetInt("RT", toggle.isOn ? 1 : 0);
    }

    public void SetRaytracing(bool enableRaytracing)
    {
        // Enable or disable Raytracing AO
        if (rayTracingAO != null)
        {
            rayTracingAO.active = enableRaytracing;
        }

        // Enable or disable Raytracing SSR
        if (rayTracingSSR != null)
        {
            rayTracingSSR.active = enableRaytracing;
        }

        // Enable or disable Raytracing SSGI
        if (rayTracingSSGI != null)
        {
            rayTracingSSGI.active = enableRaytracing;
        }
    }
}