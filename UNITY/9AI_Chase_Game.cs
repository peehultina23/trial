player script
using UnityEngine;


public class Player1 : MonoBehaviour
{
    public float speed = 5f; // Speed of the player


    // Start is called once before the first execution of Update after the MonoBehaviour is created
 


    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Get horizontal input
        float moveVertical = Input.GetAxis("Vertical"); // Get vertical input
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); // Create movement vector
        transform.Translate(movement * speed * Time.deltaTime); // Move the player
    }
}

#ai script
using UnityEngine;


public class AI_chasePlayer : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 5.0f;
    private UnityEngine.AI.NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,player.position)< detectionRange)
        {
            agent.SetDestination(player.position);
            Debug.Log("AI is chasing the player");


            float playerDistance = Vector3.Distance(player.transform.position,agent.transform.position);
            Debug.Log(playerDistance);
            if(playerDistance < 0.7f)
            {
                Debug.Log("Enemy Wins!");
                StopGame();
            }
        }
        else{
                agent.ResetPath();
            }


    }
    void StopGame()
    {
        Debug.Log("Game Over! The enemy caught you.");


        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}

#Steps to create the game:
1. Create a new Unity project.
2. Create a plane for the ground and a cube for the player.
3. Create a new C# script called "Player1" and attach it to the player cube. Copy and paste the player script code into the Player1 script.
4. Create a new C# script called "AI_chasePlayer" and attach it to a new cube that will serve as the enemy. Copy and paste the AI script code into the AI_chasePlayer script.
5. In the Unity editor, select the enemy cube and in the inspector, set the "Player" field of the AI_chasePlayer script to the player cube.
6. Add a NavMeshAgent component to the enemy cube.
7. Bake the NavMesh by going to Window > AI > Navigation, selecting the plane, and clicking "Bake".
8. Press play to test the game. The enemy will chase the player when they are within the detection range, and the game will end when the enemy catches the player.

#coordinates of player and enemy for the main scene:
Player: (0, 0.5, 0)
Enemy: (5, 0.5, 5)

#inspector settings:
Player:
- Position: (0, 0.5, 0)
- Scale: (1, 1, 1)
- Rigidbody settings:
  - Mass: 1
  - Drag: 0
  - Angular Drag: 0.05
  - Use Gravity: true
  - Is Kinematic: false
Enemy:
- Position: (5, 0.5, 5)
- Scale: (1, 1, 1)
- NavMeshAgent settings:
  - Speed: 3.5
  - Angular Speed: 120
  - Acceleration: 8
  - Stopping Distance: 0.5

#anything else:
- Make sure to have a NavMesh baked for the ground plane to allow the enemy to navigate towards the player.
