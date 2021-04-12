using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [Range(0, 24)]
    public float TimeOfDay;

    public Light Sun;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        UpdateTime();
    }

    void UpdateTime()
    {
        Sun.transform.rotation = Quaternion.Euler(TimeOfDay, 1079, 0);
    }


}
