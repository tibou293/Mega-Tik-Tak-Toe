using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreferencesScript : MonoBehaviour
{
    public GameObject PreferencesPanel;
    public GameObject SoundeffectToggle;
    public GameObject AudioScript;


    // Start is called before the first frame update
    void Start()
    {
        PreferencesPanel.SetActive(false);
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
        if (AudioScript.activeSelf == false)
        {
            AudioScript.SetActive(true);
        }
        else
        {
            AudioScript.SetActive(false);
        }
    }




}
