using FMODUnity;
using UnityEngine;

public class Key : MonoBehaviour
{
    public string keyValue;
    public ParticleSystem particles;
    public StudioEventEmitter keyPickUpSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<KeyHolder>().AddKey(keyValue);

        particles.gameObject.transform.parent = null;
        particles.Play();

        keyPickUpSound.Play();

        Debug.Log($"{keyValue} acquired!");

        Destroy(this.gameObject);
    }
}
