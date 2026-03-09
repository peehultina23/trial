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