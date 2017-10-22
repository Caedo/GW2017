using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public PlayerType m_PlayerType;
    public string m_PlayerName;

	public void Initialize(PlayerInfo info) {
        m_PlayerName = info.m_Name;
        m_PlayerType = info.m_PlayerType;
    }
}
