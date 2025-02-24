using UnityEngine;

public class PuzzleElement : MonoBehaviour
{
    public int listenTag;

    private PuzzleManager puzzleManager;
    private IPuzzleElement puzzleElement;

    private int time;

    private bool on = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.puzzleManager = GameObject.Find("PuzzleManager").GetComponent<PuzzleManager>();
        this.puzzleElement = this.gameObject.GetComponent<IPuzzleElement>();
    }

    // Update is called once per frame
    void Update()
    {
        time += 1;

        if (time % 10 != 0) return;

        if (puzzleManager.GetTagValue(listenTag))
        {
            this.puzzleElement.On();
            this.on = true;
        }
        else if (this.on)
        {
            this.puzzleElement.Off();
            this.on = false;
        }
    }
}
