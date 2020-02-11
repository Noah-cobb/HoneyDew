using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    public GameObject Dino;

    float state;

    void disappear()
    {
        gameObject.transform.localPosition = new Vector3(0, -10000, 0);
    }

    void appear()
    {
        gameObject.transform.localPosition = Dino.transform.position + new Vector3(0.8f, 0.2f, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        disappear();
    }


    // Update is called once per frame
    void Update()
    {
        if(Dino.GetComponent<DinoJump>().animState == DinoJump.JUMPING)
        {
            appear();
        }
        else
        {
            disappear();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 8)
        {
            Controller.score += 100;
            Destroy(col.gameObject);
        }
    }

}
