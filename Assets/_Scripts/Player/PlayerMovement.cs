﻿using UnityEngine;



//[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour {

    public float runSpeed = 6;
    public float gravity = -12;
    public float jumpHeight = 1;
    public float jumpRayLength = 0.2f;
    [Range(0, 1)]
    public float airControlPercent;
    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    private float currentSpeed;
    private float velocityY;

    float targetSpeed = 0.001f;
    CharacterController controller;
    new Rigidbody rigidbody;

    PlayerInput m_PlayerInput;

    public float SpeedPercent {
        get {
            if (targetSpeed > 0.0000001f)
                return currentSpeed / targetSpeed;
            else
                return 0;
        }
    }

    void Awake() {
        controller = GetComponent<CharacterController>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start() {
        m_PlayerInput = GetComponent<Player>().m_PlayerInput;
    }

    void FixedUpdate() {

        Vector2 input = new Vector2(Input.GetAxisRaw(m_PlayerInput.horizontal), Input.GetAxisRaw(m_PlayerInput.vertical));
        Vector2 inputDir = input.normalized;
        Move(inputDir);


        if (Input.GetButtonDown(m_PlayerInput.jump)) {
            Jump();
        }

    }

    private void Move(Vector2 inputDir) {
        if (inputDir != Vector2.zero) {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;
            Vector3 euler = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, GetModifiedSmoothTime(turnSmoothTime));
            rigidbody.rotation = Quaternion.Euler(euler);
        }

        targetSpeed = runSpeed * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, GetModifiedSmoothTime(speedSmoothTime));

        //velocityY += Time.deltaTime * gravity;
        Vector3 velocity = transform.forward * currentSpeed;

        rigidbody.MovePosition(velocity * Time.deltaTime + transform.position);
        //currentSpeed = new Vector2(controller.velocity.x, controller.velocity.z).magnitude;
    }

    private void Jump() {
        if (IsGrounded()) {
            Debug.Log("JUMP");
            //float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
            //velocityY = jumpVelocity;
            rigidbody.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
        }
    }

    private float GetModifiedSmoothTime(float smoothTime) {
        if (IsGrounded()) {
            return smoothTime;
        }

        if (airControlPercent == 0) {
            return float.MaxValue;
        }
        return smoothTime / airControlPercent;
    }

    bool IsGrounded() {
        if(Physics.Raycast(transform.position, -transform.up, jumpRayLength, LayerMask.GetMask("Ground") )) {
            return true;
        }
        return false;
    }
}
