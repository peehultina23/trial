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