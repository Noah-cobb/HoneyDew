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

    // Start is called before the first frame update
    void Start()
    {
        disappear();
        state = 0;
    }

    public void slash()
    {
        state = 0.25f;
    }

    // Update is called once per frame
    void Update()
    {
        if(state <= 0)
        {
            disappear();
        }
        else
        {
            state -= Time.deltaTime;
            float rot = (0.25f - state) * 360;
            gameObject.transform.localPosition = new Vector2(
                Mathf.Sin(state * Mathf.PI * 2) * 1.33f + 0.70f + Dino.transform.position.x,
                Mathf.Cos(state * Mathf.PI * 2) * 1.33f - 0.15f + Dino.transform.position.y);
            gameObject.transform.rotation = Quaternion.Euler(0, 0, rot);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 8)
        {
            Destroy(col.gameObject);
        }
    }

}
