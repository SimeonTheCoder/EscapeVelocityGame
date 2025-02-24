using UnityEngine;

public class SpawnField : MonoBehaviour
{
    public GameObject probe;
    public float launchForce;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            for(int i = -100; i < 100; i += 10)
            {
                for(int j = 0; j < 30; j += 10)
                {
                    for(int k = -100; k < 100; k += 10)
                    {
                        GameObject copy = Instantiate(probe);

                        Vector3 offset = new Vector3(i, j, k);

                        copy.transform.position = transform.position + offset;

                        //copy.GetComponent<Rigidbody>().AddForce(transform.forward * launchForce);
                    }
                }
            }
        }
    }
}
