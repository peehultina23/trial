//10B -Animation_script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Script : MonoBehaviour
{
       private Animator myanim;

    bool iswalking = false;

    bool isrunning = false;

    // Start is called before the first frame update
    void Start()
    {
        myanim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        iswalking = Input.GetKey(KeyCode.W);
        myanim.SetBool("Walk", iswalking);
        isrunning = Input.GetKey(KeyCode.D);
        myanim.SetBool("Run", isrunning);
    }
}