using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    GameObject player;
    Rigidbody2D playerRigidbody2D;

    CircleCollider2D circleCollider;
    const float colliderOffset = 0.5f;

    float attackDuration = 0.25f;

    int attackDamage;

    bool isAttacking;



    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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

        Debug.Log("Attack");
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
