using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [Header("Settings")]
    public float moveForce = 10000f;
    public float maxSpeed = 3f;

    private Rigidbody rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 inputDirection = Vector3.zero;

        //1. check input using KeyCode
        if (Input.GetKey(KeyCode.W)) inputDirection.z = 1;
        if (Input.GetKey(KeyCode.S)) inputDirection.z = -1;
        if (Input.GetKey(KeyCode.A)) inputDirection.x = -1;
        if (Input.GetKey(KeyCode.D)) inputDirection.x = 1;

        print("current input direction: " + inputDirection);

        //2. apply force
        rb.AddForce(inputDirection.normalized * moveForce * Time.fixedDeltaTime);

        //3. apply limitation of speed
        if(rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }
}
