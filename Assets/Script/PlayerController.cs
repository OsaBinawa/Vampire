using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float JumpImpulse = 10f;
    public float dashDistance = 5f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;
    public TrailRenderer trailRenderer;

    private Vector2 moveInput;
    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;

    private bool isDashing = false;
    private bool canDash = true;

    private TouchingDirection touchingDirection;
    private int maxJumps = 1;
    private int jumpCount = 0;
    private bool isMoving = false;
    public bool IsMoving
    {
        get
        {
            return isMoving;
        }

        private set
        {
            isMoving = value;
            anim.SetBool("IsMoving", value);
        }
    }

    public bool _isFacingRight = true;
    public bool IsFacingRight
    {
        get
        {
            return _isFacingRight;
        }
        private set
        {
            if (_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1);
            }
            _isFacingRight = value;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        touchingDirection = GetComponent<TouchingDirection>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 moveDirection = new Vector3(moveInput.x, 0f, 0f).normalized;
        transform.Translate(moveDirection * walkSpeed * Time.deltaTime);

        if (touchingDirection.IsGround)
        {
            jumpCount = 0;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        if(context.performed)
        {
            isMoving = true;
            anim.SetBool("IsMoving", true);
            SetFacingDirection(moveInput);
        }
        else
        {
            isMoving = false;
            anim.SetBool("IsMoving", false);
        }
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if (moveInput.x > 0 && !IsFacingRight)
        {
            IsFacingRight = true;
        }
        else if (moveInput.x < 0 && IsFacingRight)
        {
            IsFacingRight = false;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && jumpCount < maxJumps && !touchingDirection.IsOnwall)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpImpulse);
            jumpCount++;
            anim.SetTrigger("Jump");
            
        }
       
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed && canDash && !isDashing)
        {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        isDashing = true;
        canDash = false;

        trailRenderer.emitting = true;

        Vector3 dashEndPosition = transform.position + new Vector3(moveInput.x * dashDistance, 0f, 0f);
        float dashTime = 0f;

        while (dashTime < dashDuration)
        {
            float dashStep = dashDistance * (Time.deltaTime / dashDuration);
            transform.position = Vector3.MoveTowards(transform.position, dashEndPosition, dashStep);
            dashTime += Time.deltaTime;
            yield return null;
        }

        trailRenderer.emitting = false;

        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
