using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D characterRigidbody;
    private SpriteRenderer characterSprite;

    private const string runningParameterName = "Running";


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
            animator.SetBool(runningParameterName, true);
        }
        else
        {
            animator.SetBool(runningParameterName, false);
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
