using FMODUnity;
using UnityEngine;

public class AnimateCushion : MonoBehaviour
{
    public GameObject cushion;

    private Vector3 scaleA;
    private Vector3 scaleB;

    private float timerSpeed;

    private float time;

    public StudioEventEmitter fall;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scaleA = new Vector3(
            cushion.transform.localScale.x,
            cushion.transform.localScale.y,
            cushion.transform.localScale.z
        );

        scaleB = new Vector3(
            cushion.transform.localScale.x,
            cushion.transform.localScale.y * 0.4f,
            cushion.transform.localScale.z
        );
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * timerSpeed;

        time = Mathf.Min(1, time);
        time = Mathf.Max(0, time);

        if (timerSpeed < 0)
        {
            cushion.transform.localScale = Vector3.Lerp(scaleA, scaleB, Mathf.Pow(time, 2));
        }
        else
        {
            cushion.transform.localScale = Vector3.Lerp(scaleA, scaleB, 1f - Mathf.Pow(1f - time, 2));
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        timerSpeed = 3f;
        fall.Play();
    }

    public void OnTriggerExit(Collider other)
    {
        timerSpeed = -1f;
    }
}
