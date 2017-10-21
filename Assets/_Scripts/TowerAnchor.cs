using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAnchor : MonoBehaviour {

    List<Vector3> towerPosition = new List<Vector3>
    {
        new Vector3(10.0f, 0.0f, 10.0f),
        new Vector3(-10.0f, 0.0f, -10.0f),
        new Vector3(10.0f, 0.0f, -10.0f),
        new Vector3(-10.0f, 0.0f, 10.0f),
    };
    public Transform tower;
    public int playerNumber;

	// Use this for initialization
	void Start () {
		for(int i = 0; i<playerNumber; i++)
        {
            Instantiate(tower, towerPosition[i], Quaternion.identity);     
        }
    }
	
}
