using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb; 
    [SerializeField] private float speed = 5f; 

    void Start() 
    { 
        rb = GetComponent<Rigidbody2D>(); 
    } 

 

    void FixedUpdate() 
    { 
        float x = Input.GetAxis("Horizontal"); 
        float y = Input.GetAxis("Vertical"); 
        Vector3 movement = new Vector3 (x, y, 0); 
        movement.Normalize(); 
        transform.Translate(movement * speed * Time.deltaTime); 
    } 
} 