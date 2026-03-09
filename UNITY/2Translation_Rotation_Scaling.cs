
using UnityEngine;
public class TransformController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;
    public float scaleSpeed = 1f;

    void Update()
    {
        // Translation
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(moveX, moveY, 0);

        // Rotation
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }

        // Scaling
        if (Input.GetKey(KeyCode.Z))
        {
            transform.localScale += Vector3.one * scaleSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.X))
        {
            transform.localScale -= Vector3.one * scaleSpeed * Time.deltaTime;
            // Ensure the scale does not go below zero
            transform.localScale = new Vector3(
                Mathf.Max(transform.localScale.x, 0.1f),
                Mathf.Max(transform.localScale.y, 0.1f),
                1);
        }
    }
}

#new 
public class TransformController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;
    public float scaleSpeed = 1f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Translation
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + new Vector2(moveX, moveY));

        // Rotation
        if (Input.GetKey(KeyCode.Q))
        {
            rb.MoveRotation(rb.rotation + rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            rb.MoveRotation(rb.rotation - rotationSpeed * Time.deltaTime);
        }

        // Scaling
        if (Input.GetKey(KeyCode.Z))
        {
            transform.localScale += Vector3.one * scaleSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.X))
        {
            transform.localScale -= Vector3.one * scaleSpeed * Time.deltaTime;
            // Ensure the scale does not go below zero
            transform.localScale = new Vector3(
                Mathf.Max(transform.localScale.x, 0.1f),
                Mathf.Max(transform.localScale.y, 0.1f),
                1);
        }
    }
}