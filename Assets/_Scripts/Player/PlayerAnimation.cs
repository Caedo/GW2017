using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    Animator animator;

    PlayerMovement playerMovement;
    PlayerItemsController playerItemsController;

    private void Awake() {
        animator = GetComponentInChildren<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerItemsController = GetComponent<PlayerItemsController>();

        playerItemsController.OnItemThrow += OnItemThrow;
    }

    // Update is called once per frame
    void Update () {
        animator.SetFloat("speedPercent", playerMovement.SpeedPercent, .1f, Time.deltaTime);
    }

    void OnItemThrow(Item item) {
        animator.SetTrigger("throw");
    }
}
