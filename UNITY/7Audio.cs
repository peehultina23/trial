#coordinates for object in front of camera
To set an object properly in front of the camera in the Unity scene inspector, you can use
the following coordinates:
- Position: (0, 0, 5) - This will place the object 5 units in front of the camera along the Z-axis.
- Rotation: (0, 0, 0) - This will ensure the object is not rotated and faces the camera directly.
- Scale: (1, 1, 1) - This will keep the object at its original size.
Make sure to adjust the Z-coordinate based on the distance you want the object to be from the
camera. If you want it closer, you can use a smaller value (e.g., 3), and if you want it farther away, you can use a larger value (e.g., 10).


#steps to create and set audio source in Unity
1. Open Unity and create a new 2D project.
2. In the Project window, right-click and select "Create > C# Script". Name the script "audio".
3. Double-click the script to open it in your code editor (e.g., Visual Studio).
4. Replace the default code with the following code to control audio playback:


using UnityEngine;

public class audio : MonoBehaviour
{
    public AudioSource audioSource;

    void Start(){
        audioSource = GetComponent<AudioSource>();

        if(audioSource == null){
            Debug.Log("Audio not found.");
        }
        audioSource.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            audioSource.Play();
        }
        
        if(Input.GetKeyDown(KeyCode.D)){
            audioSource.Stop();
        }
    }
}
5. Save the script and return to Unity.
6. Create a new GameObject in the scene (e.g., an empty GameObject or a sprite).
7. Select the GameObject and click "Add Component" in the Inspector window. Search for "audio" and add it to the GameObject.
8. With the GameObject still selected, click "Add Component" again and search for "Audio Source". Add the Audio Source component to the GameObject.
9. In the Audio Source component, assign an audio clip to the "Audio Clip" field. You can use any audio file you have in your project (e.g., .mp3, .wav).
10. Press the Play button to run the scene. Press the "A" key to play the audio and the "D" key to stop it.

# Note: Make sure to have an audio clip assigned to the Audio Source component for the audio to play when you press the "A" key.