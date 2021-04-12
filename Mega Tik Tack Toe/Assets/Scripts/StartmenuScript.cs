using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartmenuScript : MonoBehaviour
{
    public GameObject PreferencesWheel;
    public int Rotate = 1; //Start value of PreferencesWheelRotation
    public Button StartButton;
    public Button TutorialButton;
    public GameObject TitleText;



    // Start is called before the first frame update
    void Start()
    {
        beforeStart();
        StartCoroutine(introGame());
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
        SceneManager.LoadScene(1);
    }

    void beforeStart()
    {
        StartButton.transform.position = new Vector3 (-411, -20, 103);
        TutorialButton.transform.position = new Vector3(-151, -10, 53);
        TitleText.transform.position = new Vector3(237, 271, 229);
    }


    IEnumerator introGame()
    {
        yield return new WaitForSeconds(1f);
        //StartButton.transform.position.
        yield return new WaitForSeconds(2f);
        Debug.Log("du da");
    }

}


