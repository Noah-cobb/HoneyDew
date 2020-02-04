using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndShower : MonoBehaviour
{

    Transform trans;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        trans.position = new Vector3(0, -1000, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0)
        {
            trans.position = new Vector3(0, 0, 0);
        }
    }
}
