using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Anchor : MonoBehaviour {

    public bool HasBlock { get; set; }

    private MeshRenderer m_MeshRenderer;

    private void Awake() {
        m_MeshRenderer = GetComponent<MeshRenderer>();
    }

    public void SetHelperVisibility(bool visibility) {
        m_MeshRenderer.enabled = visibility;
    }
}
