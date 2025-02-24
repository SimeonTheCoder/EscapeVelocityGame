using UnityEngine;

public class TriggerActivate : MonoBehaviour
{
    public int targetTag;

    private PuzzleManager puzzleManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.puzzleManager = GameObject.Find("PuzzleManager").GetComponent<PuzzleManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        this.puzzleManager.SetTag(targetTag, true);
    }

    public void OnTriggerExit(Collider other)
    {
        this.puzzleManager.SetTag(targetTag, false);
    }
}
