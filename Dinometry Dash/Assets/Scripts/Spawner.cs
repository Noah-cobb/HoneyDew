using System.Collections;
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
    public GameObject Cloud;

    float untilNext;

    // Start is called before the first frame update
    void Start()
    {
        untilNext = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Clouds
        if(Random.value < 0.003)
        {
            Instantiate(Cloud, new Vector2(Random.Range(22, 21f), Random.Range(-3f, 5f)), Quaternion.identity);
        }
        //Obstacles
        untilNext -= Time.deltaTime;
        if (untilNext <= 0) {
            untilNext = Random.Range(0.75f, 2);
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
            if (id < 6)
            {
                Instantiate(obj, new Vector2(ObstacleMovement.Speed / 2 + 22, -2), Quaternion.identity);
            }
            else
            {
                Instantiate(obj, new Vector2(22, -2 + Random.value * 4), Quaternion.identity);
            }
        }
    }
}
