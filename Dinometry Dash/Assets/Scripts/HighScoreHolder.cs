using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreHolder : MonoBehaviour
{

    public static float highScore = 0;
    static int amt = 0;

    // Start is called before the first frame update
    void Start()
    {
        amt++;
        if (amt == 1)
        {
            DontDestroyOnLoad(this);
        }
        else
        {
            amt--;
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
