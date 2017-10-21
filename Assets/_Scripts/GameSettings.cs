using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInfo {
    public string m_Name;
    public PlayerType m_PlayerType;
    public int m_SkinIndex;
}

[CreateAssetMenu(menuName = "GameSettings/Settings")]
public class GameSettings : ScriptableObject {

    public static GameSettings SelectedGameSettings;

    public List<PlayerInfo> m_Players;
    public int PlayersCount { get { return m_Players.Count; } }
}
