using FMODUnity;
using UnityEngine;

public class DistanceActivate : MonoBehaviour
{
    public int targetTag;
    public float distanceThreshold;

    public StudioEventEmitter clickSound;

    private PuzzleManager puzzleManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.puzzleManager = GameObject.Find("PuzzleManager").GetComponent<PuzzleManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.E)) return;

        float distance = Vector3.Distance(
            transform.position,
            GameObject.Find("Player").transform.position
        );

        if (distance > this.distanceThreshold) return;

        puzzleManager.SetTag(targetTag, !puzzleManager.GetTagValue(targetTag));

        clickSound.Play();
    }
}
