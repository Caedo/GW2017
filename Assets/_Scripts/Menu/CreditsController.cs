﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsController : MenuState {

	public void Back(){
		MenuStateMachine.Instance.PopState ();
	}
}
