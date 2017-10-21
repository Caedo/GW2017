using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType {
    Player1,
    Player2,
    Player3,
    Player4
};

public class GameManager : MonoBehaviour {

    public Player m_PlayerPrefab;
    public List<Tower> m_Towers = new List<Tower>();
    public List<Transform> m_SpawnPoints = new List<Transform>();

    GameSettings m_GameSettings;

    private void Start() {
        m_GameSettings = GameSettings.SelectedGameSettings;

        for (int i = 0; i < m_GameSettings.PlayersCount; i++) {
            m_Towers[i].gameObject.SetActive(true);
            m_Towers[i].Initialize((PlayerType)i);

            Player player = Instantiate(m_PlayerPrefab, m_SpawnPoints[i].position, m_SpawnPoints[i].rotation);
            player.Initialize(m_GameSettings.m_Players[i]);
        }
    }
}
