using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [Range(0, 24)]
    public float TimeOfDay;

    public Light Sun;
    public Light Moon;
    public float orbitSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        TimeOfDay = 8f;
    }


    // Update is called once per frame
    void Update()
    {
        TimeOfDay += Time.deltaTime * orbitSpeed;
        if (TimeOfDay > 24)
        {
            TimeOfDay = 0;
        }
        
        UpdateTime();


    }

    void UpdateTime()
    {
        float alpha = TimeOfDay / 24f;
        float sunRotation = Mathf.Lerp(-90, 270, alpha);
        float moonRotation = sunRotation - 180;
        Sun.transform.rotation = Quaternion.Euler(sunRotation, 1079, 0);
        Moon.transform.rotation = Quaternion.Euler(moonRotation, 1079, 0);
    }


}
