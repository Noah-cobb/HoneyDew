using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DinoJump : MonoBehaviour
{

    const int STANDING = 0;
    const int RUNNING = 1;
    const int CROUCHING = 2;
    const int OOF = 3;
    
    public Sprite Standing;
    public Sprite[] Running;
    public Sprite[] Crouching;
    public Sprite Oof;

    public GameObject sword;

    int animState;
    float subState;

    public float JumpPower;
    public float DownPower;
    public int JumpFrames;

    public AudioClip[] jumpClips;
    private RandomContainer randomC;


    int jfs;

    bool changedAnim;

    public GameObject Ground;
    Collider2D groundCol;
    Collider2D dinoCol;
    Rigidbody2D rb;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        groundCol = Ground.GetComponent<Collider2D>();
        dinoCol = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        jfs = 0;
        setAnim(RUNNING);
        subState = 0;

        randomC = GetComponent<RandomContainer>();
        
    }

    void doAnim()
    {
        switch(animState)
        {
            case STANDING:
                sr.sprite = Standing;
                subState = 0;
                break;
            case RUNNING:
                sr.sprite = Running[(int) subState];
                subState = (subState + Time.deltaTime * 8) % Running.Length;
                break;
            case CROUCHING:
                sr.sprite = Crouching[(int) subState];
                subState = (subState + Time.deltaTime * 8) % Crouching.Length;
                break;
            case OOF:
                sr.sprite = Oof;
                subState = 0;
                break;
        }
    }

    void setAnim(int state)
    {
        if (!changedAnim && animState != state)
        {
            changedAnim = true;
            animState = state;
            doAnim();
            Destroy(GetComponent<PolygonCollider2D>());
            gameObject.AddComponent<PolygonCollider2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        changedAnim = false;
        if (Time.timeScale > 0)
        {
            dinoCol = GetComponent<Collider2D>();
            if (dinoCol.IsTouching(groundCol))
            {
                if (Input.GetKey("down"))
                {
                    setAnim(CROUCHING);
                }
                else
                {
                    jfs = JumpFrames;
                    setAnim(RUNNING);
                }
            }
            //jump
            if (jfs > 0 && Input.GetKey("space"))
            {
                jfs--;
                rb.velocity = new Vector2(0, JumpPower);
                if(animState != STANDING)
                {
                    //GetComponent<AudioSource>().Play();
                    randomC.clips = jumpClips;
                    randomC.PlaySound();
                    sword.GetComponent<Sword>().slash();
                    
                }
                setAnim(STANDING);
            }
            else
            {
                jfs = 0;
            }
            if (Input.GetKey("down"))
            {
                rb.velocity = new Vector2(0, -DownPower);
            }
            doAnim();
        }
        else
        {
            setAnim(OOF);
        }
    }
}
