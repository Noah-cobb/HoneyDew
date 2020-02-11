using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{

    public static float Speed = 18;
    public float SpeedAddMult = 1;

    float speedAdd;
    Transform trans;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        speedAdd = (Random.value * 2 - 1) * SpeedAddMult;
    }

    // Update is called once per frame
    void Update()
    {
        trans.position += new Vector3((speedAdd - Speed) * Time.deltaTime, 0);
        if(trans.position.x < -22)
        {
            Destroy(gameObject);
        }
    }
}
