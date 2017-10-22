using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CameraController : MonoBehaviour {

    public Transform m_CameraLookTransform;

    Transform[] m_PlayersTransform;

    private void Start() {
        m_PlayersTransform = FindObjectsOfType<Player>().Select(p => p.transform).ToArray();
    }

    private void Update() {
        Vector3 avaragePosition = Vector3.zero;
        foreach (var item in m_PlayersTransform) {
            avaragePosition += item.position;
        }

        avaragePosition /= m_PlayersTransform.Length;

        m_CameraLookTransform.position = avaragePosition;
    }
}
