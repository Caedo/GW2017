using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinnerController : MenuState {

	public Text timerLabel;
	public Text nickNameWinner;

	void Start(){
		timerLabel.text = GameUIController.actualTime;

		Time.timeScale = 0;
		Time.fixedDeltaTime = 0;
	}
	public void GoToMenu(){
		Time.timeScale = 1;
		Time.fixedDeltaTime = 0.02f;
		SceneManager.LoadScene("Menu");
	}
	public void Again(){
		Time.timeScale = 1;
		Time.fixedDeltaTime = 0.02f;
		SceneManager.LoadScene("Main");
	}
}
