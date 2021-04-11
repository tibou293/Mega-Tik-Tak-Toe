using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator starTransition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            sceneTransition();
        }
    }

    public void sceneTransition()
    {
        StartCoroutine(LoadLevel(0));

    }

    IEnumerator LoadLevel(int levelIndex)
    {
        starTransition.SetTrigger("StartTrigger");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }

    
    
    /*
    public void whichScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    } 
    */




}
