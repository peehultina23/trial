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