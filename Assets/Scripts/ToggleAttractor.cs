using UnityEngine;

public class ToggleAttractor : MonoBehaviour, IPuzzleElement
{
    public int massA, massB;

    private GravityAttractor attractor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.attractor = GetComponent<GravityAttractor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void On()
    {
        this.attractor.mass = massB;
    }

    public void Off()
    {
        this.attractor.mass = massA;
    }
}
