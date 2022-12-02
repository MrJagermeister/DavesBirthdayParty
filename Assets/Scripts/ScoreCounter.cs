using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreCounter : MonoBehaviour
{
    private Transform player;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreGiftText;

    public static int giftScore;
    public static int currentScore;
    public static int maxScore;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        currentScore = Mathf.RoundToInt(-player.position.y);
        
        if (currentScore > maxScore)
        {
            maxScore = currentScore;
        }

        scoreText.text = "Meters fallen: "+ maxScore.ToString();
        scoreGiftText.text = giftScore.ToString();
    }
}
