﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemsController : MonoBehaviour {

    public LayerMask m_ItemsMask;
    public LayerMask m_AnchorMask;
    public float m_PickUpRadius;
    public float m_ThrowForce;

    public Transform m_PickUpHolder;

    Collider[] m_ItemsInRadius;

    Item m_ClosestItem;
    Anchor m_ClosestAnchor;

    Item m_PickedItem;
    bool m_HasItem {
        get {
            return m_PickedItem != null;
        }
    }

    private void Update() {

        FindClosesItem();

        if (m_HasItem) {
            if(m_PickedItem.m_IsPlaceable)
                FindClosestAnchor();
        }

        if (Input.GetButtonDown("PickUp")) {
            PickUpItem();
        }
        if (Input.GetKeyDown(KeyCode.F)) {
            ThrowItem();
        }
    }

    void FindClosesItem() {

        m_ClosestItem = null;
        m_ItemsInRadius = Physics.OverlapSphere(transform.position, m_PickUpRadius, m_ItemsMask);

        float minDst = float.MaxValue;
        foreach (var item in m_ItemsInRadius) {
            float sqrDist = Vector3.SqrMagnitude(transform.position - item.transform.position);

            if (sqrDist < minDst) {
                m_ClosestItem = item.GetComponent<Item>();
                minDst = sqrDist;
            }
        }
    }

   void FindClosestAnchor() {
        if (m_ClosestAnchor != null) {
            m_ClosestAnchor.SetHelperVisibility(false);
        }

        m_ClosestAnchor = null;
        Collider[] anchors = Physics.OverlapSphere(transform.position, m_PickUpRadius, m_AnchorMask);

        float minDst = float.MaxValue;
        foreach (var anchor in anchors) {
            float sqrDist = Vector3.SqrMagnitude(transform.position - anchor.transform.position);

            if (sqrDist < minDst) {
                Anchor actualAnchor = anchor.GetComponent<Anchor>();
                if (actualAnchor.m_IsAvaible) {
                    minDst = sqrDist;
                    m_ClosestAnchor = actualAnchor;
                }
            }
        }

        if (m_ClosestAnchor != null) {
            m_ClosestAnchor.SetHelperVisibility(true);
        }
    }

    void ThrowItem() {
        if (m_HasItem) {
            m_PickedItem.Throw(transform.forward, m_ThrowForce);
            m_PickedItem = null;
        }
    }

    void PickUpItem() {

        if (m_HasItem)
            return;

        m_ClosestItem.PickUp();

        m_ClosestItem.transform.parent = m_PickUpHolder;
        m_ClosestItem.transform.position = m_PickUpHolder.position;

        m_PickedItem = m_ClosestItem;
    }

    private void OnDrawGizmos() {
        if(m_ClosestItem != null) {
            Gizmos.color = Color.red;

            Gizmos.DrawLine(transform.position, m_ClosestItem.transform.position);
        }

        if(m_ClosestAnchor != null) {
            Gizmos.color = Color.green;

            Gizmos.DrawLine(transform.position, m_ClosestAnchor.transform.position);
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, m_PickUpRadius);
    }
}
