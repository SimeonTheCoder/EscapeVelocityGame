using FMODUnity;
using System;
using UnityEngine;

public class DeactivateSources : MonoBehaviour
{
    private PuzzleManager puzzleManager;

    public StudioEventEmitter cancel;
    public ParticleSystem particles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.puzzleManager = GameObject.Find("PuzzleManager").GetComponent<PuzzleManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            DeactivateWells();
            particles.Play();
            cancel.Play();
        }
    }

    void DeactivateWells()
    {
        foreach (var attractor in GameObject.FindGameObjectsWithTag("GAttractor"))
        {
            try
            {
                attractor.GetComponent<ToggleAttractor>().Off();
                puzzleManager.SetTag(attractor.GetComponent<PuzzleElement>().listenTag, false);

                Debug.Log($"Deactivated! {attractor.GetComponent<GravityAttractor>().mass}");
            }
            catch (Exception e)
            {

            }
        }
    }
}
