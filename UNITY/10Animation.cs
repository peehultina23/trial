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

Phase 1: Asset Preparation (Mixamo)
 * Character: Download a character (e.g., "Arissa") as FBX Binary with Skin.
 * Animations: Search and download Running, Breathing, and Walking animations.
   * Settings: 30 FPS, Without Skin (since you already have the character skin).
 * Unity Import: Create an "animation" folder in your Assets and drag all FBX files into it.
 * Fix Textures: Select the character FBX in Unity, go to the Materials tab in the Inspector, and click Extract Textures and Extract Materials.

Phase 2: Animator Controller Setup
 * Create Controller: Right-click in your folder > Create > Animator Controller. Name it "animator".
 * Add States: Open the Animator window and drag your animation clips (breathing, walking, running) into the grid.
 * Define Parameters: In the Animator window, click the Parameters tab, click +, select Bool, and create two: Walk and Running.
 * Set Transitions: * Right-click breathing > Make Transition to walking (and vice versa).
   * Right-click breathing > Make Transition to running (and vice versa).
 * Configure Logic: Click each transition arrow and uncheck Has Exit Time. Add Conditions:
   * Breathing \rightarrow Walking: Walk = true.
   * Walking \rightarrow Breathing: Walk = false.
   * Breathing \rightarrow Running: Running = true.
   * Running \rightarrow Breathing: Running = false.

Phase 3: Scripting & Binding
 * Create Script: Create Animation_script.cs and use the following logic:
 
   public class Animation_script : MonoBehaviour {
    private Animator myanim;
    void Start() { myanim = GetComponent<Animator>(); [span_23](start_span)} //[span_23](end_span)
    void Update() {
        myanim.SetBool("Walk", Input.GetKey(KeyCode.W)); [span_24](start_span)//[span_24](end_span)
        myanim.SetBool("Running", Input.GetKey(KeyCode.D)); [span_25](start_span)//[span_25](end_span)
    }
}

 * Attach Components: Select your character in the Hierarchy:
   * Drag the Animator Controller into the Animator component's Controller slot.
   * Drag the Animation_script onto the character to add it as a component.

Phase 4: Testing
 * Press Play in Unity.
 * Hold W to trigger the Walking animation.
 * Hold D to trigger the Running animation.