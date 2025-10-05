using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Transform firePoint;

    private PlayerShooting shooting;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        shooting = GetComponent<PlayerShooting>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0);
        movement.Normalize();
        transform.Translate(movement * speed * Time.deltaTime);

        Flip(horizontalInput);
    }

    void Flip(float horizontalInput)
    {
        if (horizontalInput < 0)
        {
            sr.flipX = true;
            shooting.shootDirection = -1;
        }
        else if (horizontalInput > 0)
        {
            sr.flipX = false;
            shooting.shootDirection = 1;
        }
    }
}
