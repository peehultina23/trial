#Area, Platform & Buoyancy Effect in unity
STEPS

#Area Effector : 

GameObject > 2D Object > Sprites > Square (create two boxes(GameObject) one big and one slightly smaller, facing each other 

Smaller Box 
From Components > Box Collider2D
From Components > Rigidbody2D(GravityScale : 0)
Add JumpMove script 
In Sprite Renderer > Additional Settings > Order in Layer : 5

Bigger Box 
BoxCollider2D : (IsTrigger : Checked, Used ByEffector : Checked)
Area Effector2D : Use collider Mask : checked 
Change the colour of the bigger box 


#Buoyancy Effector : 

GameObject > a circle, and a square long slab,right below it

Small Circle : 
RigidBody2D: GravityScale :1
BoxCollider2D 
JumpMove script

Square Slab :
Change colour
BoxCollider2D : IsTrigger : checked, Used by Effector :Checked 
Buoyancy Effector : Surface Level : 0.5, 
Damping : both should be 5

#Platform Effector :
GameObject > a circle, and a square long slab,right below it
Small Circle : 
RigidBody2D: GravityScale :1
BoxCollider2D 
JumpMove script
Square Slab :
Change colour
BoxCollider2D : IsTrigger : checked, Used by Effector :Checked 
Platform Effector : Surface Arc : 180, Use One Way : checked, Use Side Friction : checked, Side Friction : 0.5


#steps to create buoyancy effect in Unity
1. Open Unity and create a new 2D project.
2. Create a new 2D sprite (e.g., a square or circle) and add it to the scene.
3. Create a new C# script (e.g., "BuoyancyEffect") and attach it to the sprite.
4. Open the script and implement the following code to create a buoyancy effect:
jumpm.cs
using UnityEngine;

public class jumpm : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 10f;
    private Rigidbody2D rb2d;
    private float moveX;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpForce);
        }
    }
    void FixedUpdate()
    {
        rb2d.linearVelocity = new Vector2(moveX * speed, rb2d.linearVelocity.y);
    }
}
5. Save the script and return to Unity.
6. Create a new GameObject in the scene (e.g., an empty GameObject or a sprite).
7. Select the GameObject and click "Add Component" in the Inspector window. Search for "jumpm" and add it to the GameObject.
8. Press the Play button to run the scene. Use the arrow keys for horizontal movement and the spacebar to jump. The sprite will move left and right and will jump when the spacebar is pressed, simulating a buoyancy effect when it interacts with water or other surfaces.

#area effector steps
1. Follow steps 1-3 from the previous instructions to create a new 2D project, add a sprite, and create a new C# script.
2. In the Unity Editor, select the sprite and click on "Add Component" in the Inspector window. Search for "Area Effector 2D" and add it to the sprite.
3. Configure the Area Effector 2D component by adjusting its properties such as force magnitude, force variation, and force angle to achieve the desired effect (e.g., simulating wind or water currents).
4. Save the script and return to Unity.
5. Press the Play button to run the scene. Observe how the Area Effector 2D influences the movement of the sprite based on the configured properties, creating effects like buoyancy or wind resistance depending on your settings.

script for area effector
using UnityEngine;

public class jumpmove : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 10f;
    private Rigidbody2D rb2d;
    private float moveX;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpForce);
        }
    }
    void FixedUpdate()
    {
        rb2d.linearVelocity = new Vector2(moveX * speed, rb2d.linearVelocity.y);
    }
}

#platform effector steps
1. Follow steps 1-3 from the previous instructions to create a new 2D project, add a sprite, and create a new C# script.    
2. In the Unity Editor, select the sprite and click on "Add Component" in the Inspector window. Search for "Platform Effector 2D" and add it to the sprite.
3. Configure the Platform Effector 2D component by adjusting its properties such as surface arc, use one-way, and use side friction to create a platform that allows the player to jump through it from below but land on it from above.
4. Save the script and return to Unity.
5. Press the Play button to run the scene. Test the platform by jumping through it from below and landing on it from above, ensuring that the Platform Effector 2D is functioning as intended.
using UnityEngine;

public class jump : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 10f;
    private Rigidbody2D rb2d;
    private float moveX;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpForce);
        }
    }
    void FixedUpdate()
    {
        rb2d.linearVelocity = new Vector2(moveX * speed, rb2d.linearVelocity.y);
    }
}

