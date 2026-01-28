using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int playerSpeed = 5;
    private SpriteRenderer dogSprite;
    private void Awake()
    {
        dogSprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void Update()
    {
        if(Keyboard.current.rightArrowKey.isPressed && transform.position.x < 8.15)
        {
            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
            dogSprite.flipX = false;
        }
        if(Keyboard.current.leftArrowKey.isPressed && transform.position.x > -8.25)
        {
            transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
            dogSprite.flipX = true;
        }
    }
}
