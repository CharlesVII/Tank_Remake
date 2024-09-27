using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;

public class TileGround : MonoBehaviour
{

    public Tilemap tilemap;
    public List<TileBase> tileToPlaces; 
    void Start()
    {
        setTileMap();
    }


    public void setTileMap()
    {
        int indexRangedom;
        for (int i = -100; i < 100; i++)
        {
            for (int j = -100; j < 100; j++)
            {
                {
                    indexRangedom = Random.Range(0, tileToPlaces.Count);
                    //Debug.Log(indexRangedom);
                    tilemap.SetTile(new Vector3Int(i, j, 0), tileToPlaces[indexRangedom]);
    
                }
            }
        }
    }
}
