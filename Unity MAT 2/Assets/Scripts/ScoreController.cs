using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Player1score;
    [SerializeField] TextMeshProUGUI Player2score;

    

    public int p1score=0;
    public int p2score=0;
    
    private void Start()
    {
        RefreshUI();
    }

   

    public void IncreaseScoreP1(int increment)
    {
        p1score += increment;
        RefreshUI();
    }

    public void IncreaseScoreP2(int increment)
    {
        p2score += increment;
        RefreshUI();
    }

    private void RefreshUI()
    {
        Player1score.text = "P1 Score : " + p1score;
        Player2score.text = "P2 Score : " + p2score;
    }
}