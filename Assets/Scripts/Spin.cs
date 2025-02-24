using UnityEngine;

public class Spin : MonoBehaviour
{
    public Vector3 axis;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.rotation *= Quaternion.Euler(1f/14f * axis);
    }
}
