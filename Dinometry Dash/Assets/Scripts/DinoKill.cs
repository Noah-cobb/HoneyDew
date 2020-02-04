using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DinoKill : MonoBehaviour
{

    int framesLeft;

    // Start is called before the first frame update
    void Start()
    {
        framesLeft = 120;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0)
        {
            framesLeft--;
            if (framesLeft < 1 && Input.GetKey("space"))
            {
                if (HighScoreHolder.highScore < Controller.score)
                {
                    HighScoreHolder.highScore = Controller.score;
                }
                SceneManager.LoadScene("MainScene");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == 8)
        {
            Time.timeScale = 0;
            
        }
    }
}
