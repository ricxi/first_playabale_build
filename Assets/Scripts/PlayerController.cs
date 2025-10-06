using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 9f;
    [SerializeField] private float sprintSpeed = 20f;

    [SerializeField] private Transform teleportTarget;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private PolygonCollider2D pc;
    public Vector2 originalColliderOffset;
    public Vector2 flippedColliderOffset;

    private PlayerShooting shooting;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        pc = GetComponent<PolygonCollider2D>();
        shooting = GetComponent<PlayerShooting>();
        originalColliderOffset = pc.offset;
        flippedColliderOffset = new Vector2(-originalColliderOffset.x, originalColliderOffset.y);
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


        Flip(horizontalInput);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleport") && teleportTarget != null)
        {
            transform.position = teleportTarget.position;
        }
    }

    void Flip(float horizontalInput)
    {
        if (horizontalInput < 0)
        {
            sr.flipX = true;
            pc.offset = flippedColliderOffset;
            shooting.shootDirection = -1;
        }
        else if (horizontalInput > 0)
        {
            sr.flipX = false;
            pc.offset = originalColliderOffset;
            shooting.shootDirection = 1;
        }
    }
}
