using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoController : MonoBehaviour {

    public PlayerInfo PlayerInfo;
    public Image selectionImage;
    public Transform[] buttons;

    public void OnNameEditEnd(string name) {
        PlayerInfo.m_Name = name;
    }

    public void SetSkinIndex(int index) {
        PlayerInfo.m_SkinIndex = index;
        selectionImage.transform.position = buttons[index].position;
    }
}
