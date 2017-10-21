using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInfo {
    public string m_Name;
    public int m_SkinIndex;
}

public class GameSettings : ScriptableObject {

    public List<PlayerInfo> m_Players;
}
