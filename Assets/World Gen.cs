using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LazyFloodFill();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    bool isValid(int[,] map, int mapLength, int mapWidth, int x, int y) {
        if (x < 0 || x >= mapLength || y < 0 || y >= mapWidth)
            return false;
        return true;
    }

    void LazyFloodFill()
    {
        double chance = 100;
        double decay = 0.9995;

        //Create map *To be changed with plane* 
        int[,] map = new int[256, 256];

        int mapWidth = map.GetLength(0);
        int mapLength = map.GetLength(1);


        //Create Queue 
        List<Vector2Int> queue = new List<Vector2Int>();

        int x = Random.Range(0, map.Length);
        int y = Random.Range(0, map.Length);


        //Add random point from map to the Queue
        queue.Add(new Vector2Int(x,y));

        //Set the point on the map to filled
        map[x, y] = 1;

        while (queue.Count > 0) {
            Vector2Int currentPosition = new Vector2Int();
            currentPosition = queue[queue.Count - 1];

            queue.RemoveAt(queue.Count - 1);

            int posX = currentPosition.x;
            int posY = currentPosition.y;

            if ((Random.Range(1, 100) <= chance)) {
                if (isValid(map, mapWidth, mapLength, posX + 1, posY)) {
                    map[posX + 1, posY] = 1;
                    queue.Add(new Vector2Int(posX + 1, posY));
                }
                if (isValid(map, mapWidth, mapLength, posX - 1, posY)) {
                    map[posX - 1, posY] = 1;
                    queue.Add(new Vector2Int(posX - 1, posY));
                }
                if (isValid(map, mapWidth, mapLength, posX, posY + 1)) {
                    map[posX, posY + 1] = 1;
                    queue.Add(new Vector2Int(posX, posY + 1));
                }
                if (isValid(map, mapWidth, mapLength, posX, posY - 1)) {
                    map[posX, posY - 1] = 1;
                    queue.Add(new Vector2Int(posX, posY - 1));
                }
            }
            chance = chance * decay;
        }

    for (int i = 0; i < map.Length; i++)
    {
        for (int j = 0; j < mapWidth; j++)
        {
            Debug.Log(map[i, j] + " ");
        }
    }
}
}
