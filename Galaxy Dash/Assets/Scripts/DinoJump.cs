using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DinoJump : MonoBehaviour
{

    const int STANDING = 0;
    const int RUNNING = 1;
    public const int JUMPING = 2;
    const int OOF = 3;
    public AudioClip DinoJumpp;
    AudioSource source;

    public Sprite Standing;
    public Sprite[] Running;
    public Sprite[] Jumping;
    public Sprite Oof;

    public GameObject sword;

    public int animState;
    float subState;

    public float JumpPower;
    public float DownPower;
    public int JumpFrames;

   


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

        source = gameObject.AddComponent<AudioSource>();

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
                subState = (subState + Time.deltaTime * 24) % Running.Length;
                break;
            case JUMPING:
                sr.sprite = Jumping[(int) subState];
                updateCollider();
                if (subState < Jumping.Length - 1)
                {
                    subState = (subState + Time.deltaTime * 24);
                }
                break;
            case OOF:
                sr.sprite = Oof;
                subState = 0;
                break;
        }
    }

    void updateCollider()
    {
        if (!changedAnim)
        {
            Destroy(GetComponent<PolygonCollider2D>());
            gameObject.AddComponent<PolygonCollider2D>();
            changedAnim = true;
        }
    }

    void setAnim(int state)
    {
        if (animState != state)
        {
            updateCollider();
            animState = state;
            doAnim();
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
                jfs = JumpFrames;
                setAnim(RUNNING);
            }
            //jump
            if (jfs > 0 && Input.GetKey("space"))
            {
                jfs--;
                rb.velocity = new Vector2(0, JumpPower);
                if(animState == RUNNING)
                {
                    animState = JUMPING;
                    source.clip = DinoJumpp;
                    source.Play();
                    subState = 0;
                }
                
                setAnim(JUMPING);
            }
            else
            {
                if (animState != RUNNING && rb.velocity.y < 0)
                {
                    setAnim(STANDING);
                    jfs = 0;
                }
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
