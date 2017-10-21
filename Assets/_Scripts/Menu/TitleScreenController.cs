using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenController : MenuState {

	public void QuitGame(){
		Application.Quit ();
	}
	public void PlayGame(){
		MenuStateMachine.Instance.PushState<PlayerPanelController> ();
	}
	public void Credits(){
		MenuStateMachine.Instance.PushState<CreditsController> ();
	}
	public void SettingsGame(){
		MenuStateMachine.Instance.PushState<Settings> ();
	}
}
