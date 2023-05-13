using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f;
    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    public Animator myAnim;
    public int pointsForKill;
    AudioSource aS;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        health = maxHealth;
        target = GameObject.Find("Player").transform;
        myAnim = GetComponent<Animator>();
        aS = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            moveDirection = direction;
        }
    }

    private void FixedUpdate()
    {
        if(target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
            myAnim.Play("SkeletonRun");
        }
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if(health <= 0)
        {
            aS.Play();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            ScoreTextScript.instance.IncreaseScore(pointsForKill);
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
