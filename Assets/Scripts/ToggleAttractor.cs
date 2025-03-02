using FMODUnity;
using UnityEngine;

public class ToggleAttractor : MonoBehaviour, IPuzzleElement
{
    public int massA, massB;

    public ParticleSystem particles;

    public StudioEventEmitter gravitySound;

    private GravityAttractor attractor;

    private bool playing;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.attractor = GetComponent<GravityAttractor>();
        playing = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void On()
    {
        this.attractor.mass = massB;
        particles.Play();

        if(!playing)
        {
            gravitySound.Play();
            playing = true;
        }
    }

    public void Off()
    {
        this.attractor.mass = massA;
        particles.Stop();

        if (playing)
        {
            gravitySound.Stop();
            playing = false;
        }
    }
}
