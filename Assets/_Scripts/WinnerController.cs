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
		SceneManager.LoadScene("Menu");
	}
	public void Again(){
		SceneManager.LoadScene("Main");
		Time.timeScale = 1;
		Time.fixedDeltaTime = 0.02f;
	}
}
