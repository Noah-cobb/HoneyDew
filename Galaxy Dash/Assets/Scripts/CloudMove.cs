using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{

    public float Speed;
    float para;


    Transform trans;

    // Start is called before the first frame update
    void Start()
    {
        para = Random.Range(3f, 10f);
        trans = GetComponent<Transform>();
        float scale = 10f / para;
        gameObject.transform.localScale = new Vector3(scale, scale, scale);
    }

    // Update is called once per frame
    void Update()
    {
        trans.position += new Vector3(Speed / para * Time.deltaTime * ObstacleMovement.Speed, 0);
        if (trans.position.x < -22)
        {
            Destroy(gameObject);
        }
    }
}
