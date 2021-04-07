using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartmenuScript : MonoBehaviour
{
    public GameObject PreferencesWheel;
    public int Rotate = 1; //Start value of PreferencesWheelRotation



    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

        preferencesWheelRotation();
    }



    //Wheel Rotation
    void preferencesWheelRotation()
    {
        Rotate--;
        if (Rotate == -360)
        {
            Rotate = 1;
        }
        PreferencesWheel.transform.rotation = Quaternion.Euler(0, 0, Rotate);
    }

    //Auf Knopfdruck "Start Game" startet das Spiel
    public void switchScene()
    {
        SceneManager.LoadScene(0);
    }



}


