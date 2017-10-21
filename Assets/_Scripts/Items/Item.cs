using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Item : MonoBehaviour {

    public bool m_IsPlaceable;

    protected new Rigidbody rigidbody;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }

    public virtual void PickUp() {
        rigidbody.useGravity = false;
        rigidbody.isKinematic = true;
        GetComponent<Collider>().enabled = false;

        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }

    public abstract void Use();
    public virtual void Throw(Vector3 direction, float force) {
        rigidbody.AddForce(direction * force, ForceMode.Impulse);
    }

}
