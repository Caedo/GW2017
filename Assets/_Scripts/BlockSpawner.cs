﻿using UnityEngine;

public class BlockSpawner : MonoBehaviour {

    public float spawnTimeMin = 0.0f;
    public float spawnTimeMax = 1.0f;
    public Transform block;
    public float areaSize = 2.0f;
    public int blockQuantity = 1;

    float timeToSpawn = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeToSpawn -= Time.deltaTime;

	    if(timeToSpawn <= 0)
        {
            for(int i = 0; i < blockQuantity; i++)
            {
                Vector3 position = new Vector3(Random.Range(-areaSize, areaSize), transform.position.y, Random.Range(-areaSize, areaSize));
                Instantiate(block, position, Quaternion.identity);
            }
            timeToSpawn = Random.Range(spawnTimeMin, spawnTimeMax);
        }
        
	}
}
