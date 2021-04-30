using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
    public Text Tutorialtext;
    public Button ContinueButton;
    public GameController VarFromGameController;
    public GameObject[] Arrows = new GameObject[2];

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Tutorial101());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Tutorial101()
    {
        ContinueButton.GetComponent<Button>().onClick.AddListener(Tutorial102);

            Tutorialtext.text = "Willkommen zu diesem Tutorial";

            yield return new WaitForSeconds(3.5f);

            Tutorialtext.text = "Dieses Spiel kann ausschließlich zu zweit gespielt werden.";
    }

    public void Tutorial102()
    {
        Arrows[0].SetActive(true);
        Arrows[1].SetActive(true);
        Arrows[0].transform.position = new Vector2(170 , 250);
        Arrows[0].transform.rotation = Quaternion.Euler(0, 0, 46);
        Arrows[1].transform.position = new Vector2(620, 250);
        Arrows[1].transform.rotation = Quaternion.Euler(0, 0, -19);
        VarFromGameController.turnsIcons[1].SetActive(true);
        Tutorialtext.text = "Die Kreise zeigen an, wer am Zug ist.";
        ContinueButton.GetComponent<Button>().onClick.AddListener(Tutorial103);
    }

    public void Tutorial103()
    {
        Arrows[0].transform.position = new Vector2(160, 220);
        Arrows[0].transform.rotation = Quaternion.Euler(0, 0, 127);
        Arrows[1].transform.rotation = Quaternion.Euler(0, 0, -106);
        VarFromGameController.turnsIcons[1].SetActive(false);
        Tutorialtext.text = "Die Zahlen geben an, wie viele Spiele man gewonnen hat.";
        ContinueButton.GetComponent<Button>().onClick.AddListener(Tutorial104);
    }

    public void Tutorial104()
    {
        Arrows[0].SetActive(false);
        Arrows[1].transform.position = new Vector2(600, 190);
        Arrows[1].transform.rotation = Quaternion.Euler(0, 0, -135);
        Tutorialtext.text = "Der Neustart Knopf setzt die Zahlen zurück. Der Nochmal Knopf setzt die Zahlen nicht zurück.";
    }

    public void Tutorial105()
    {
        Tutorialtext.text = "Das große Gitter ist das Spielgitter. In diesem belegt man mit den Münzen Felder.";
    }

    public void Tutorial106()
    {
        Tutorialtext.text = "Das kleine Gitter an der Seite zeigt an, wer welches großes Feld gewonnen hat.";
    }

    public void Tutorial107()
    {
        Tutorialtext.text = "Ziel des Speil ist es, dass man im großen Gitter drei Felder in einer Reihe besitzt.";
    }

    public void Tutorial201()
    {
        Tutorialtext.text = "Ziel des Speil ist es, dass man im großen Gitter drei Felder in einer Reihe besitzt.";
    }

    public void Tutorial202()
    {
        Tutorialtext.text = "Ziel des Speil ist es, dass man im großen Gitter drei Felder in einer Reihe besitzt.";
    }

    public void Tutorial203()
    {
        Tutorialtext.text = "Ziel des Speil ist es, dass man im großen Gitter drei Felder in einer Reihe besitzt.";
    }

    public void Tutorial204()
    {
        Tutorialtext.text = "Ziel des Speil ist es, dass man im großen Gitter drei Felder in einer Reihe besitzt.";
    }

    public void Tutorial205()
    {
        Tutorialtext.text = "Ziel des Speil ist es, dass man im großen Gitter drei Felder in einer Reihe besitzt.";
    }

    public void Tutorial301()
    {
        Tutorialtext.text = "Ziel des Speil ist es, dass man im großen Gitter drei Felder in einer Reihe besitzt.";
    }

}

