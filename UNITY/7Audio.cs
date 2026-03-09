Create new 2d scene
Select main camera in heirarchy
and add compnenet Audio Source 
then drag and drom the audio that you have downloaded next add the audio script
save and run the scene. Press A to play the audio and D to stop it.



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
