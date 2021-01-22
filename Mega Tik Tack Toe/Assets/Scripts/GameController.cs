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
    public AudioSource feldClickAudio;
    public AudioSource restartClickAudio;
    public AudioSource rematchClickAudio;
    public Button closeButton;


    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
    }

    void GameSetup()
    {
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

    public void TicTacToeButton(int WhichNumber)
    {
        starButton.interactable = false;
        crossButton.interactable = false;
        tictactoeSpaces[WhichNumber].image.sprite = playIcons[whoTurn];
        tictactoeSpaces[WhichNumber].interactable = false;

        markedSpaces[WhichNumber] = whoTurn+1;
        turnCount++;

        if(turnCount > 4)
        {
            WinnerCheck();
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

    void WinnerCheck()
    {
        int s1 = markedSpaces[0] + markedSpaces[1] + markedSpaces[2]; //horizontal oben
        int s2 = markedSpaces[3] + markedSpaces[4] + markedSpaces[5]; //horizontal mitte
        int s3 = markedSpaces[6] + markedSpaces[7] + markedSpaces[8]; //horizontal unten

        int s4 = markedSpaces[0] + markedSpaces[3] + markedSpaces[6]; //vertikal links
        int s5 = markedSpaces[1] + markedSpaces[4] + markedSpaces[7]; //vertikal mitte
        int s6 = markedSpaces[2] + markedSpaces[5] + markedSpaces[8]; //vertikal rechts

        int s7 = markedSpaces[0] + markedSpaces[4] + markedSpaces[8]; //diagonal oben links -> unten rechts
        int s8 = markedSpaces[2] + markedSpaces[4] + markedSpaces[6]; //diagonal oben rechts -> unten links#

        var solutions = new int[] { s1, s2, s3, s4, s5, s6, s7, s8 };

        for(int i = 0; i < solutions.Length; i++)
        {
            if(solutions[i] == 3 * (whoTurn + 1))
            {
                WinnerDisplay(i);
                Debug.Log("Player" + whoTurn + "won the game!");
                return;
            }
        }
    }

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

    public void playClickAudio()
    {
        feldClickAudio.Play();
    }
    public void playRestartAudio()
    {
        restartClickAudio.Play();
    }
    public void playRematchAudio()
    {
        rematchClickAudio.Play();
    }

    public void CloseButtonClick()
    {
        Application.Quit();
        Debug.Log("Close Application");
    }

}

