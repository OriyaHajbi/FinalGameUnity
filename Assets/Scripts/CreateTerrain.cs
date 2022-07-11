using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTerrain : MonoBehaviour
{

    Terrain tr = Terrain.activeTerrain;
    private int width, height;
    private float[,] heightMap;

    private void Awake()
    {
        width = (int)tr.terrainData.size.x;
        height = (int)tr.terrainData.size.y;

        heightMap = new float[height, width];
        setHeight();


        tr.terrainData.SetHeights(0, 0, heightMap);
    }

    void setHeight()
    {
        int i, j;
        for (i = 0; i < height; i++)
            for (j = 0; j < width; j++)
                heightMap[i, j] = i/(float) height;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
