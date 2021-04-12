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
    public int yStartButton = 90;
    public int yTutorialButton = 117;
    public int yTitleText = 271;


    // Start is called before the first frame update
    void Start()
    { 

    }
    // Update is called once per frame
    void Update()
    {
        beforeStart();
        preferencesWheelRotation();
        //änderung();
        StartCoroutine(introGame());
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



    void beforeStart()
    {
        StartButton.transform.position = new Vector3 (173, yStartButton, 199);
        TutorialButton.transform.position = new Vector3(319, yTutorialButton, 249);
        TitleText.transform.position = new Vector3(237, yTitleText, 229);
    }


    IEnumerator introGame()
    {
        if (yTitleText > 133)
        {
            yTitleText--;
        }
        else
        {
            yTitleText = 133;
        }
        yield return new WaitForSeconds(1f);

        if (yStartButton < 194)
        {
            yStartButton++;
        }
        else
        {
            yStartButton = 194;
        }
        yield return new WaitForSeconds(1f);
        if (yTutorialButton < 190)
        {
            yTutorialButton++;
        }
        else
        {
            yTutorialButton = 190;
        }
    }
}

   /* void änderung()
    {
        if (yStartButton < 194)
        {
            yStartButton++;
        }
        else
        {
            yStartButton = 194;
        }

        if (yTutorialButton < 190)
        {
            yTutorialButton++;
        }
        else
        {
            yTutorialButton = 190;
        }
    }*/




