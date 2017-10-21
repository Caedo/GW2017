using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Anchor : MonoBehaviour {

    public enum PlayerType
    {
        Player1,
        Player2,
        Player3,
        Player4
    };

    public bool HasBlock { get; set; }
    public bool m_IsAvaible = true;
    public PlayerType player = PlayerType.Player1;

    private MeshRenderer m_MeshRenderer;

    private void Awake() {
        m_MeshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start() {
        SetHelperVisibility(false);
    }

    public void SetHelperVisibility(bool visibility) {
        m_MeshRenderer.enabled = visibility;
    }

    public void SetPlayer(PlayerType p)
    {
        player = p;
    }
}
