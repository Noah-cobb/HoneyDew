using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoJump : MonoBehaviour
{

    const int STANDING = 0;
    const int RUNNING = 1;
    const int CROUCHING = 2;
    const int OOF = 3;

    public Sprite Standing;
    public Sprite Running0;
    public Sprite Running1;
    public Sprite Crouching0;
    public Sprite Crouching1;
    public Sprite Oof;


    int animState;
    int subState;

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
        Time.timeScale = 0;
        groundCol = Ground.GetComponent<Collider2D>();
        dinoCol = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        jfs = 0;
        animState = 0;
        subState = 0;
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
