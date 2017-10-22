using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobletController : MonoBehaviour {

    public static System.Action<Player> OnGameEnds;

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Player player = other.GetComponent<Player>();

            if (OnGameEnds != null) {
                OnGameEnds(player);
            }
        }
    }
}
