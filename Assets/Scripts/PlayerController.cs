using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private float speed = 5f; 

    void Start() 
    { 
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }



    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0);
        movement.Normalize();
        transform.Translate(movement * speed * Time.deltaTime);

        FlipSprite(horizontalInput);
    } 

    void FlipSprite(float horizontalInput)
    {
        if (horizontalInput < 0)
            sr.flipX = true;
        else if (horizontalInput > 0)
            sr.flipX = false;
    }
} 