#Implement physical characteristics(jump) to an object and also bind surface effector steps (also rigid body2d) to it in Unity

using UnityEngine;
public class jump : MonoBehaviour
{
public float jumpForce = 4f;
private Rigidbody2D rb;
void Start()
{
rb = GetComponent<Rigidbody2D>();
}
void Update()
{
if(Input.GetKeyDown(KeyCode.Space))
{
rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
}
}
}

#Translation + Move(forward and backward) create one more script(move) and bind with tringle object
using UnityEngine;
public class move : MonoBehaviour
{
public float moveSpeed = 5f;
public float jumpForce = 8f;
private Rigidbody2D rb;
private float moveX;
void Start()
{
rb = GetComponent<Rigidbody2D> ();
}
void Update()
{
moveX = Input.GetAxis("Horizontal");
if(Input.GetKeyDown(KeyCode.Space))
{
rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
}
}
void FixedUpdate()
{
rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);
}
}

#Create one more script for changing a colours.
using UnityEngine;
public class jumpcolor : MonoBehaviour
{
public float moveSpeed = 5f;
public float jumpForce = 8f;
private SpriteRenderer sr;
private Rigidbody2D rb;
private float moveX;
void Start()
{
rb = GetComponent<Rigidbody2D> ();
sr = GetComponent<SpriteRenderer> ();
}
void Update()
{
moveX = Input.GetAxis("Horizontal");
rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);
if(Input.GetKeyDown(KeyCode.Space))
{
rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
}
if (Mathf.Abs(rb.linearVelocity.y)>0.1f)
{
sr.color = Color.blue;
}
else if(Mathf.Abs(moveX)>0.1f)
{
sr.color = Color.red;
}
else
{
sr.color = Color.white;
}
}
}

#D. Jump + Move + Colour + Surface effector
Create a base with a subject. Then:
Component > physics 2D >; Box collider 2D
Component > physics 2D > Surface effector 2D
And bind with same script as C.





