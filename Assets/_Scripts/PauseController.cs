using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MenuState {

	public void SettingsGame(){
		MenuStateMachine.Instance.PushState<Settings> ();
	}
	public void Resume(){
		MenuStateMachine.Instance.PopState ();
	}
	public void GoToMenu(){
		SceneManager.LoadScene("Menu");
	}
}
