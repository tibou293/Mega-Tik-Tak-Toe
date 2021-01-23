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

    public void TicTacToeButton01(int WhichNumber)
    {
        starButton.interactable = false;
        crossButton.interactable = false;
        tictactoeSpaces[WhichNumber].image.sprite = playIcons[whoTurn];
        tictactoeSpaces[WhichNumber].interactable = false;

        markedSpaces[WhichNumber] = whoTurn+1;
        turnCount++;

        if(turnCount > 4)
        {
            WinnerCheck01();
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

    void WinnerCheck01()
    {
        //o L
        int s1 = markedSpaces[0] + markedSpaces[1] + markedSpaces[2]; //horizontal oben
        int s2 = markedSpaces[3] + markedSpaces[4] + markedSpaces[5]; //horizontal mitte
        int s3 = markedSpaces[6] + markedSpaces[7] + markedSpaces[8]; //horizontal unten

        int s4 = markedSpaces[0] + markedSpaces[3] + markedSpaces[6]; //vertikal links
        int s5 = markedSpaces[1] + markedSpaces[4] + markedSpaces[7]; //vertikal mitte
        int s6 = markedSpaces[2] + markedSpaces[5] + markedSpaces[8]; //vertikal rechts

        int s7 = markedSpaces[0] + markedSpaces[4] + markedSpaces[8]; //diagonal oben links -> unten rechts
        int s8 = markedSpaces[2] + markedSpaces[4] + markedSpaces[6]; //diagonal oben rechts -> unten links


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



    public void TicTacToeButton02(int WhichNumber)
    {
        starButton.interactable = false;
        crossButton.interactable = false;
        tictactoeSpaces[WhichNumber].image.sprite = playIcons[whoTurn];
        tictactoeSpaces[WhichNumber].interactable = false;

        markedSpaces[WhichNumber] = whoTurn + 1;
        turnCount++;

        if (turnCount > 4)
        {
            WinnerCheck02();
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

    void WinnerCheck02()
    {
        //o M
        int s9 = markedSpaces[9] + markedSpaces[10] + markedSpaces[11]; //horizontal oben
        int s10 = markedSpaces[12] + markedSpaces[13] + markedSpaces[14]; //horizontal mitte
        int s11 = markedSpaces[15] + markedSpaces[16] + markedSpaces[17]; //horizontal unten

        int s12 = markedSpaces[9] + markedSpaces[12] + markedSpaces[15]; //vertikal links
        int s13 = markedSpaces[10] + markedSpaces[13] + markedSpaces[16]; //vertikal mitte
        int s14 = markedSpaces[11] + markedSpaces[14] + markedSpaces[17]; //vertikal rechts

        int s15 = markedSpaces[9] + markedSpaces[13] + markedSpaces[17]; //diagonal oben links -> unten rechts
        int s16 = markedSpaces[11] + markedSpaces[13] + markedSpaces[15]; //diagonal oben rechts -> unten links

        var solutions = new int[] { s9, s10, s11, s12, s13, s14, s15, s16, };

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



    public void TicTacToeButton03(int WhichNumber)
    {
        starButton.interactable = false;
        crossButton.interactable = false;
        tictactoeSpaces[WhichNumber].image.sprite = playIcons[whoTurn];
        tictactoeSpaces[WhichNumber].interactable = false;

        markedSpaces[WhichNumber] = whoTurn + 1;
        turnCount++;

        if (turnCount > 4)
        {
            WinnerCheck03();
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

    void WinnerCheck03()
    {
        //o R
        int s17 = markedSpaces[18] + markedSpaces[19] + markedSpaces[20]; //horizontal oben
        int s18 = markedSpaces[21] + markedSpaces[22] + markedSpaces[23]; //horizontal mitte
        int s19 = markedSpaces[24] + markedSpaces[25] + markedSpaces[26]; //horizontal unten

        int s20 = markedSpaces[18] + markedSpaces[21] + markedSpaces[24]; //vertikal links
        int s21 = markedSpaces[19] + markedSpaces[22] + markedSpaces[25]; //vertikal mitte
        int s22 = markedSpaces[20] + markedSpaces[23] + markedSpaces[26]; //vertikal rechts

        int s23 = markedSpaces[18] + markedSpaces[22] + markedSpaces[26]; //diagonal oben links -> unten rechts
        int s24 = markedSpaces[20] + markedSpaces[22] + markedSpaces[24]; //diagonal oben rechts -> unten links


        var solutions = new int[] { s17, s18, s19, s20, s21, s22, s23, s24, };

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



    public void TicTacToeButton04(int WhichNumber)
    {
        starButton.interactable = false;
        crossButton.interactable = false;
        tictactoeSpaces[WhichNumber].image.sprite = playIcons[whoTurn];
        tictactoeSpaces[WhichNumber].interactable = false;

        markedSpaces[WhichNumber] = whoTurn + 1;
        turnCount++;

        if (turnCount > 4)
        {
            WinnerCheck04();
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

    void WinnerCheck04()
    {
        //m L
        int s25 = markedSpaces[27] + markedSpaces[28] + markedSpaces[29]; //horizontal oben
        int s26 = markedSpaces[30] + markedSpaces[31] + markedSpaces[32]; //horizontal mitte
        int s27 = markedSpaces[33] + markedSpaces[34] + markedSpaces[35]; //horizontal unten

        int s28 = markedSpaces[27] + markedSpaces[30] + markedSpaces[33]; //vertikal links
        int s29 = markedSpaces[28] + markedSpaces[31] + markedSpaces[34]; //vertikal mitte
        int s30 = markedSpaces[29] + markedSpaces[32] + markedSpaces[35]; //vertikal rechts

        int s31 = markedSpaces[27] + markedSpaces[31] + markedSpaces[35]; //diagonal oben links -> unten rechts
        int s32 = markedSpaces[29] + markedSpaces[31] + markedSpaces[33]; //diagonal oben rechts -> unten links

        var solutions = new int[] { s25, s26, s27, s28, s29, s30, s31, s32, };

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



    public void TicTacToeButton05(int WhichNumber)
    {
        starButton.interactable = false;
        crossButton.interactable = false;
        tictactoeSpaces[WhichNumber].image.sprite = playIcons[whoTurn];
        tictactoeSpaces[WhichNumber].interactable = false;

        markedSpaces[WhichNumber] = whoTurn + 1;
        turnCount++;

        if (turnCount > 4)
        {
            WinnerCheck05();
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

    void WinnerCheck05()
    {
        //m M
        int s33 = markedSpaces[36] + markedSpaces[37] + markedSpaces[38]; //horizontal oben
        int s34 = markedSpaces[39] + markedSpaces[40] + markedSpaces[41]; //horizontal mitte
        int s35 = markedSpaces[42] + markedSpaces[43] + markedSpaces[44]; //horizontal unten

        int s36 = markedSpaces[36] + markedSpaces[39] + markedSpaces[42]; //vertikal links
        int s37 = markedSpaces[37] + markedSpaces[40] + markedSpaces[43]; //vertikal mitte
        int s38 = markedSpaces[38] + markedSpaces[41] + markedSpaces[44]; //vertikal rechts

        int s39 = markedSpaces[36] + markedSpaces[40] + markedSpaces[44]; //diagonal oben links -> unten rechts
        int s40 = markedSpaces[38] + markedSpaces[40] + markedSpaces[42]; //diagonal oben rechts -> unten links

        var solutions = new int[] { s33, s34, s35, s36, s37, s38, s39, s40, };

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



    public void TicTacToeButton06(int WhichNumber)
    {
        starButton.interactable = false;
        crossButton.interactable = false;
        tictactoeSpaces[WhichNumber].image.sprite = playIcons[whoTurn];
        tictactoeSpaces[WhichNumber].interactable = false;

        markedSpaces[WhichNumber] = whoTurn + 1;
        turnCount++;

        if (turnCount > 4)
        {
            WinnerCheck06();
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

    void WinnerCheck06()
    {
        //m R
        int s41 = markedSpaces[45] + markedSpaces[46] + markedSpaces[47]; //horizontal oben
        int s42 = markedSpaces[48] + markedSpaces[49] + markedSpaces[50]; //horizontal mitte
        int s43 = markedSpaces[51] + markedSpaces[52] + markedSpaces[53]; //horizontal unten

        int s44 = markedSpaces[45] + markedSpaces[48] + markedSpaces[51]; //vertikal links
        int s45 = markedSpaces[46] + markedSpaces[49] + markedSpaces[52]; //vertikal mitte
        int s46 = markedSpaces[47] + markedSpaces[50] + markedSpaces[53]; //vertikal rechts

        int s47 = markedSpaces[45] + markedSpaces[49] + markedSpaces[53]; //diagonal oben links -> unten rechts
        int s48 = markedSpaces[47] + markedSpaces[49] + markedSpaces[51]; //diagonal oben rechts -> unten links

        var solutions = new int[] { s41, s42, s43, s44, s45, s46, s47, s48, };

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



    public void TicTacToeButton07(int WhichNumber)
    {
        starButton.interactable = false;
        crossButton.interactable = false;
        tictactoeSpaces[WhichNumber].image.sprite = playIcons[whoTurn];
        tictactoeSpaces[WhichNumber].interactable = false;

        markedSpaces[WhichNumber] = whoTurn + 1;
        turnCount++;

        if (turnCount > 4)
        {
            WinnerCheck07();
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
    void WinnerCheck07()
    {
        //u L
        int s49 = markedSpaces[54] + markedSpaces[55] + markedSpaces[56]; //horizontal oben
        int s50 = markedSpaces[57] + markedSpaces[58] + markedSpaces[59]; //horizontal mitte
        int s51 = markedSpaces[60] + markedSpaces[61] + markedSpaces[62]; //horizontal unten

        int s52 = markedSpaces[54] + markedSpaces[57] + markedSpaces[60]; //vertikal links
        int s53 = markedSpaces[55] + markedSpaces[58] + markedSpaces[61]; //vertikal mitte
        int s54 = markedSpaces[56] + markedSpaces[59] + markedSpaces[62]; //vertikal rechts

        int s55 = markedSpaces[54] + markedSpaces[58] + markedSpaces[62]; //diagonal oben links -> unten rechts
        int s56 = markedSpaces[56] + markedSpaces[58] + markedSpaces[60]; //diagonal oben rechts -> unten links

        var solutions = new int[] { s49, s50, s51, s52, s53, s54, s55, s56, };

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



    public void TicTacToeButton08(int WhichNumber)
    {
        starButton.interactable = false;
        crossButton.interactable = false;
        tictactoeSpaces[WhichNumber].image.sprite = playIcons[whoTurn];
        tictactoeSpaces[WhichNumber].interactable = false;

        markedSpaces[WhichNumber] = whoTurn + 1;
        turnCount++;

        if (turnCount > 4)
        {
            WinnerCheck08();
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

    void WinnerCheck08()
    {
        //u M
        int s57 = markedSpaces[63] + markedSpaces[64] + markedSpaces[65]; //horizontal oben
        int s58 = markedSpaces[66] + markedSpaces[67] + markedSpaces[68]; //horizontal mitte
        int s59 = markedSpaces[69] + markedSpaces[70] + markedSpaces[71]; //horizontal unten

        int s60 = markedSpaces[63] + markedSpaces[66] + markedSpaces[69]; //vertikal links
        int s61 = markedSpaces[64] + markedSpaces[67] + markedSpaces[70]; //vertikal mitte
        int s62 = markedSpaces[65] + markedSpaces[68] + markedSpaces[71]; //vertikal rechts

        int s63 = markedSpaces[63] + markedSpaces[67] + markedSpaces[71]; //diagonal oben links -> unten rechts
        int s64 = markedSpaces[65] + markedSpaces[67] + markedSpaces[69]; //diagonal oben rechts -> unten links

        var solutions = new int[] { s57, s58, s59, s60, s61, s62, s63, s64, };

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



    public void TicTacToeButton09(int WhichNumber)
    {
        starButton.interactable = false;
        crossButton.interactable = false;
        tictactoeSpaces[WhichNumber].image.sprite = playIcons[whoTurn];
        tictactoeSpaces[WhichNumber].interactable = false;

        markedSpaces[WhichNumber] = whoTurn + 1;
        turnCount++;

        if (turnCount > 4)
        {
            WinnerCheck09();
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

    void WinnerCheck09()
    {
        //u R
        int s65 = markedSpaces[72] + markedSpaces[73] + markedSpaces[74]; //horizontal oben
        int s66 = markedSpaces[75] + markedSpaces[76] + markedSpaces[77]; //horizontal mitte
        int s67 = markedSpaces[78] + markedSpaces[79] + markedSpaces[80]; //horizontal unten

        int s68 = markedSpaces[72] + markedSpaces[75] + markedSpaces[78]; //vertikal links
        int s69 = markedSpaces[73] + markedSpaces[76] + markedSpaces[79]; //vertikal mitte
        int s70 = markedSpaces[74] + markedSpaces[77] + markedSpaces[80]; //vertikal rechts

        int s71 = markedSpaces[72] + markedSpaces[76] + markedSpaces[80]; //diagonal oben links -> unten rechts
        int s72 = markedSpaces[74] + markedSpaces[76] + markedSpaces[78]; //diagonal oben rechts -> unten links

        var solutions = new int[] { s65, s66, s67, s68, s69, s70, s71, s72, };

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

