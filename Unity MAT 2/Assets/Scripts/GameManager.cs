using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject winnerPanel;
    public Button restartButton;
    public ScoreController scoreController;

    private float roundTime = 30f; 
    private float remainingTime;
    private bool roundEnded = false;
    private bool winnerDeclared = false; 

    private void Start()
    {
        remainingTime = roundTime;
        UpdateTimerText();
        winnerPanel.SetActive(false);
        restartButton.onClick.AddListener(RestartRound);
    }

    private void Update()
    {
        if (!roundEnded)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerText();

            if (remainingTime <= 0)
            {
                EndRound();
            }
        }
        else if (!winnerDeclared)
        {
            
            string winner = DetermineWinner();
            winnerPanel.transform.Find("Winner").GetComponent<TextMeshProUGUI>().text = "Winner: " + winner;
            winnerPanel.SetActive(true);
            winnerDeclared = true;
        }
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);
        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }

    private void EndRound()
    {
        Time.timeScale = 0;
        roundEnded = true;
    }

    private string DetermineWinner()
    {
        if (scoreController.p1score > scoreController.p2score)
        { return "Player 1"; }
        else { return "Player 2"; }
    }

    public void RestartRound()
    {
        
        remainingTime = roundTime;
        UpdateTimerText();
        winnerPanel.SetActive(false);

        
        roundEnded = false;
        winnerDeclared = false;
        Time.timeScale = 1;
        scoreController.p1score = 0;
        scoreController.p2score = 0;
    }
}




