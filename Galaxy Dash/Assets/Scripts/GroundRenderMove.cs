using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRenderMove : MonoBehaviour
{

    public float StartPos;
    public float EndPos;
    Transform trans;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        trans.position = new Vector2(trans.position.x - ObstacleMovement.Speed * Time.deltaTime, trans.position.y);
        if(trans.position.x < EndPos)
        {
            trans.position = new Vector2(trans.position.x + (StartPos - EndPos), trans.position.y);
        }
    }
}
