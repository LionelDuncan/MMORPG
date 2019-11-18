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

    Animation anim;

    public float extraSpeed;


    // Start is called before the first frame update
    void Start()
    {
        characterInput = GetComponent<CharacterInput>();
        mybody = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;

        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Input.GetKey(characterInput.sprintKey))
        {
            extraSpeed = 2f;
        }
        else
        {
            extraSpeed = 1f;
        }

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical) * movementSpeed * Time.deltaTime * extraSpeed;

        transform.Translate(moveDirection);

        Debug.Log(isGrounded);

        walkAnimation(moveDirection);

        isGrounded = mybody.position.y == 0.0f;

        if (!isGrounded)
        {
            anim.CrossFade("Jump1");
        }

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

    void walkAnimation(Vector3 moveDirection)
    {
        if (isGrounded)
        {
            if (moveDirection == new Vector3(0, 0, 0))
            {
                anim.CrossFade("Idle1");
            }

            else if (moveDirection.z > 0.0f && moveDirection.z < 0.15f)
            {
                anim.CrossFade("Walk1");
            }

            else if (moveDirection.z > 0.15f)
            {
                anim.CrossFade("Run1");
            }

            else if (moveDirection.z < 0.0f)
            {
                anim.CrossFade("RunBack1");
            }
        }

    }
}
