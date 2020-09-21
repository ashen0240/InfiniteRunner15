using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreTracker : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    

    // Update is called once per frame
    void Update()
    {
        
        if (player.position.y < 0)
        {
          
        }
        else if (player.position.z > 50)
        {
            scoreText.text = (((player.position.z-1) / 10 - 5) / 2).ToString("0");
        }
        else
        {
            scoreText.text = "0";
        }

    }

    public string GetScore()
    {
        print("test");
        return scoreText.text;
    }

    public void SetScore(string s)
    {
        scoreText.text = s;
    }
}
