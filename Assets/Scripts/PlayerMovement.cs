using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variable for speed of the player
    public float speed;

    // Variable for rigidbody movement
    private Rigidbody2D rigidBody;

    // Vector for how much players position changes
    private Vector3 changeInPosition;

    // Variable to access the players animations
    private Animator playerAnimations;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimations = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Every frame resets how much the player has changed
        changeInPosition = Vector3.zero;
        changeInPosition.x = Input.GetAxis("Horizontal");
        changeInPosition.y = Input.GetAxis("Vertical");
        UpdateAnimationAndMove();
    }

    void UpdateAnimationAndMove()
    {
        if (changeInPosition != Vector3.zero)
        {
            MoveCharacter();
            playerAnimations.SetFloat("moveX", changeInPosition.x);
            playerAnimations.SetFloat("moveY", changeInPosition.y);
            playerAnimations.SetBool("moving", true);

        }
        else
        {
            playerAnimations.SetBool("moving", false);
        }
    }
    void MoveCharacter()
    {
        rigidBody.MovePosition(transform.position + changeInPosition * speed * Time.deltaTime);
    }
}
