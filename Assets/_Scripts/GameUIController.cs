using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MenuState {

    public Text timerLabel;

    public static string actualTime;

    public float time;

    public void PauseMenu() {
        MenuStateMachine.Instance.PushState<PauseController>();
    }
    void Update() {


        time += Time.deltaTime;

        var minutes = time / 60; //Divide the guiTime by sixty to get the minutes.
        var seconds = time % 60;//Use the euclidean division for the seconds.
                                //var fraction = (time * 100) % 100;

        //update the label value
        timerLabel.text = actualTime = string.Format("{0:00} : {1:00}", minutes, seconds);

        //else
        if (Input.GetButtonDown("Cancel"))
            PauseMenu();


    }
}
