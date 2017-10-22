using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInput {
    public string horizontal;
    public string vertical;
    public string jump;
    public string itemThrow;
    public string itemUse;
}

public class Player : MonoBehaviour {

	public AudioClip[] audio;

    public PlayerType m_PlayerType;
    public string m_PlayerName;
    public PlayerInput m_PlayerInput;

    void SetupPlayerInput() {
         m_PlayerInput = new PlayerInput()
           {
                horizontal = m_PlayerType.ToString() + "horizontal",
                vertical = m_PlayerType.ToString() + "vertical",
                jump = m_PlayerType.ToString() + "jump",
                itemThrow = m_PlayerType.ToString() + "throw",
                itemUse = m_PlayerType.ToString() + "use"
            };

    }

    public void Initialize(PlayerInfo info) {
        m_PlayerName = info.m_Name;
        m_PlayerType = info.m_PlayerType;

        SetupPlayerInput();
    }
}
