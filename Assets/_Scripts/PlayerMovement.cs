using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float jump;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float moveY = jump;
        bool isJump = Input.GetButton("Jump");
        
        if(isJump)
        {
            moveY = jump;
        }
        else
        {
            moveY = 0.0f;
        }

        Vector3 movement = new Vector3(moveHorizontal, moveY, moveVertical);


        rb.AddForce(movement * speed);
    }

}
