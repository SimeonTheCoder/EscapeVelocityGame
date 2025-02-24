using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public bool[] tags;
    public int tagCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.tags = new bool[tagCount];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTag (int tagId, bool value)
    {
        this.tags[tagId] = value;
    }

    public bool GetTagValue (int tagId)
    {
        return this.tags[tagId];
    }
}
