using FMODUnity;
using UnityEngine;

public class TransitionState : MonoBehaviour
{
    public StudioEventEmitter switchSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Prop")
        {
            Debug.Log("NOW A PROP!!!!");
            switchSound.Play();
            other.gameObject.tag = "Prop";
        }
        /*else other.gameObject.tag = "Untagged";*/
    }
}
