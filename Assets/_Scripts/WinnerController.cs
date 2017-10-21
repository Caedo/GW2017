using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerController : MenuState {

	public Text timerLabel;

	void Start(){
		timerLabel.text = GameUIController.actualTime;
	}
}
