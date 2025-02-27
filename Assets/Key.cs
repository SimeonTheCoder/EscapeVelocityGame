using UnityEngine;

public class Key : MonoBehaviour
{
    public string keyValue;

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

        Debug.Log($"{keyValue} acquired!");

        Destroy(this.gameObject);
    }
}
