using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : Item {

    bool m_IsPlaced;
    bool m_CanBePlaced;

    List<Anchor> m_Anchors = new List<Anchor>();
    
    public void PlaceBlock(Anchor anchor) {
        transform.parent = anchor.transform;
        transform.position = anchor.transform.position;

        anchor.HasBlock = true;
    }

    public override void Use() {
        throw new NotImplementedException();
    }
}
