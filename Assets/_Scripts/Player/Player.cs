using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public PlayerType m_PlayerType;
    public string m_Name;

	public void Initialize(PlayerInfo info) {
        m_Name = info.m_Name;
        m_PlayerType = info.m_PlayerType;
    }
}
