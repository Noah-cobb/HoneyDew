using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{

    public Text ScoreText;
    public float SpeedIncrease;
    public AudioClip DinoScore;
    AudioSource source;
    int target = 500;

    public static float score;

    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.clip = DinoScore;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ObstacleMovement.Speed += SpeedIncrease * Time.deltaTime;
        score += ObstacleMovement.Speed * Time.deltaTime;
        ScoreText.text = "HighScore: " + (int) HighScoreHolder.highScore + "\nScore: " + (int) score;

        if (score >= target)
        {
            target += 500;
            source.Play();
        }
    }
}
