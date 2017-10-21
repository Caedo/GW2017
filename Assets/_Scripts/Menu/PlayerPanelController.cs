using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPanelController : MenuState {

	public void Back(){
		MenuStateMachine.Instance.PushState<TitleScreenController> ();
	}
}
