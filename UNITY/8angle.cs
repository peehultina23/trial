
#check sphere collider for angle
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RangeChecker : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float range = 5;
    private bool targetWasInRange = false;
    // Update is called once per frame
    void Update()
    {
        var distance = (target.position - transform.position).magnitude;
        if(distance <=range && targetWasInRange == false)
        {
            Debug.LogFormat("Target {0} entered range", target.name);
            targetWasInRange = true;
        }
        else if(distance > range && targetWasInRange == true)
        {
            Debug.LogFormat("Target {0} exited range", target.name);
            targetWasInRange = false;
        }
    }
}

In new 3D scene
add sphere and cube
cube mein add box collider
in sphere - add angle.cs and degree_checker.cs scripts and drag cube from heirarchy in Targe field 
save and run the scene. Move the sphere using WASD keys and check the console for angle and range information.