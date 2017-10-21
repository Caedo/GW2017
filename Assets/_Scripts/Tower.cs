using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public PlayerType m_PlayerType;
    
    public void Initialize(PlayerType playerType) {
        m_PlayerType = playerType;
        foreach (var item in GetComponentsInChildren<Anchor>()) {
            item.SetPlayer(playerType);
        }
    }

}
