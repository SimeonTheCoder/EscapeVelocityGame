using UnityEngine;

public class Wave : MonoBehaviour
{
    private Vector3 initial;

    private float time;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.time = 0f;

        this.initial = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.time += Time.deltaTime;

        this.transform.position = this.initial + new Vector3
        (
            0f, Mathf.Sin(time), 0f
        );
    }
}
