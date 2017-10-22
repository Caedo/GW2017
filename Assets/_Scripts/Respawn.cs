using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

	private Collider Player;
	void OnTriggerEnter(Collider other){
		Player = other;
		Player.enabled = !Player.enabled;
		StartCoroutine (test ());
	}
	IEnumerator test(){

		yield return new WaitForSeconds (3);
		Player.enabled = !Player.enabled;
        Rigidbody rb = Player.GetComponent<Rigidbody>();
        rb.isKinematic = true;
		Player.gameObject.transform.position = new Vector3 (30f, 10f, 30f);
        rb.isKinematic = false;
    }
}
