using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{

    public int whoTurn; //0=Star and 1=Cross
    public int turnCount; // zahlt die gespielten Felder
    public GameObject[] turnsIcons; // zeigt wer dran ist
    public Sprite[] playIcons; //0=Star Icon and 1=Cross Icon
    public Button[] tictactoeSpaces; //freie Spielfelder
    public GameObject[] bigField;
    public int[] markedSpaces; //Makiert was von wem angetippt wurde
    public Text winnerText; //der Text der angibt wer gewinnt
    public GameObject[] winningLine; //die Linien die einen Sieg makieren
    public GameObject winnerPanel;
    public int starScore;
    public int crossScore;
    public Text starScoreText;
    public Text crossScoreText;
    public Button starButton;
    public Button crossButton;
    public Button closeButton;

    public int[] winners; //Gewinner eines großen Feldes


    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
    }

    //Die Grundeinstellungen am anfang des Spiels
    void GameSetup()
    {
        winners = new int[9];
        for(int i = 0; i < winners.Length; i++)
        {
            winners[i] = -100;
        }
        whoTurn = 0;
        turnCount = 0;
        turnsIcons[0].SetActive(true);
        turnsIcons[1].SetActive(false);
        for(int i = 0; i <tictactoeSpaces.Length; i++)
        {
            tictactoeSpaces[i].interactable = true;
            tictactoeSpaces[i].GetComponent<Image>().sprite = null;
        }
        for(int i = 0; i < markedSpaces.Length; i++)
        {
            markedSpaces[i] = -100;
        }
    }


    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Close Application");
            Application.Quit();
        }
    }


    //Checkt die Sige in den kleinen Feldern
    void WinnerCheck(int bigSpaceNumber)
    {
        if (winners[bigSpaceNumber] >= 0) return;

        int s1 = markedSpaces[0 + bigSpaceNumber * 9] + markedSpaces[1 + bigSpaceNumber * 9] + markedSpaces[2 + bigSpaceNumber * 9]; //horizontal oben
        int s2 = markedSpaces[3 + bigSpaceNumber * 9] + markedSpaces[4 + bigSpaceNumber * 9] + markedSpaces[5 + bigSpaceNumber * 9]; //horizontal mitte
        int s3 = markedSpaces[6 + bigSpaceNumber * 9] + markedSpaces[7 + bigSpaceNumber * 9] + markedSpaces[8 + bigSpaceNumber * 9]; //horizontal unten

        int s4 = markedSpaces[0 + bigSpaceNumber * 9] + markedSpaces[3 + bigSpaceNumber * 9] + markedSpaces[6 + bigSpaceNumber * 9]; //vertikal links
        int s5 = markedSpaces[1 + bigSpaceNumber * 9] + markedSpaces[4 + bigSpaceNumber * 9] + markedSpaces[7 + bigSpaceNumber * 9]; //vertikal mitte
        int s6 = markedSpaces[2 + bigSpaceNumber * 9] + markedSpaces[5 + bigSpaceNumber * 9] + markedSpaces[8 + bigSpaceNumber * 9]; //vertikal rechts

        int s7 = markedSpaces[0 + bigSpaceNumber * 9] + markedSpaces[4 + bigSpaceNumber * 9] + markedSpaces[8 + bigSpaceNumber * 9]; //diagonal oben links -> unten rechts
        int s8 = markedSpaces[2 + bigSpaceNumber * 9] + markedSpaces[4 + bigSpaceNumber * 9] + markedSpaces[6 + bigSpaceNumber * 9]; //diagonal oben rechts -> unten links


        var solutions = new int[] { s1, s2, s3, s4, s5, s6, s7, s8 };



        for (int i = 0; i < solutions.Length; i++)
        {
            Debug.Log("hallo" + solutions);
            if (solutions[i] == 3 * (whoTurn + 1))
            {
               
                winners[bigSpaceNumber] = whoTurn;
                //  WinnerDisplay(i);
                Debug.Log("Player " + whoTurn + " won a field!");
                WinnerCheckAll();
                return;

            }
        }
    }


    //Checkt den Sieg im großen Feld
    public void WinnerCheckAll()
    {
        int s1 = winners[0] + winners[1] + winners[2]; //horizontal oben
        int s2 = winners[3] + winners[4] + winners[5]; //horizontal mitte
        int s3 = winners[6] + winners[7] + winners[8]; //horizontal unten

        int s4 = winners[0] + winners[3] + winners[6]; //vertikal links
        int s5 = winners[1] + winners[4] + winners[7]; //vertikal mitte
        int s6 = winners[2] + winners[5] + winners[8]; //vertikal rechts

        int s7 = winners[0] + winners[4] + winners[8]; //diagonal oben links -> unten rechts
        int s8 = winners[2] + winners[4] + winners[6]; //diagonal oben rechts -> unten links


        var solutions = new int[] { s1, s2, s3, s4, s5, s6, s7, s8 };
       


        for (int i = 0; i < solutions.Length; i++)
        {

            if (solutions[i] == 3 * (whoTurn))
            {
                //  WinnerDisplay(i);
                Debug.Log("Player " + whoTurn + " won the game!");
                WinnerDisplay(i);
                return;

            }
        }
    }
   

    public void TicTacToeButton(int WhichNumber)
    {
        starButton.interactable = false;
        crossButton.interactable = false;
        tictactoeSpaces[WhichNumber].image.sprite = playIcons[whoTurn];
        tictactoeSpaces[WhichNumber].interactable = false;

        markedSpaces[WhichNumber] = whoTurn + 1;
        turnCount++;

        if (turnCount > 4)
        {
            WinnerCheck(WhichNumber/9);
        }


        if (whoTurn == 0)
        {
            whoTurn = 1;
            turnsIcons[0].SetActive(false);
            turnsIcons[1].SetActive(true);
        }
        else
        {
            whoTurn = 0;
            turnsIcons[0].SetActive(true);
            turnsIcons[1].SetActive(false);
        }

        SetNewInteractable(WhichNumber % 9);
    }

    //gibt an, welche Felder als nächstes bespielt werden können
    void SetNewInteractable(int bigSpaceNumber)
    {
        int n = 0;
        for(int i = 0; i < 81; i++)
        {
            if (markedSpaces[i] > 0) continue;

            //tictactoeSpaces[i].gameObject.SetActive((i / 9) == bigSpaceNumber);
            bool interactable = bigSpaceNumber == -1 || (i / 9) == bigSpaceNumber;
            tictactoeSpaces[i].interactable = interactable;
            n += interactable ? 1 : 0;
        }

        if (n == 0 && bigSpaceNumber == -1) WinnerDisplay(-1);
        if (n == 0) SetNewInteractable(-1);
        
    }

    








    //Das Display am Ende, auf dem Steht wer gewonnen hat
    void WinnerDisplay(int indexIn)
    {
        Debug.Log(indexIn);
        winnerPanel.gameObject.SetActive(true);
        if (whoTurn == 0)
        {
            starScore++;
            starScoreText.text = starScore.ToString();
            winnerText.text = "Star Wins!";
        }
        else if (whoTurn == 1)
        {
            crossScore++;
            crossScoreText.text = crossScore.ToString();
            winnerText.text = "Cross Wins!";
        }
        else if (whoTurn == -1)
        {
            winnerText.text = "Tie";
        }

        winningLine[indexIn].SetActive(true);

    }

    //Nochmal Knopf (Spielstand wird nicht zurückgesetzt)
    public void Rematch()
    {
        starButton.interactable = true;
        crossButton.interactable = true;

        GameSetup();
        for(int i = 0; i < winningLine.Length; i++)
        {
            winningLine[i].SetActive(false);
        }
        winnerPanel.SetActive(false);
    }

    //Neustart Knopf (StRTET DAS GESAMTE SPIEL NEU: Spielstand wird zurückgesetzt)
    public void Restart()
    {
        Rematch();
        starScore = 0;
        crossScore = 0;
        starScoreText.text = "0";
        crossScoreText.text = "0";
    }

    //Die Auswahl des Startspielers am Anfang der Runde
    public void SwitchPlayer(int whichPlayer)
    {
        if(whichPlayer == 0)
        {
            whoTurn = 0;
            turnsIcons[0].SetActive(true);
            turnsIcons[1].SetActive(false);
        }
        else if(whichPlayer == 1)
        {
            whoTurn = 1;
            turnsIcons[0].SetActive(false);
            turnsIcons[1].SetActive(true);
        }
    }

    //Knopf zum schließen
    public void CloseButtonClick()
    {
        Application.Quit();
        Debug.Log("Close Application");
    }

}

