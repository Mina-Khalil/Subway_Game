using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private float zSpawn = 0;
    private float tileLength = 49.15f;
    public int numberOfTiles = 5;
    public Transform PlayerTransform;
    private List<GameObject> activeTiles = new List<GameObject>();
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
            {
                SpawTile(0);
            }
            else
            {
                SpawTile(Random.Range(1, tilePrefabs.Length));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerTransform.position.z -165 > zSpawn - (numberOfTiles * tileLength) )
        {
            SpawTile(Random.Range(0, tilePrefabs.Length));
             DeletTile();
        }
    }
    // create the tiles
    public void SpawTile(int TileIndex)
    {
        GameObject Go = Instantiate(tilePrefabs[TileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(Go);
        zSpawn += tileLength;
    }

public void DeletTile()
    {
    Destroy(activeTiles[0]);
    activeTiles.RemoveAt(0);
    }
}
