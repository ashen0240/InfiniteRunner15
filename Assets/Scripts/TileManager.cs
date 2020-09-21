using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    public GameObject[] tilePrefabs;
    public GameObject[] objectPrefabs;

    public float distance;      //lenght of 1 tile
    public float initialLoc;    //Starting point for next tile
    public int numTiles;        //number of tiles at a time
    public int lastSpawned = -1;
    public Transform player;

    int count = 6; //for the first few tiles with no obstacles
    float bounceBug = 0;

    public List<GameObject> activeTiles = new List<GameObject>();
    public List<GameObject> activeObjects = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < numTiles; i++)
        {
            bool ob = false;
            if (i > 5)
            {
                ob = true;
            }
            if (lastSpawned == tilePrefabs.Length - 1)
            {
                lastSpawned = -1;
            }
            SpawnTile(lastSpawned+1,ob);
            lastSpawned++;
        }

    }

    // Update is called once per frame
    void Update()
    {


        if (player.position.z+((numTiles-4.5)*distance) > initialLoc)
        {
            if (lastSpawned == tilePrefabs.Length - 1)
            {
                lastSpawned = -1;
            }
            SpawnTile(lastSpawned + 1, true);
            lastSpawned++;

            if (count == 0)
            {
                DeleteTile(true);
            }
            else
            {
                DeleteTile(false);
                count--;
            }
        }
    }

    public void SpawnTile(int tileIndex, bool ob)
    {
        bounceBug += 0.015F;
        GameObject a = Instantiate(tilePrefabs[tileIndex], new Vector3(0, 0-bounceBug, initialLoc), transform.rotation);
        activeTiles.Add(a);

        if (ob)
        {
            int loca = Random.Range(-6, 6);
            GameObject b = Instantiate(objectPrefabs[Random.Range(0, objectPrefabs.Length-1)], new Vector3(loca, 1-bounceBug+.03f, initialLoc-distance + Random.Range(1, 9)), Quaternion.Euler(0, Random.Range(0, 360), 0));
            int locb = Random.Range(-6, 6);
            while (!(locb > loca + 2) && !(locb < loca - 2))
            {
                locb = Random.Range(-6, 6);
            }
            GameObject c = Instantiate(objectPrefabs[Random.Range(0, objectPrefabs.Length - 1)], new Vector3(locb, 1-bounceBug+.03f, initialLoc-distance + Random.Range(1, 9)), Quaternion.Euler(0, Random.Range(0, 360), 0));
            activeObjects.Add(b);
            activeObjects.Add(c);
        }
        
        initialLoc += distance;
    }

    public void DeleteTile(bool ob)
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
        
        if (ob)
        {
            Destroy(activeObjects[0]);
            activeObjects.RemoveAt(0);
            Destroy(activeObjects[0]);
            activeObjects.RemoveAt(0);
        }
    }
}