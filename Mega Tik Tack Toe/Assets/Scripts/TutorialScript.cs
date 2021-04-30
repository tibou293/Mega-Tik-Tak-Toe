﻿using System.Collections;
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
    public GameObject smallWinningLine;
    public GameObject TutorialPanel;
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
        ContinueButton.GetComponent<Button>().onClick.AddListener(Tutorial105);
    }

    public void Tutorial105()
    {
        Arrows[0].SetActive(true);
        Arrows[1].transform.position = new Vector2(600, 190);
        Arrows[1].transform.rotation = Quaternion.Euler(0, 0, 46);
        Arrows[0].transform.position = new Vector2(170, 250);
        Arrows[0].transform.rotation = Quaternion.Euler(0, 0, -120);
        Tutorialtext.text = "Das große Gitter ist das Spielgitter. In diesem belegt man mit den Münzen Felder.";
        ContinueButton.GetComponent<Button>().onClick.AddListener(Tutorial106);
    }

    public void Tutorial106()
    {
        Arrows[1].SetActive(false);
        Arrows[0].transform.position = new Vector2(160, 190);
        Arrows[0].transform.rotation = Quaternion.Euler(0, 0, 160);
        Tutorialtext.text = "Das kleine Gitter an der Seite zeigt an, wer welches großes Feld gewonnen hat.";
        ContinueButton.GetComponent<Button>().onClick.AddListener(Tutorial107);
    }

    public void Tutorial107()
    {
        Arrows[0].SetActive(false);
        VarFromGameController.winningLine[0].SetActive(true);
        Tutorialtext.text = "Ziel des Spiel ist es, dass man im großen Gitter drei Felder in einer Reihe besitzt.";
        ContinueButton.GetComponent<Button>().onClick.AddListener(Tutorial201);
    }

    public void Tutorial201()
    {
        VarFromGameController.winningLine[0].SetActive(false);
        smallWinningLine.SetActive(true);
        Tutorialtext.text = "Um ein großes Feld zu besitzten muss man in desem Feld das kleine TicTacToe gewinnen.";
        ContinueButton.GetComponent<Button>().onClick.AddListener(Tutorial202);
    }

    public void Tutorial202()
    {

        TutorialPanel.SetActive(false);
        smallWinningLine.SetActive(false);
        Tutorialtext.text = "Der erste Spieler klicke in eines der kleinen Feldern um es zu seinem zumachen.";
        for (int i = 0; i < VarFromGameController.markedSpaces.Length; i++)
        {
            Debug.Log(i);
            if (VarFromGameController.markedSpaces[i] == 1)
            {
                Tutorial203();
            }
        }
    }

    public void Tutorial203()
    {
        Tutorialtext.text = "Aufgrund desen dass Spieler 1 in dieses Feld gedrückt hat, muss der nächste Spieler in das dementsprechende große Feld setzten.";
    }

    public void Tutorial204()
    {
        Tutorialtext.text = "Spieler 2 hat in dieses Feld gedrückt, deshalb muss Spieler eins in das dementsprechende große Feld setzten.";
    }

    public void Tutorial205()
    {
        Tutorialtext.text = "So geht es nun die ganze Zeit weiter bis ein Spieler drei große Felder in einer Reihe besitzt.";
        ContinueButton.GetComponent<Button>().onClick.AddListener(Tutorial301);
    }

    void Tutorial301()
    {
        Tutorialtext.text = "Viel Spaß beim spielen!";
        StartCoroutine(Tutorial301continue());
    }

    IEnumerator Tutorial301continue()
    {
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(0);
    }

}

