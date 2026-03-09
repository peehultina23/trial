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

#steps:
1. Create a 3D character (or use a pre-made one from the asset store - maximo)
2. Add an animator component to the character
3. Create an animator controller and add it to the animator component
4. Create animation clips for walking and running (or use pre-made ones)
5. Set up the animator controller with parameters (Walk and Run) and transitions between the idle, walk, and run states
6. Create a new C# script called "Animation_Script" and attach it to the character
7. Copy and paste the above code into the Animation_Script
8. Run the scene and press the W key to make the character walk and the D key to make it run.

#inspector window:
- Animator component: assign the animator controller to the Controller field
- Animation_Script component: no additional settings needed, as the script will automatically reference the animator component and respond to the W and D key inputs to control the walking and running animations.

