using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Anchor : MonoBehaviour {

    public bool HasBlock { get; set; }

    private MeshRenderer m_MeshRenderer;



    public void SetHelperVisibility(bool visibility) {
        //m_HelperObject.SetActive(visibility);
    }
}
