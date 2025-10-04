using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private float speedX = 5; 
    [SerializeField] private Transform cameraTransform; 
    private float startPositionX; 
    private float spriteWidth;

    void Start()
    {
        // cameraTransform = Camera.main.transform; 
        startPositionX = transform.position.x;  
        spriteWidth = GetComponent<SpriteRenderer>().sprite.bounds.size.x;       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float relativeDistanceX = cameraTransform.transform.position.x * speedX; 
        transform.position = new Vector3(startPositionX + relativeDistanceX, transform.position.y, transform.position.z); 

        float relativeCameraPositionX = cameraTransform.transform.position.x - relativeDistanceX; 
        if (relativeCameraPositionX > startPositionX + spriteWidth) 
        { 
            startPositionX += spriteWidth; 
        } 
        else if (relativeCameraPositionX < startPositionX - spriteWidth) 
        { 
            startPositionX -= spriteWidth; 
        }
    }
}
