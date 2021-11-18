using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    
    public static int[] score = new int[] {0, 0};

    public static string getWinner()
    {
        if(ScoreScript.score[0] > ScoreScript.score[1])
            return "Blue Player Win!";
        
        if(ScoreScript.score[0] < ScoreScript.score[1])
            return "Green Player Win!";    
        
        return "Tie!";
    }

    Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text =  string.Format("[ Blue Player {0} ] [ Green Player {1} ] ", ScoreScript.score[0], ScoreScript.score[1]);
    }
}
