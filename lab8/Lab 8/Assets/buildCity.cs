using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildCity : MonoBehaviour
{
    public GameObject[] buildings;
    public GameObject cloud;
    public int mapWidth = 200;
    public int mapHeight = 200;
    float buildingFootprint = 1.3f;

    void Start()
    {
        float seed = Random.Range(0, 100);
        for(int h = 0; h < mapHeight; h++)
        {
            for(int w = 0; w < mapWidth; w++)
            {
                float y = (int)(Mathf.PerlinNoise(w / 10.0f + seed, h / 10.0f + seed + 20) * 30);
                if(y < 8)
                    y = 0;
                else if(y > 13 && y < 17)
                    y = 10;
                else if(y > 20 && y < 23)
                    y = 20;
                else if(y > 25)
                    y = 30;
                else
                    y = -1;
                if (y != -1)
                {
                    int result = (int)(Mathf.PerlinNoise(w / 10.0f + seed, h / 10.0f + seed) * 10);
                    Vector3 pos = new Vector3(w * buildingFootprint, y, h * buildingFootprint);
                    if (result < 2)
                        Instantiate(buildings[0], pos, Quaternion.identity);
                    else if (result < 4)
                        Instantiate(buildings[1], pos, Quaternion.identity);
                    else if (result < 6)
                        Instantiate(buildings[2], pos, Quaternion.identity);
                    else if (result < 8)
                        Instantiate(buildings[3], pos, Quaternion.identity);
                    else if (result < 10)
                        Instantiate(buildings[4], pos, Quaternion.identity);
                    Instantiate(cloud, pos, Quaternion.identity);
                }
            }
        }
    }
}
