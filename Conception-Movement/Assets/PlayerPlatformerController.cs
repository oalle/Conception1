using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{
    public float maxSpeed = 7;

    public AudioClip saut;

    public AudioClip marche;

    protected AudioSource source;

    public float jumpTakeOffSpeed = 7;

    private int numberJump =0;

    private SpriteRenderer spriteRenderer;

    private Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if(grounded)
        {
            if (move.magnitude > minMoveDist)
            {
                if (!source.isPlaying)
                    source.PlayOneShot(marche);
            }
            else
            {
               // source.Stop();
            }
        }
        else
        {
            //source.Stop(); ;
        }


        if (Input.GetButtonDown("Jump")&&grounded)
        {
            source.PlayOneShot(saut);
            velocity.y = jumpTakeOffSpeed;
            numberJump = 1;
        }
        else if(Input.GetButtonDown("Jump")&&numberJump<2)
        {
            source.PlayOneShot(saut);
            velocity.y = jumpTakeOffSpeed;
            numberJump++;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y >0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }
        else if (grounded)
        {
            numberJump = 0;
        }

        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));

        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        animator.SetBool("grounded", grounded);

        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }
}
