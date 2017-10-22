using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlockSpawner : MonoBehaviour {

    public float spawnTimeMin = 0.0f;
    public float spawnTimeMax = 1.0f;
    public float specialSpawnTimeMin = 0.0f;
    public float specialSpawnTimeMax = 0.0f;
    public Transform blockPrefab;
    public Transform sword;
    public Transform bomb;
    public Transform lama;
    public float areaSize = 2.0f;
    public int blockQuantity = 1;
    public int specialBlockQuantity = 1;

    float timeToSpawn = 1.0f;
    float timeToSpawnSpecial = 1.0f;

    List<Transform> specialItem;

	// Use this for initialization
	void Start () {
        specialItem = new List<Transform>
        {
            sword,
            bomb,
            lama
        };
	}
	
	// Update is called once per frame
	void Update () {
        timeToSpawn -= Time.deltaTime;
        timeToSpawnSpecial -= Time.deltaTime;

	    if(timeToSpawn <= 0)
        {
            for(int i = 0; i < blockQuantity; i++)
            {
                Vector3 position = new Vector3(Random.Range(-areaSize, areaSize), 0, Random.Range(-areaSize, areaSize)) + transform.position;
                Instantiate(blockPrefab, position, Quaternion.identity);
            }
            timeToSpawn = Random.Range(spawnTimeMin, spawnTimeMax);
        }

        if(timeToSpawnSpecial <= 0)
        {
            for(int i = 0; i < specialBlockQuantity; i++)
            {
                int index = Random.Range(0, 3);
                Vector3 position = new Vector3(Random.Range(-areaSize, areaSize), 0, Random.Range(-areaSize, areaSize)) + transform.position;
                Instantiate(specialItem[index], position, Quaternion.identity);
            }
            timeToSpawnSpecial = Random.Range(specialSpawnTimeMin, specialSpawnTimeMax);
        }
        
	}

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(transform.position, Vector3.one * areaSize);
    }
}
