using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider masterVolume;
    public Slider musicVolume;
    public Slider sfxVolume;
    public Slider playerVolume;
    public Slider uiVolume;

    private Bus masterBus;
    private Bus musicBus;
    private Bus sfxBus;
    private Bus playerBus;
    private Bus uiBus;

    private bool paused = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.masterBus = RuntimeManager.GetBus("bus:/");
        this.musicBus = RuntimeManager.GetBus("bus:/Music");
        this.sfxBus = RuntimeManager.GetBus("bus:/SFX");
        this.playerBus = RuntimeManager.GetBus("bus:/Player");
        this.uiBus = RuntimeManager.GetBus("bus:/UI");

        this.uiBus.setVolume(0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (paused) return;

        this.masterBus.setVolume(masterVolume.value);
        this.musicBus.setVolume(musicVolume.value);
        this.sfxBus.setVolume(sfxVolume.value);
        this.playerBus.setVolume(playerVolume.value);

        this.uiBus.setVolume(0f);
    }

    public void PauseAll()
    {
        this.masterBus.setVolume(0f);
        this.musicBus.setVolume(0f);
        this.sfxBus.setVolume(0f);
        this.playerBus.setVolume(0f);

        this.uiBus.setVolume(uiVolume.value);

        paused = true;
    }

    public void Unpause()
    {
        paused = false;
    }
}
