using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public GameObject doorFragA, doorFragB;
    public BoxCollider collision;

    private bool triggered;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown("'")) Trigger();*/

        if (!triggered) return;

        doorFragA.transform.rotation *= Quaternion.Euler(0f, Time.deltaTime * 90, 0);
        doorFragB.transform.rotation *= Quaternion.Euler(0f, -Time.deltaTime * 90, 0);
    }

    public void Trigger()
    {
        triggered = true;

        Destroy(collision);
    }
}
