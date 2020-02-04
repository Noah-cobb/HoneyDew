using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{

    public Text ScoreText;
    public float SpeedIncrease;

    public static float score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ObstacleMovement.Speed += SpeedIncrease * Time.deltaTime;
        score += ObstacleMovement.Speed * Time.deltaTime;
        ScoreText.text = "Score: " + (int) score + "\nHigh Score: " + (int) HighScoreHolder.highScore;
    }
}
