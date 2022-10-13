 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] Transform playerCamera = null;
    [SerializeField] public float mouseSensitivity = 3.5f;
    [SerializeField] float walkSpeed = 10f;
    [SerializeField] float sprintSpeed = 20f;
    [SerializeField] float gravity = -30f;
    [SerializeField] float jumpHeight = 3f;
    [SerializeField][Range(0f, .5f)] float moveSmoothTime = .3f;
    [SerializeField][Range(0f, .5f)] float mouseSmoothTime = .03f;

    [SerializeField] bool lockCursor = true;


    float cameraPitch = 0.0f;
    float velocityY = 0.0f;
    CharacterController controller = null;

    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMouseLook();
        UpdateMovement();
    }

    void UpdateMouseLook()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));   //Gets direction of mouse.

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        cameraPitch -= currentMouseDelta.y * mouseSensitivity;   //Non inverted camera look

        cameraPitch = Mathf.Clamp(cameraPitch, -75f, 55f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;   //Camera up and down

        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);   //Camera Left and right
    }

    void UpdateMovement()
    {
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));   //Gets direction from wasd.
        targetDir.Normalize();   //prevents speed boost from angled walk

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);   //Smooths tranistion

        if (controller.isGrounded)   //Gravity unless grounded.
        {
            velocityY = 0.0f;
        }

        if (controller.isGrounded && Input.GetButton("Jump"))   //Jump if shift is activated
        {
            velocityY = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocityY += gravity * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftShift))   //Sprint if left shift is active
        {
            Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * sprintSpeed + Vector3.up * velocityY;
            controller.Move(velocity * Time.deltaTime);
        }
        else
        {
            Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * walkSpeed + Vector3.up * velocityY;
            controller.Move(velocity * Time.deltaTime);
        }

        

        
    }
}
