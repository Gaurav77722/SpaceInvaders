using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int points;
    public TMP_Text score;
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
    

    public void setScore()
    {
        if (points < 100)
        {
            score.SetText("Score: " + "00" + points + "  HighScore: ");
        }
        else if (points > 100)
        {
            score.SetText("Score: " + "0" + points + "  HighScore: ");
        }
    }
}
