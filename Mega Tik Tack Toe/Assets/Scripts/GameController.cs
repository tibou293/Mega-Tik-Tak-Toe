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
    int oneRight01;
    int oneRight02;
    int oneRight03;
    int oneRight04;
    int oneRight05;
    int oneRight06;
    int oneRight07;
    int oneRight08;
    int oneRight09;



    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
    }

    void GameSetup()
    {
        oneRight01 = 0;
        oneRight02 = 0;
        oneRight03 = 0;
        oneRight04 = 0;
        oneRight05 = 0;
        oneRight06 = 0;
        oneRight07 = 0;
        oneRight08 = 0;
        oneRight09 = 0;
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
      /*  changeField();  */
    }



    void WinnerCheck(int bigSpaceNumber)
    {
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
            if (solutions[i] == 3 * (whoTurn + 1))
            {

                //  WinnerDisplay(i);
                Debug.Log("Player " + whoTurn + " won the game!");

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
    }












  /*  void changeField()
    {
        var oL = new int[] {markedSpaces[0], markedSpaces[9], markedSpaces[18],
                            markedSpaces[27], markedSpaces[36], markedSpaces[45],
                            markedSpaces[54], markedSpaces[63], markedSpaces[72],};


        for (var k = 0; k < oL.Length; k++)
        {
            if (oL[k] )
            {
                
                Debug.Log(k);
            }
        }

    }  */



    // hallo


















    void WinnerDisplay(int indexIn)
    {
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

        winningLine[indexIn].SetActive(true);

    }

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

    public void Restart()
    {
        Rematch();
        starScore = 0;
        crossScore = 0;
        starScoreText.text = "0";
        crossScoreText.text = "0";
    }


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

    public void CloseButtonClick()
    {
        Application.Quit();
        Debug.Log("Close Application");
    }

}

