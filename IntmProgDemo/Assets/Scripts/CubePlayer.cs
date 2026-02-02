using UnityEngine;

public class CubePlayer : MonoBehaviour
{

    public enum MovingPatterns { Straight, Lerp, Teleport, EaseIn, EaseInAndOut }
    [SerializeField]
    private MovingPatterns movingPattern = MovingPatterns.Straight;

    [SerializeField]
    private GameManager gameManager;

    private Vector3 currentTarget;
    private Vector3 startPos;
    private float movementTimer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTarget = Vector3.up * 0.5f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin")){
            Destroy(collision.gameObject);
            gameManager.score++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Default moving direction
        Vector3 targetDistance = currentTarget - transform.position;
        targetDistance.y = 0;
        Vector3 moveDirection = targetDistance.normalized;

        Vector3 newPos = Vector3.zero;

        //teleportation
        if (movingPattern == MovingPatterns.Teleport)
        {
            newPos = currentTarget;
        }

        //fixed straight movement
        else if (movingPattern == MovingPatterns.Straight)
        {
            Vector3 moveVector = moveDirection * 10f * Time.deltaTime;
            if (moveVector.sqrMagnitude > targetDistance.sqrMagnitude)
            {
                //reached target
                newPos = currentTarget;
            }
            else
            {
                //keep moving 
                newPos = transform.position + moveVector;
            }
        }

        //lerp movement
        else if (movingPattern == MovingPatterns.Lerp)
        {
            newPos = Vector3.Lerp(transform.position, currentTarget, 2f * Time.deltaTime);
        }

        //ease in - from easings.net
        else if (movingPattern == MovingPatterns.EaseIn)
        {
            movementTimer = Mathf.Min(1, movementTimer + Time.deltaTime);
            newPos = startPos + (currentTarget - startPos) * (1 - Mathf.Cos((movementTimer * Mathf.PI) / 2));
        }

        //ease in and out - from easings.net
        else if (movingPattern == MovingPatterns.EaseIn)
        {
            movementTimer = Mathf.Min(1, movementTimer + Time.deltaTime);
            newPos = startPos + (currentTarget - startPos) * (Mathf.Cos(Mathf.PI * movementTimer) - 1) / 2;
        }

        transform.position = newPos;
        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection, Vector3.up);
        }
    }

    public void MoveTo(Vector3 newTarget)
    {
        startPos = transform.position;
        currentTarget = newTarget + Vector3.up * 0.5f;

        //for ease movement mode
        movementTimer = 0;
    }
}
