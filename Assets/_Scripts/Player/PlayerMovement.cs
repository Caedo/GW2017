using UnityEngine;



//[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour {

    public LayerMask groundMask;
    public float runSpeed = 6;
    public float jumpHeight = 6;
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
    new Rigidbody rigidbody;

    PlayerInput m_PlayerInput;
	BoxCollider collider;


    public float SpeedPercent {
        get {
            if (targetSpeed > 0.0000001f)
                return currentSpeed / targetSpeed;
            else
                return 0;
        }
    }

    void Awake() {
		collider = GetComponent<BoxCollider>();
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

    public bool IsGrounded() {
		var extents = collider.bounds.extents;

		Vector3 magic = new Vector3(0.0f, 0.05f, 0.0f);
		Vector3 first = new Vector3(extents.x, 0.0f, extents.z);
		Vector3 second = new Vector3(extents.x, 0.0f, -extents.z);
		Vector3 third = new Vector3(-extents.x, 0.0f, extents.z);
		Vector3 fourth = new Vector3(-extents.x, 0.0f, -extents.z);


		if (
			Physics.Raycast(transform.position + magic + first, -transform.up, jumpRayLength, groundMask) ||
			Physics.Raycast(transform.position + magic + second, -transform.up, jumpRayLength, groundMask) ||
			Physics.Raycast(transform.position + magic + third, -transform.up, jumpRayLength, groundMask) ||
			Physics.Raycast(transform.position + magic + fourth, -transform.up, jumpRayLength, groundMask)
			) {
            return true;
        }
        return false;
    }
}
