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
