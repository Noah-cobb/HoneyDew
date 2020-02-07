using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PterodactylFlap : MonoBehaviour
{
    public float Period;
    public Sprite[] sprites;

    int cur;
    float next;
    SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        next = Period;
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<PolygonCollider2D>().isTrigger = true;
        next -= Time.deltaTime;
        if(next < 0)
        {
            cur = 1 - cur;
            rend.sprite = sprites[cur];
            Destroy(GetComponent<PolygonCollider2D>());
            gameObject.AddComponent<PolygonCollider2D>();
            next = Period;
        }
    }
}
