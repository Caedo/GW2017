using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class PlayerPanelController : MenuState {

	public void Back(){
		MenuStateMachine.Instance.PopState ();
	}

    public void StartGame() {
        PlayerInfoController[] playerInfos = GetComponentsInChildren<PlayerInfoController>();

        GameSettings gameSettings = ScriptableObject.CreateInstance<GameSettings>();
        gameSettings.m_Players = playerInfos.Select(i => i.PlayerInfo).ToList();

        GameSettings.SelectedGameSettings = gameSettings;

        SceneManager.LoadScene("Main");
    }
}
