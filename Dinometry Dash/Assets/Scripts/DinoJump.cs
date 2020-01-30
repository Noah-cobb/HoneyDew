using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoJump : MonoBehaviour
{

    public GameObject Ground;
    Collider2D groundCol;
    Collider2D dinoCol;

    // Start is called before the first frame update
    void Start()
    {
        groundCol = Ground.GetComponent<Collider2D>();
        dinoCol = this.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
