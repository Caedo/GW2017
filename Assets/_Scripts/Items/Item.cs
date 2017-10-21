using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour {

    public bool m_IsPlaceable;

    public abstract void Use();

}
