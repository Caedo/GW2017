using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemsController : MonoBehaviour {

    public LayerMask m_ItemsMask;
    public float m_PickUpRadius;

    public Transform m_PickUpHolder;

    Collider[] m_ItemsInRadius;

    Item m_ClosestItem;

    bool m_HasItem;

    private void Update() {

        m_ItemsInRadius = Physics.OverlapSphere(transform.position, m_PickUpRadius, m_ItemsMask);
        FindClosesItem();

        if (Input.GetButtonDown("PickUp")) {
            PickUpItem();
        }
    }

    void FindClosesItem() {
        m_ClosestItem = null;

        float minDst = float.MaxValue;
        foreach (var item in m_ItemsInRadius) {
            float sqrDist = Vector3.SqrMagnitude(transform.position - item.transform.position);

            if (sqrDist < minDst) {
                m_ClosestItem = item.GetComponent<Item>();
                minDst = sqrDist;
            }
        }
    }

    void PickUpItem() {

        if (m_ClosestItem == null || m_HasItem)
            return;

        m_ClosestItem.PickUp();

        m_ClosestItem.transform.parent = m_PickUpHolder;
        m_ClosestItem.transform.position = m_PickUpHolder.position;
    }

    private void OnDrawGizmos() {
        if(m_ClosestItem != null) {
            Gizmos.color = Color.red;

            Gizmos.DrawLine(transform.position, m_ClosestItem.transform.position);
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, m_PickUpRadius);
    }
}
