using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource src;
    private CapsuleCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;// the ground layer for raycast

    private float dirX = 0f;
    [SerializeField] public float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling }// using enum to change the player states by its index

    [SerializeField] private AudioClip jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        src = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        // dirX = Dirction X
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
       

        // GetButtonDown method connect with Unity input Manager.
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            src.clip = jumpSoundEffect;
            src.Play();
        }

        
    }
    private void FixedUpdate()
    {
        UpdateAnimationState();
    }
    private void UpdateAnimationState()
    {
        MovementState state;

        if(rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        else if (Mathf.Abs(dirX) > 0f && IsGrounded())
        {
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }
        // Flip Sprite
        if (dirX > 0f)
        {
            if(transform.localScale.x < 0)
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, 1);
        }
        else if (dirX < 0f)
        {
            if (transform.localScale.x > 0)
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1);
        }


        anim.SetInteger("state", (int)state);
            
    }

    private bool IsGrounded()//check is grounded, then jump. 
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
