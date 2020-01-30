using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoJump : MonoBehaviour
{
    public float JumpPower;
    public float DownPower;
    public int JumpFrames;

    int jfs;

    public GameObject Ground;
    Collider2D groundCol;
    Collider2D dinoCol;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        groundCol = Ground.GetComponent<Collider2D>();
        dinoCol = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        jfs = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(dinoCol.IsTouching(groundCol))
        {
            jfs = JumpFrames;
        }
        if(jfs > 0 && Input.GetKey("space"))
        {
            jfs--;
            rb.velocity = new Vector2(0, JumpPower);
        } else
        {
            jfs = 0;
        }
        if(Input.GetKey("down"))
        {
            rb.velocity = new Vector2(0, -DownPower);
        }
    }
}
