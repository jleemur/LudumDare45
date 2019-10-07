using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myRigidBody;

    private Animator myAnimator;

    [SerializeField]
    private float movementSpeed;

    private bool slideInput;

    private bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();

    }

    private void Update()
    {
        HandleInput();
    }

    // FixedUpdate is called based on timeStep
    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleInput()
    {
        slideInput = Input.GetKey(KeyCode.LeftControl);
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");

        myRigidBody.velocity = new Vector2(horizontal * movementSpeed, myRigidBody.velocity.y);
        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));

        Slide();
        FlipSprite(horizontal);
    }

    private void FlipSprite(float horizontal)
    {
        bool doChangeDirections = horizontal > 0 && !facingRight || horizontal < 0 && facingRight;
        if (doChangeDirections)
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }

    }

    private void Slide()
    {
        bool isPlayerSliding = this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Player_Slide");
        if (slideInput && !isPlayerSliding)
        {
            myAnimator.SetBool("slide", true);
        }
        else if (!slideInput)
        {
            myAnimator.SetBool("slide", false);
        }
    }
}
