using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    // Speed Variables
    [SerializeField] float jumpHeight = 20.0f;       // Player jump height as vertical speed

    private bool hasDoubleJump = false;             // Bool for if the player has their double jump

    private bool boxCastFeet {                      // Bool for the BoxCast created in the "IsGrounded" function and used in OnDrawGizmo

        get { return Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer); }

    }

    [SerializeField] private Rigidbody2D rigidbody; // Stores the rigidbody to apply the movement to
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Space]

    // BoxCast variables
    [SerializeField] private Vector2 boxSize;       // Field for the size of the BoxCast around the center of castDistance
    [SerializeField] private float castDistance;    // Field for the distance of the BoxCast from the center of the player
    [SerializeField] private LayerMask groundLayer; // Stores the LayerMask of the intended ground to check for

    void Start() {

        

    }

    void Update() {

        if (!GlobalVariables.isGameOver) {

            if (IsGrounded() && !Input.GetButton("Jump")) {

                hasDoubleJump = false;

            }

            if (Input.GetButtonDown("Jump")) {

                if (IsGrounded() || hasDoubleJump) {

                    rigidbody.velocity = new Vector2(0, jumpHeight);

                    hasDoubleJump = !hasDoubleJump;

                }

            }

            if (Input.GetAxis("Vertical") < 0) {

                transform.rotation = Quaternion.Euler(new Vector3(0,0,-90));

            } else {

                transform.rotation = Quaternion.Euler(new Vector3(0,0,0));

            }

        }

    }
    void OnDrawGizmos() {
        
        // Draws a wire cube around the position of boxCastFeet
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);

    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Obstacle") {

            spriteRenderer.color = UnityEngine.Color.red;
            GlobalVariables.isGameOver = true;
            SceneManager.LoadScene("Game Over");
        }

    }

    public bool IsGrounded() {      // Returns true or fase based on if the boxCastFeet is colliding with something

        if (boxCastFeet) {

            return true;

        } else {

            return false;

        }

    }

}
