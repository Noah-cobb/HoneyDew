using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{

    public static float Speed = 5;

    Transform trans;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        trans.position += new Vector3(-Speed * Time.deltaTime, 0);
        if(trans.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
