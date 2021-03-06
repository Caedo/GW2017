﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour {
    public bool isButton = true; 
    public bool leftJoystick = true; 
    public string buttonName;
    private Vector3 startPos;
    private Transform thisTransform;
    private MeshRenderer mr;

	// Use this for initialization
	void Start () {
        thisTransform = transform;
        startPos = thisTransform.position;
        mr = thisTransform.GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(isButton)
        {
            mr.enabled = Input.GetButton(buttonName);
        }
        else
        {
            if(leftJoystick)
            {
                Vector3 inputDirection = Vector3.zero;
                inputDirection.x = Input.GetAxis("LeftJoystickHorizontal");
                inputDirection.y = Input.GetAxis("LeftJoystickVertical");
                thisTransform.position = startPos + inputDirection;

            }
            else
            {
                Vector3 inputDirection = Vector3.zero;
                inputDirection.x = Input.GetAxis("RightJoystickHorizontal");
                inputDirection.y = Input.GetAxis("RightJoystickVertical");
                thisTransform.position = startPos + inputDirection;
            }
        }
	}
}
