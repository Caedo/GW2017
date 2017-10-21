using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : Item {

    bool m_IsPlaced;

    Anchor[] m_Anchors;

    protected override void Awake() {
        base.Awake();

        m_Anchors = GetComponentsInChildren<Anchor>();
    }

    private void Start() {
        SetAnchorsAvaible(true);
    }

    public override void PlaceBlock(Anchor anchor) {
        transform.parent = anchor.transform;
        transform.position = anchor.transform.position;
        transform.rotation = anchor.transform.rotation;

        anchor.HasBlock = true;
        m_IsPlaced = true;
    }

    public override void Use() {
        throw new NotImplementedException();
    }

    public override void PickUp() {
        base.PickUp();

        SetAnchorsAvaible(false);
    }

    void SetAnchorsAvaible(bool avaible) {
        for (int i = 0; i < m_Anchors.Length; i++) {
            m_Anchors[i].m_IsAvaible = avaible;
        }
    }
}
