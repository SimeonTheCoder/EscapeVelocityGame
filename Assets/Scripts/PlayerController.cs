using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject camera;

    public float acceleration;

    public float jumpStrength;

    public float bobbingStrength;
    public float bobbingFrequency;

    private bool onSurface;
    private bool onWall;

    private const float BackMovementFactor = 0.625f;
    private const float SidewaysMovementFactor = 0.75f;

    private const float AirFriction = 0.1f;

    private float time;

    private Vector3 prevMovementDir;

    private float materialFriction;

    private float velocity;

    private string tag = "";


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        this.time = 0f;

        this.onSurface = true;
        tag = "Floor";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float tick = Time.fixedDeltaTime;
        float friction = this.onSurface ? this.materialFriction : AirFriction;
        float controlCoefficient = friction;

        float mass = this.GetComponent<Rigidbody>().mass;
        float g = Physics.gravity.magnitude;
        float weight = mass * g;

        float accelerationWithFriction = acceleration + 1 - Mathf.Exp(this.velocity / 2f) - friction * g;
        this.velocity += tick * accelerationWithFriction * controlCoefficient;

        transform.rotation *= Quaternion.Euler(0f, Input.GetAxis("Mouse X"), 0f);
        camera.transform.rotation *= Quaternion.Euler(-Input.GetAxis("Mouse Y") + Mathf.Sin(time * bobbingFrequency) * bobbingStrength * this.velocity, 0f, Mathf.Cos(time * bobbingFrequency * 1.618f) * bobbingStrength * this.velocity);

        float vAxis = Input.GetAxis("Vertical");
        float hAxis = Input.GetAxis("Horizontal");

        vAxis = ( vAxis > 0f ? vAxis : vAxis * BackMovementFactor ) ;

        if (vAxis == 0f && hAxis == 0f) this.velocity -= tick * friction * g;
        this.velocity = Mathf.Max(0, this.velocity);

        Vector3 movementDir = (transform.forward * vAxis + transform.right * SidewaysMovementFactor * hAxis) * tick;
        movementDir = (movementDir != Vector3.zero && movementDir.magnitude > 1f ? movementDir.normalized : movementDir);

        Vector3 deltaPos = ( Vector3.Lerp ( prevMovementDir, movementDir, controlCoefficient ) * this.velocity ) ;
        transform.position += deltaPos;

        if (vAxis == 0f && hAxis == 0f && deltaPos.magnitude < 0.02f) this.velocity = 0f;

        this.prevMovementDir = Vector3.Lerp ( prevMovementDir, movementDir, controlCoefficient );
    }

    void Update()
    {
        time += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && this.onSurface)
        {
            if (!this.onWall)
            {
                GetComponent<Rigidbody>().AddForce(transform.up * jumpStrength);
            }
            else
            {
                GetComponent<Rigidbody>().AddForce((transform.forward + transform.up * 1.3f) * jumpStrength * 1.5f);
            }

            this.onSurface = false;
        }

        if (Input.GetKey(KeyCode.LeftControl)) transform.localScale = new Vector3(0.6f, 0.45f, 0.6f);
        else transform.localScale = new Vector3(0.6f, 0.9f, 0.6f);

        //StickToGround();
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.materialFriction = collision.collider.material.dynamicFriction;
        this.onSurface = true;

        this.tag = collision.collider.tag;
    }

    void StickToGround()
    {
        onWall = true;
        if (tag == "Wall") return;
        onWall = false;

        if (Physics.Raycast(transform.position, -camera.transform.up, out RaycastHit hit, 10f))
        {
            Vector3 groundNormal = hit.normal;

            Quaternion targetRotation = Quaternion.FromToRotation(transform.up, groundNormal) * transform.rotation;

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }
}
