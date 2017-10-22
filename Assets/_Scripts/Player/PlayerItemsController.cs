using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemsController : MonoBehaviour {

    public System.Action<Item> OnItemThrow;
	public System.Action<Item> OnItemPickedUp;

    public LayerMask m_ItemsMask;
    public LayerMask m_AnchorMask;
    public float m_PickUpRadius;
    public float m_MinPickuUpRadius;
    public float m_ThrowForce;

    public Transform m_PickUpHolder;

    Collider[] m_ItemsInRadius;

    Item m_ClosestItem;
    Anchor m_ClosestAnchor;

    public PlayerInput m_PlayerInput;

    Player m_Player;

    Item m_PickedItem;
    bool m_HasItem {
        get {
            return m_PickedItem != null;
        }
    }

    private void Start() {
        m_Player = GetComponent<Player>();
        m_PlayerInput = m_Player.m_PlayerInput;

    }

    private void Update() {

        FindClosesItem();

        if (m_HasItem) {
            if (m_PickedItem.m_IsPlaceable) {
                FindClosestAnchor();

                if (Input.GetButtonDown(m_PlayerInput.itemUse)) {
					if (OnItemThrow != null)
						OnItemThrow(m_PickedItem);

					PlaceItem();
                }
            }
            else {
                if (Input.GetButtonDown(m_PlayerInput.itemUse)) {
					if (OnItemThrow != null)
						OnItemThrow(m_PickedItem);

					UseItem();
                }
            }
        }

        if (Input.GetButtonDown(m_PlayerInput.itemUse)) {
			if (OnItemPickedUp != null)
				OnItemPickedUp(m_PickedItem);

            PickUpItem();
        }
        if (Input.GetButtonDown(m_PlayerInput.itemThrow)) {
            if (OnItemThrow != null)
                OnItemThrow(m_PickedItem);

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
        //Collider[] anchors = Physics.OverlapSphere(transform.position + transform.forward * 2, m_PickUpRadius/2, m_AnchorMask);

        //float minDst = float.MaxValue;
        //foreach (var anchor in anchors) {
        //    float sqrDist = Vector3.SqrMagnitude(transform.position - anchor.transform.position);

        //    if (sqrDist < minDst && sqrDist > m_MinPickuUpRadius * m_MinPickuUpRadius) {
        //        Anchor actualAnchor = anchor.GetComponent<Anchor>();
        //        if (actualAnchor.m_IsAvaible && actualAnchor.player == m_Player.m_PlayerType) {
        //            minDst = sqrDist;
        //            m_ClosestAnchor = actualAnchor;
        //        }
        //    }
        //}

        RaycastHit hit;
        Debug.DrawRay(transform.position + Vector3.up / 2, transform.forward * m_MinPickuUpRadius, Color.red);

        if (Physics.Raycast(transform.position + Vector3.up /2 ,transform.forward, out hit, m_PickUpRadius, m_AnchorMask)) {
            Anchor anchor = hit.collider.GetComponent<Anchor>();
            if (anchor && anchor.m_IsAvaible) {
                m_ClosestAnchor = anchor;
            }
        }

        if (m_ClosestAnchor != null) {
            m_ClosestAnchor.SetHelperVisibility(true);
        }
    }

    void PlaceItem() {
        if (m_HasItem && m_ClosestAnchor != null) {
            m_PickedItem.PlaceBlock(m_ClosestAnchor);
            m_PickedItem = null;
            m_ClosestAnchor = null;
        }
    }

    void ThrowItem() {
        if (m_HasItem) {
            m_PickedItem.Throw(transform.forward, m_ThrowForce);
            m_PickedItem = null;
        }
    }

    void UseItem() {
        m_PickedItem.Use();
        m_PickedItem = null;
    }

    void PickUpItem() {

        if (!m_HasItem && m_ClosestItem != null && m_ClosestItem.CanBePicked) {

            m_ClosestItem.PickUp();

            m_ClosestItem.transform.parent = m_PickUpHolder;
            m_ClosestItem.transform.position = m_PickUpHolder.position;

            m_PickedItem = m_ClosestItem;
        }
    }

    private void OnDrawGizmos() {
        if (m_ClosestItem != null) {
            Gizmos.color = Color.red;

            Gizmos.DrawLine(transform.position, m_ClosestItem.transform.position);
        }

        if (m_ClosestAnchor != null) {
            Gizmos.color = Color.green;

            Gizmos.DrawLine(transform.position, m_ClosestAnchor.transform.position);
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, m_PickUpRadius);
    }
}
