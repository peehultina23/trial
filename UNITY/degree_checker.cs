
using UnityEngine;

public class DegreeChecker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Transform target;
    [SerializeField] float moveSpeed = 5f;


    // Update is called once per frame
    void Update()
    {
        var direction = target.position - transform.position;
        var directionToTarget = direction.normalized;
        var dotproduct = Vector3.Dot(transform.forward, directionToTarget);
        var angle = Mathf.Acos(dotproduct);
        Debug.LogFormat("Angle to target {0} is {1} degrees", target.name, angle * Mathf.Rad2Deg);

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(moveX, 0, moveZ);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
           
    }
}
