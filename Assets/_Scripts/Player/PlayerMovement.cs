using UnityEngine;



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
    //CharacterController controller;
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
        //controller = GetComponent<CharacterController>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start() {
        m_PlayerInput = GetComponent<Player>().m_PlayerInput;
    }

    void FixedUpdate() {
        m_PlayerInput = GetComponent<Player>().m_PlayerInput;

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
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, GetModifiedSmoothTime(turnSmoothTime));
        }

        targetSpeed = runSpeed * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, GetModifiedSmoothTime(speedSmoothTime));

        velocityY += Time.deltaTime * gravity;
        Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;

        //controller.Move(velocity * Time.deltaTime);
        rigidbody.MovePosition(velocity * Time.deltaTime + transform.position);
        currentSpeed = new Vector2(rigidbody.velocity.x, rigidbody.velocity.z).magnitude;

        if (IsGrounded()) {
            velocityY = 0;
        }
    }

    private void Jump() {
        if (IsGrounded()) {
            float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
            velocityY = jumpVelocity;
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
