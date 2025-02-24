using UnityEngine;

public class DistanceActivate : MonoBehaviour
{
    public int targetTag;
    public float distanceThreshold;

    private PuzzleManager puzzleManager;

    private bool on;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.puzzleManager = GameObject.Find("PuzzleManager").GetComponent<PuzzleManager>();
        this.on = false;
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

        this.on = !this.on;
        puzzleManager.SetTag(targetTag, this.on);
    }
}
