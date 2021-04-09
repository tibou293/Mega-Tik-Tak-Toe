using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PreferencesScript : MonoBehaviour
{
    public GameObject PreferencesPanel;
    public GameObject SoundeffectToggle;
    public GameObject AudioScript;
    public int SoundActiv = 0;


    // Start is called before the first frame update
    void Start()
    {
        PreferencesPanel.SetActive(false);
        if (PlayerPrefs.HasKey("PlayerPrefsSoundActiv"))
        {
            SoundActiv = PlayerPrefs.GetInt("PlayerPrefsSoundActiv");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    //open and close Preferences
    public void openPreferences()
    {
        if (PreferencesPanel.activeSelf == false)
        {
            PreferencesPanel.SetActive(true);
        }
        else
        {
            PreferencesPanel.SetActive(false);
        }
    }


    public void SoundeffectToggleCheck()
    {
        if (AudioScript.activeSelf == false && SoundActiv == 0)
        {
            AudioScript.SetActive(true);
            SoundActiv = 1;
        }
        else
        {
            AudioScript.SetActive(false);
            SoundActiv = 0;
        }
        PlayerPrefs.SetInt("PlayerPrefsSoundActiv" , SoundActiv);
        Debug.Log(SoundActiv);
    }




}
