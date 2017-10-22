using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinnerController : MenuState {

	public Text timerLabel;

	void Start(){
		timerLabel.text = GameUIController.actualTime;
	}
	public void GoToMenu(){
		SceneManager.LoadScene("Menu");
	}
}
