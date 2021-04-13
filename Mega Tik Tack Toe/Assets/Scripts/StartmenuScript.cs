using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartmenuScript : MonoBehaviour
{
    public GameObject PreferencesWheel;
    public int Rotate = 1; //Start value of PreferencesWheelRotation
    public GameObject StartButton;
    public GameObject TutorialButton;
    public GameObject TitleText;

    //Start Y-Werte
    public int StartYStartButton = 90; 
    public int StartYTutorialButton = 117;
    public int StartYTitleText = 300;

    //End Y-Werte
    public int EndYStartButton = 194;
    public int EndYTutorialButton = 190;
    public int EndYTitleText = 40;


    // Start is called before the first frame update
    void Start()
    { 

    }


    // Update is called once per frame
    void Update()
    {
        beforeStart();
        preferencesWheelRotation();
        StartCoroutine(introGame());
        QuitGame();
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
        SceneManager.LoadScene(1);
    }


    //setzt auf Startposition (nicht sichtbar)
    void beforeStart()
    {
        StartButton.transform.position = new Vector3 (173, StartYStartButton, 199);
        TutorialButton.transform.position = new Vector3(319, StartYTutorialButton, 249);
        TitleText.transform.position = new Vector3(237, StartYTitleText, 229);
    }

    //bewegt Objekte an endgültige Position
    IEnumerator introGame()
    {
        if (StartYTitleText > EndYTitleText)
        {
            StartYTitleText--;
        }
        else
        {
            StartYTitleText = EndYTitleText;
        }

        yield return new WaitForSeconds(2.5f);

        if (StartYStartButton < EndYStartButton)
        {
            StartYStartButton++;
        }
        else
        {
            StartYStartButton = EndYStartButton;
        }

        yield return new WaitForSeconds(1f);

        if (StartYTutorialButton < EndYTutorialButton)
        {
            StartYTutorialButton++;
        }
        else
        {
            StartYTutorialButton = EndYTutorialButton;
        }
    }

    void QuitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Close Application");
            Application.Quit();
        }
    }


}





