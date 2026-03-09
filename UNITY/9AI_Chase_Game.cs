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
