using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D characterRigidbody;
    SpriteRenderer characterSprite;
    
    private void Start()
    {
        animator = GetComponent<Animator>();

        characterRigidbody = GetComponentInParent<Rigidbody2D>();

        characterSprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (characterRigidbody.velocity.magnitude != 0)
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }

        if (characterRigidbody.velocity.x > 0)
        {
            characterSprite.flipX = true;
        }
        else if (characterRigidbody.velocity.x < 0)
        {
            characterSprite.flipX = false;
        }
    }


}
