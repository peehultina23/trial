New 2D project > Game Object > 2D object > Sprites > Circle
Components > Physics2D > Rigidbody 2D
Go to inspector > Body type = ‘Dynamic’> Gravity scale = ‘0’
Edit > Project setting > Player > Other settings > Active input handling = ‘Both’
Add component > new script

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

#sakina code
//Rotation

using UnityEngine;
public class Rotate: MonoBehaviour
{
    public float rotationSpeed = 150f; // speed of player rotation
    void Update()
    {
        float rotateInput = Input.GetAxis("Horizontal"); 
        // A = -1, D = +1
        transform.Rotate(0, 0, rotateInput * rotationSpeed * Time.deltaTime);
    }
}

//Translation

using UnityEngine;
public class Translation: MonoBehaviour
{
    public float speed = 1f; // speed of player
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right arrows
        float moveY = Input.GetAxis("Vertical");   // W/S or Up/Down arrows
        Vector2 movement = new Vector2(moveX, moveY);
        rb2d.linearVelocity = movement * speed;
    }
}

// Scaling

using UnityEngine;
public class Scaling: MonoBehaviour
{
    public float scaleSpeed = 1f;
    public float minScale = 0.2f;
    public float maxScale = 2f;

    void Update()
    {
        float scaleInput = Input.GetAxis("Vertical");
        // Create a new scale based on input
        Vector3 newScale = transform.localScale + Vector3.one * scaleInput * scaleSpeed * Time.deltaTime;

        // Clamp X and Y scale
        newScale.x = Mathf.Clamp(newScale.x, minScale, maxScale);
        newScale.y = Mathf.Clamp(newScale.y, minScale, maxScale);

        // Force Z scale to stay 1
        newScale.z = 1f;

        // Apply the scale
        transform.localScale = newScale;
    }
}
