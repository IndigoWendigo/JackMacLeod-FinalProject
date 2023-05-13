using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera sceneCamera;

    public Animator animator;

    public float moveSpeed;

    public Rigidbody2D rb;

    private Vector2 moveDirection;

    private Vector2 mousePosition;

    public WeaponScript weapon;

    private float fireRate = 0.5f;
    private float nextFire = 0f;

    // Update is called once per frame
    void Update()
    {
        // Processing Inputs
        ProcessMovements();
        AnimCheck();
    }

    void FixedUpdate()
    {
        // Physics Calculations
        Move();
    }

    void ProcessMovements()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if(Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            weapon.Fire();
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);

    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        // Rotate Player To Follow Mouse
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

    void AnimCheck()
    {
        if(Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }
}
