using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioScript : MonoBehaviour
{
    public AudioSource feldClickAudio;
    public AudioSource restartClickAudio;
    public AudioSource rematchClickAudio;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playClickAudio()
    {
        feldClickAudio.Play();
    }
    public void playRestartAudio()
    {
        restartClickAudio.Play();
        Debug.Log("geht");
    }
    public void playRematchAudio()
    {
        rematchClickAudio.Play();
    }



}
