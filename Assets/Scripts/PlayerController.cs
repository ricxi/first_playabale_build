using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 9f;
    [SerializeField] private float sprintSpeed = 20f;

    [SerializeField] private Transform teleportTarget;
    private bool facingRight = false;

    private PlayerShooting shooting;

    void Start()
    {
        shooting = GetComponent<PlayerShooting>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0);
        movement.Normalize();
        transform.Translate(movement * currentSpeed * Time.deltaTime);

        if (horizontalInput > 0 && facingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && !facingRight)
        {
            Flip();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleport") && teleportTarget != null)
        {
            transform.position = teleportTarget.position;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
