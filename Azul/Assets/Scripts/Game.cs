using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

class Tile
{
    private GameObject prefab;

    public Tile(int i, int j, Sprite color)
    {

    }
}

//class Fabric
//{
//    private GameObject[] tiles;

//    public void fill(int i)
//    {
//        for (int j = 0; j < 4; j++)
//        {
//            tiles[j] = Instantiate(tile, tile_draw_v3(i, j), Quaternion.Euler(0, 0, 0));
//            tiles[j].GetComponent<SpriteRenderer>().sprite = colors[rand.Next(5)];
//        }
//    }
//}

public class Game : MonoBehaviour
{
    public GameObject factory_prefab, tile;
    public Sprite[] colors;
    private GameObject[] fabrics;
    private GameObject[,] fabrics_tiles;
    private System.Random rand;

    void Start()
    {
        rand = new System.Random();
        fabrics = new GameObject[5];
        fabrics_tiles = new GameObject[5, 4];
        for (int i = 0; i < 5; i++)
        {
            fabrics[i] = Instantiate(factory_prefab, fabric_draw_v3(i), Quaternion.Euler(0, 0, 0));
            fabric_fill(i);
        }
    }

    void fabric_fill(int i)
    {
        for (int j = 0; j < 4; j++)
        {
            fabrics_tiles[i, j] = Instantiate(tile, tile_draw_v3(i, j), Quaternion.Euler(0, 0, 0));
            fabrics_tiles[i, j].GetComponent<SpriteRenderer>().sprite = colors[rand.Next(5)];
        }
    }

    Vector3 fabric_draw_v3(int i)
    {
        switch (i)
        {
            case 0: return new Vector3(-3f, 0.7f, -1f);
            case 1: return new Vector3(-3f, 3.7f, -1f);
            case 2: return new Vector3(0f, 3.7f, -1f);
            case 3: return new Vector3(3f, 3.7f, -1f);
            case 4: return new Vector3(3f, 0.7f, -1f);
            default: return new Vector3(0f, 0f, -1f);
        }
    }

    Vector3 tile_draw_v3(int i, int j)
    {
        var result = fabrics[i].GetComponent<Transform>().position;
        float x = result.x, y = result.y, delta = 0.35f;
        switch (j)
        {
            case 0: x -= delta; y += delta; break;
            case 1: x += delta; y += delta; break;
            case 2: x -= delta; y -= delta; break;
            case 3: x += delta; y -= delta; break;
        }
        result = new Vector3(x, y, -2f);
        return result;
    }
}
