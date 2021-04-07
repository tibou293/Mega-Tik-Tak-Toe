using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        PreferencesWheelRotation();
    }



    //Wheel Rotation
    void PreferencesWheelRotation()
    {
        Rotate--;
        if (Rotate == -360)
        {
            Rotate = 1;
        }
        Debug.Log(Rotate);
        PreferencesWheel.transform.rotation = Quaternion.Euler(0, 0, Rotate);
    }

}


