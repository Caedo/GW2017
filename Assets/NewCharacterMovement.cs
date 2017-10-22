using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class NewCharacterMovement : MonoBehaviour {

    public float speedMultiplier;
    new Rigidbody rigidbody;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        float horizontal = Input.GetAxis("Player1horizontal");
        float vertical = Input.GetAxis("Player1vertical");

        Vector3 newVelocity = new Vector3(horizontal, 0, vertical).normalized * speedMultiplier;

        rigidbody.MovePosition(rigidbody.position + newVelocity * Time.fixedDeltaTime);
    }
}
