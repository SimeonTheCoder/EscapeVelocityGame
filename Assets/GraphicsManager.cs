using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;

public class GraphicsManager : MonoBehaviour
{
    public VolumeProfile volumeProfile;

    public Toggle toggle;
    public Toggle lensFlareToggle;
    public Toggle volumetricsToggle;

    // References to Ray Tracing settings
    private ScreenSpaceAmbientOcclusion rayTracingAO;
    private ScreenSpaceReflection rayTracingSSR;
    private GlobalIllumination rayTracingSSGI;

    private ScreenSpaceLensFlare lensFlareEffect;
    private Bloom lensBloom;

    private Fog fog;

    private bool enabled;

    void Start()
    {
        volumeProfile.TryGet(out rayTracingAO);
        volumeProfile.TryGet(out rayTracingSSR);
        volumeProfile.TryGet(out rayTracingSSGI);

        volumeProfile.TryGet(out lensFlareEffect);
        volumeProfile.TryGet(out lensBloom);

        volumeProfile.TryGet(out fog);

        bool rt = (PlayerPrefs.GetInt("RT") == 1);
        bool volumetrics = (PlayerPrefs.GetInt("Godrays") == 1);
        bool lensFlares = (PlayerPrefs.GetInt("LensFlare") == 1);

        SetRaytracing(rt);
        SetVolumetrics(rt);
        SetLensFlares(rt);

        this.toggle.isOn = rt;
        this.lensFlareToggle.isOn = lensFlares;
        this.volumetricsToggle.isOn = volumetrics;
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

    public void ToggleVolume()
    {
        SetVolumetrics(volumetricsToggle.isOn);
        PlayerPrefs.SetInt("Godrays", volumetricsToggle.isOn ? 1 : 0);
    }

    public void ToggleLens()
    {
        SetLensFlares(lensFlareToggle.isOn);
        PlayerPrefs.SetInt("LensFlare", lensFlareToggle.isOn ? 1 : 0);
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

    public void SetLensFlares(bool enableLensFlare)
    {
        if (lensFlareEffect == null || lensBloom == null) return;
        lensFlareEffect.active = enableLensFlare;
        lensBloom.active = enableLensFlare;
    }

    public void SetVolumetrics(bool enableVolume)
    {
        if (fog == null) return;
        fog.active = enableVolume;
    }
}