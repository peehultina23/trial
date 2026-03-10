#10A
steps
search mixamo in google
sign up for mixamo
click on character and select anyone from the following
click on animations
Search Running and select the plain running one, 'with skin' and download it
Search Breathing and select it, 'without skin' and download it
Search Walking, select it 'without skin' and download it
now go to unity and create a 3D project 
Create a new folder in Assets and name it animation, and drag the three animation fbx folder into it
the character one with skin, and drop that one in the scene view
Now we have to make the character facing you

Running > Inspector Running ka
position : X= -1.23, Y= -0.13, Z= -7.37
rotation : X=0, Y=150, Z=0
Scale : X=1, Y=1, Z=1

Select the running animation from the project folder and in the inspector window open materials tab
Click on extract materials
Then select the folder where you downloaded the animations
then extract features

Expand the animations from the animation folder and click the triangle Then click edit in inspector window
there you will se option to edit your animation name, change it to their respective name (from mixamo.com to running) and etc
do the same for walking and breathing

Right click in animation folder
create > animation > animation controller
Select Animator Controller > name it anything (eg:Animator) and then double click on it

Drag and drop walking animation in the animator controller
Then drag and drop the two other states too

Right click on walking > make transition > and connect to the one you want to make your next move and then to the same for other too until all 3 are connected

Double click on the arrow
Change exit time, to however long you want that animation to last, and change for all three

Connect your last animation back to first, for loop

then, again in project structure
Under Loop Time, check the box for all three

Click your character from the hierarchy panel and then add component and search your animation controller name(eg: Animator)
double click on it and then run
#10b
Do 10A then continue 

In assets >animation > new animation controller by right clicking on animation > create>animation > animation controller : secondAnimation > double click on it 

Put breathing first and entry should be connected to breathing 
Connect it anyhow, just make sure there is no connection between running and walking 

Eg : running > breathing > then back to running || breathing > walking > then back to breathing 




In assets > new script : Animation_script :

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
        myanim.SetBool("walking", iswalking);
        isrunning = Input.GetKey(KeyCode.D);
        myanim.SetBool("running", isrunning);
    }
}


Bind this script to your character (Running) ^ 

Then in animator window >Parameter > click on the plus sign > bool > name it walking > make another one and name it running 

Click on the transition line from breathe to walk > uncheck “Has Exit Time”  > there, down only > conditions > + > first (left side) parameter walk : > second (right side) parameter : true 

Click on the transition line from walking to breathe > uncheck “Has Exit Time”  > there, down only > conditions > + > first (left side) parameter walk : > second (right side) parameter : false 

Click on breathing to running transition arrow > uncheck “Has Exit Time”  > there, down only > conditions > + > first (left side) parameter running : > second (right side) parameter : true

Click on running to  breathing  transition arrow > uncheck “Has Exit Time”  > there, down only > conditions > + > first (left side) parameter running : > second (right side) parameter : false


In hierarchy > running > in inspector, animator controller > in controller, replace from firstAnimation to secondAnimation 

Run it 

Click on W and D keys

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