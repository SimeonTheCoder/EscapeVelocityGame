using UnityEngine;

public class GravityField : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (var attractor in GameObject.FindGameObjectsWithTag("GAttractor"))
        {
            foreach (var prop in GameObject.FindGameObjectsWithTag("Prop"))
            {
                float distance = Vector3.Distance(attractor.gameObject.transform.position, prop.transform.position);
                float massProduct = attractor.GetComponent<GravityAttractor>().mass * prop.GetComponent<Rigidbody>().mass;

                Vector3 dir = (attractor.gameObject.transform.position - prop.transform.position).normalized;

                Vector3 force = dir * massProduct / Mathf.Pow(distance, 2);

                prop.GetComponent<Rigidbody>().AddForce(force);
            }
        }
    }
}
