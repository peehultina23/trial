Create a 3D project > add 3D object > plane > rename it : ground 
In inspector window :> Transform 
Ground coordinates (Scale) : X : 2.93 Y : 1.07 Z : 6.63 

In the project console down > go to “Scenes”, which is below assets, in scenes > right click > create  > material 
It will create a ball, give it any colour and drag the ball into the scene, the ground will become that colour 

Create 3 GameObjects : 

Cube = Goal 
Capsule = Player 
Capsule = Enemy 

To change the colour of the game objects , same process : scenes > right click > create > material 
Create three materials for 3 game objects and drag and drop the colour into them respectively 

Goal Coordinates : 
Position : X : 10 Y: 0.5 Z : 0
Rotation : X : 0 Y: 0 Z: 0 
Scale : X : 3.09 Y : 4.08 Z : 4.81

Player Coordinates : 
Position : X : 1.67 Y : 1 Z : -6.4 
Rotation : X : 0 Y : 0 Z : 0
Scale : X : 0.41 Y : 0.5 Z : 0.05 

Enemy Coordinates : 
Position : X : -7.36 Y : 1  Z : 0
Rotation : 0 0 0 
Scale : X : -0.56 Y : 0.85 Z : 1


Then in Goal > Component > Physics > Sphere collider (IsTrigger : Check)

In Enemy > Component > Add > Nav Mesh Agent

In Player > Physics > Rigidbody 
In Rigidbody > Constraints > Freeze Rotation > Check x,y,z

In Hierarchy >Component > create empty  > in inspector > add component > select nav mesh surface > click on bake 

In Hierarchy > create empty > GameObject 

In Assets folder > create script > PlayerScript : 

using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0, v) * speed;
        // Updates velocity while preserving gravity (y-axis)
        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);
    }
}


Bind this script to Player Object ^ 

Create a another script AI_Player : 

using UnityEngine;
using UnityEngine.AI;

public class AI_Player : MonoBehaviour
{
    public Transform target;
    public float speed = 3.5f;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }
}
Bind this script to Enemy ^ 

Create another Script, GameManager : 

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject ai;
    public GameObject goal;

    void Update()
    {
        float playerDistance = Vector3.Distance(player.transform.position, goal.transform.position);
        float aiDistance = Vector3.Distance(ai.transform.position, goal.transform.position);

        if (playerDistance < 1.0f)
        {
            Debug.Log("Player Wins!");
            QuitGame();
        }
        else if (aiDistance < 1.0f)
        {
            Debug.Log("AI! Wins");
            QuitGame();
        }
    }

    void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
Bind this to the empty GameObject we made ^ 

Now in GameObject > Inspector : 
Drag and drop Player,Enemy and Goal respectively 

Create a new script in assets > Goal :

using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Playerhed the goal!");
            Time.timeScale = 0; // Pause the game
        }
        else if (other.CompareTag("Enemy"))
        {
            Debug.Log("AIhed the goal!");
            Time.timeScale = 0; // Pause the game
        }
    }
}

Bind it to Goal Object ^ 

In Hierarchy > Enemy > Inspector > Tag > Add Tag : Enemy > and tag it 

In Enemy > Scroll down > Set Target : (Drag and drop Goal from hierarchy into it) 

In Enemy > add rigid body > Constraints : freeze rotation : (Check x,y,z)

In player > inspector > tag : player
//Player.cs
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0, v) * speed;
        // Updates velocity while preserving gravity (y-axis)
        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);
    }
}

//Enemy.cs/AI_Player.cs
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float speed = 3.5f;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }
}

//Goal.cs
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player reached the goal!");
            Time.timeScale = 0; // Pause the game
        }
        else if (other.CompareTag("Enemy"))
        {
            Debug.Log("AI reached the goal!");
            Time.timeScale = 0; // Pause the game
        }
    }
}


//GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject ai;
    public GameObject goal;

    void Update()
    {
        float playerDistance = Vector3.Distance(player.transform.position, goal.transform.position);
        float aiDistance = Vector3.Distance(ai.transform.position, goal.transform.position);

        if (playerDistance < 1.0f)
        {
            Debug.Log("Player wins!");
            QuitGame();
        }
        else if (aiDistance < 1.0f)
        {
            Debug.Log("AI wins!");
            QuitGame();
        }
    }

    void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

#Steps to create the game:
1. Create a new Unity project.
2. Create a plane for the ground and a cube for the goal.
3. Create a capsule for the player and a sphere for the AI.
4. Add the Player script to the capsule and the Enemy script to the sphere.
5. Add the Goal script to the cube.
6. Create an empty GameObject and add the GameManager script to it. Assign the player, AI, and goal objects to the respective fields in the GameManager script.
7. Bake the NavMesh for the ground plane to allow the AI to navigate.
#Run the game and use the arrow keys to move the player towards the goal while the AI chases it. The first to reach the goal wins!

#coordinates of the objects in the scene:
Player (Capsule): (0, 0.5, 0)
AI (Sphere): (-5, 0.5, -5)
Goal (Cube): (5, 0.5, 5)


#inspector settings:
Player:
- Tag: Player
- Rigidbody: Use Gravity (checked), Is Kinematic (unchecked)
- Collider: Box Collider (default for capsule)
- Player script: Speed (5)

AI: 
- Tag: Enemy
- NavMeshAgent: Speed (3.5)
- Collider: Sphere Collider (default for sphere)
- Enemy script: Target (Player)
- Goal script: Goal (Cube)
- Collider: Box Collider (default for cube)


Goal: 
- Tag: Goal
- Collider: Box Collider (default for cube)
- Goal script: Goal (Cube)
- Rigidbody: Is Trigger (checked)

#anything else:
- Make sure to have a NavMesh baked for the ground plane to allow the AI to navigate towards the player.
