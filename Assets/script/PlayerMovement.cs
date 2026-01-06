using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float moveSpeed;

    public float rotatedSpeed;

    public float jumpSpeed = 2f;

    private float gravity = -80f;

    private Vector3 velocity;

    public Transform cameraTransform;


    private void Update()
    {
        Movement();
        Rotate();

    }

    void Movement()
    {
        float inputAD;
        float inputWS;
        Vector3 inputWASD;
        inputAD = Input.GetAxis("Horizontal");
        inputWS = Input.GetAxis("Vertical");
        inputWASD = new Vector3(inputAD, 0, inputWS);
        Vector3 moveCameraDirection = cameraTransform.TransformDirection(inputWASD);
        moveCameraDirection.y = 0;


        if (controller.isGrounded)
        {
            if (velocity.y < 0)
            velocity.y = -2f;
            if (Input.GetButtonDown("Jump"))
            {
               velocity.y = Mathf.Sqrt(jumpSpeed * -2f * gravity);
            }
        }
        velocity.y += gravity * Time.deltaTime;
        
        Vector3 final = moveCameraDirection * moveSpeed + velocity;
        controller.Move(final * Time.deltaTime);
    }

    void Rotate()
    {
        float inputMouseHorizontal;
        inputMouseHorizontal = Input.GetAxis("Mouse X");
        transform.eulerAngles += new Vector3(0, inputMouseHorizontal * rotatedSpeed * Time.deltaTime, 0);
    }
}
