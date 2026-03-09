
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
In new 3D scene
add sphere and cube
cube mein add box collider
in sphere - add angle.cs and degree_checker.cs scripts and drag cube from heirarchy in Targe field 
save and run the scene. Move the sphere using WASD keys and check the console for angle and range information.
