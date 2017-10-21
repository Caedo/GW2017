﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Item : MonoBehaviour {

    public bool m_IsPlaceable;

    protected new Rigidbody rigidbody;

    protected virtual void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }
    public virtual void PlaceBlock(Anchor anchor) { }
    public virtual void PickUp() {
        Debug.Log("LUL");
        rigidbody.useGravity = false;
        rigidbody.isKinematic = true;
        GetComponent<Collider>().enabled = false;

        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }

    public abstract void Use();
    public virtual void Throw(Vector3 direction, float force) {
        rigidbody.useGravity = true;
        rigidbody.isKinematic = false;
        GetComponent<Collider>().enabled = true;

        transform.parent = null;

        rigidbody.AddForce(direction * force, ForceMode.Impulse);
    }

}
