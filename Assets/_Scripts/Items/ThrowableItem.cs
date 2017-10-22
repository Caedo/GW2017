using System;
using UnityEngine;

public class ThrowableItem : Item
{
    bool m_IsPlaced;
    
    public override bool CanBePicked
    {
        get
        {
            return !m_IsPlaced;
        }

        set
        {
            base.CanBePicked = value;
        }
    }

    protected override void Awake()
    {
        base.Awake();
    }

    public override void Use()
    {

    }

    public override void PickUp()
    {
        base.PickUp();
    }
}

