using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MenuState {

	void Start(){
		Time.timeScale = 0;
		Time.fixedDeltaTime = 0;
	}

	public void SettingsGame(){
		MenuStateMachine.Instance.PushState<Settings> ();
	}
	public void Resume(){
		MenuStateMachine.Instance.PopState ();
		Time.timeScale = 1;
		Time.fixedDeltaTime = 0.02f;
	}
	public void GoToMenu(){
		SceneManager.LoadScene("Menu");
	}
	public void Restart(){
		SceneManager.LoadScene("Main");
		Time.timeScale = 1;
		Time.fixedDeltaTime = 0.02f;
	}
}
