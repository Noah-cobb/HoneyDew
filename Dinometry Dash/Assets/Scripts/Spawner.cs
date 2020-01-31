﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject BigCactus1;
    public GameObject BigCactus2;
    public GameObject BigCactus3;
    public GameObject Pterodactyl;
    public GameObject SmallCactus1;
    public GameObject SmallCactus2;
    public GameObject SmallCactus3;

    float untilNext;

    // Start is called before the first frame update
    void Start()
    {
        untilNext = 0;
    }

    // Update is called once per frame
    void Update()
    {
        untilNext -= Time.deltaTime;
        if (untilNext <= 0) {
            untilNext = Random.Range(1, 3);
            GameObject obj = null;
            int id = (int)(Random.value * 7);
            switch (id)
            {
                case 0:
                    obj = BigCactus1;
                    break;
                case 1:
                    obj = BigCactus2;
                    break;
                case 2:
                    obj = BigCactus3;
                    break;
                case 3:
                    obj = SmallCactus1;
                    break;
                case 4:
                    obj = SmallCactus2;
                    break;
                case 5:
                    obj = SmallCactus3;
                    break;
                case 6:
                    obj = Pterodactyl;
                    break;
            }

            Instantiate(obj, new Vector2(10, obj.transform.localScale.y / 2 - 4), Quaternion.identity);
        }
    }
}