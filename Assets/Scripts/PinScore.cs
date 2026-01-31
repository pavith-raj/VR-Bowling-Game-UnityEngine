using UnityEngine;

public class PinScore : MonoBehaviour
{
    public bool counted=false;

    [Header("Fall Detection")]
    public float fallAngle = 40f;      
    public float fallTime = 0.6f;

    private float timer = 0f;
    private Quaternion startRotation;

    [Header("Sliding Detection")]
    public float slideCollisionTime = 0.5f;

    private float collisionTimer = 0f;
    private bool isColliding = false;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startRotation = transform.rotation;
    }

    void FixedUpdate()
    {
        if (counted) return;

        float angle = Quaternion.Angle(transform.rotation, startRotation);
        
        //if pin is rotated
        if (angle > fallAngle)
        {
            if (rb.linearVelocity.magnitude < 0.2f)
                timer += Time.fixedDeltaTime;

            if (timer >= fallTime)
            {
                counted = true;
                collisionTimer = 0f;
                ScoreManager.Instance.AddPoint();
                Destroy(gameObject, 2f);
            }
        }
        else
        {
            timer = 0f; 
        }

        //if pin Sliding wall
        if (!counted && isColliding)
        {
            collisionTimer += Time.fixedDeltaTime;

            if (collisionTimer >= slideCollisionTime)
            {
                counted = true;
                ScoreManager.Instance.AddPoint();
                Destroy(gameObject, 2f);
                return;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isColliding = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isColliding = false;
            collisionTimer = 0f;
        }
    }
}
