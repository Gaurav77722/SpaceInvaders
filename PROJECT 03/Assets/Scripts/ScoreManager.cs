using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int points;
    public TMP_Text score;
    private int highScore;
    private string highScoreKey = "key";

    private void Start()
    {
        highScore = PlayerPrefs.GetInt(highScoreKey,0);
        score.SetText("Score: " + "000" + points + "  HighScore: " + highScore);
    }

    public void scoreIncEnemy1()
    {
        points = points + 10;
        
    }
    
    public void scoreIncEnemy2()
    {
        points = points + 20;
        
    }
    
    public void scoreIncEnemy3()
    {
        points = points + 30;
        
    }
    public void scoreIncEnemy4()
    {
        points = points + 100;
        
    }
    

    public void setScore()
    {
        if(points>highScore){
            PlayerPrefs.SetInt(highScoreKey, points);
            PlayerPrefs.Save();
        }
        
        if (points < 100)
        {
            score.SetText("Score: " + "00" + points + "  HighScore: " + highScore);
        }
        else if (points > 100)
        {
            score.SetText("Score: " + "0" + points + "  HighScore: " + highScore);
        }
    }
}
