using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    CharacterInput characterInput;

    public float movementSpeed;
    public float jumpForce;

    Rigidbody mybody;

    public Transform groundCheck;

    public bool isGrounded;

    bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        characterInput = GetComponent<CharacterInput>();
        mybody = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical) * movementSpeed * Time.deltaTime;
        transform.Translate(moveDirection);

        isGrounded = Physics.CheckSphere(groundCheck.transform.position, 0.1f);

        if(Input.GetKeyDown(characterInput.jumpKey) && isGrounded)
        {
            canJump = !canJump;
        }
        
    }

    void FixedUpdate()
    {
        if (canJump)
        {
            mybody.AddForce(Vector3.up * jumpForce);
            canJump = !canJump;
        }
    }
}
