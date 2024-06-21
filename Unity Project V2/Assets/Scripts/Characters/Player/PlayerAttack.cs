using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D playerRigidbody2D;

    private CircleCollider2D circleCollider;
    private const float colliderOffset = 0.5f;

    private float attackDuration = 0.25f;

    private int attackDamage;

    private bool isAttacking;



    private void Start()
    {
        player = gameObject;
        playerRigidbody2D = player.GetComponent<Rigidbody2D>();

        circleCollider = player.GetComponentInChildren<CircleCollider2D>();
        circleCollider.enabled = false;
    }

    private void Update()
    {
        if (playerRigidbody2D.velocity.magnitude > 0.5)
        {
            if (playerRigidbody2D.velocity.x > 0)
            {
                circleCollider.offset = new Vector2(colliderOffset, 0);
            }
            else if (playerRigidbody2D.velocity.x < 0)
            {
                circleCollider.offset = new Vector2(-colliderOffset, 0);
            }

            if (playerRigidbody2D.velocity.y > 0)
            {
                circleCollider.offset = new Vector2(0, colliderOffset);
            }
            else if (playerRigidbody2D.velocity.y < 0)
            {
                circleCollider.offset = new Vector2(0, -colliderOffset);
            }
        }
    }


    public void BaseAttack(int damage)
    {
        attackDamage = damage;
        if (!isAttacking)
        {
            StartCoroutine(Attacking());
        }
    }

    public IEnumerator Attacking()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.slash, 5.0f);


        isAttacking = true;
        circleCollider.enabled = true;

        yield return new WaitForSeconds(attackDuration);

        isAttacking = false;
        circleCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Stats>() != null)
        {
            collision.GetComponent<Stats>().TakeDamage(attackDamage);
        }
    }

}
