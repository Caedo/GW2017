using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoController : MonoBehaviour {

	public PlayerInfo PlayerInfo { get; set; }

    public void OnNameEditEnd(string name) {
        PlayerInfo.m_Name = name;
    }

    public void SetSkinIndex(int index) {
        PlayerInfo.m_SkinIndex = index;
    }
}
