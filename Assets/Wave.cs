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
            0f, Mathf.Sin(time * 4f), 0f
        ) / 2f;

        this.transform.rotation *= Quaternion.Euler(0f, Time.deltaTime * 360 / 2f, 0f);
    }
}
