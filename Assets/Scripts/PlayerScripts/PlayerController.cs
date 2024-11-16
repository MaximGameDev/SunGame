using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Speed Variables
    private float speed = 12.0f;            // Player movement speed
    private float jumpHeight = 20.0f;       // Player jump height as vertical speed

    private bool hasDoubleJump = false;             // Bool for if the player has their double jump

    private bool boxCastFeet {

        get { return Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer); }

    }               // Bool for the BoxCast created in the "IsGrounded" function and used in OnDrawGizmo

    [SerializeField] private Rigidbody2D rigidbody; // Stores the rigidbody to apply the movement to

    [Space]

    // BoxCast variables
    [SerializeField] private Vector2 boxSize;       // Field for the size of the BoxCast around the center of castDistance
    [SerializeField] private float castDistance;    // Field for the distance of the BoxCast from the center of the player
    [SerializeField] private LayerMask groundLayer; // Stores the LayerMask of the intended ground to check for

    void Start() {

        

    }

    void Update() {

        if (IsGrounded() && !Input.GetButton("Jump")) {

            hasDoubleJump = false;

        }

        if (Input.GetButtonDown("Jump")) {

            if (IsGrounded() || hasDoubleJump) {

                rigidbody.velocity = new Vector2(0, jumpHeight);

                hasDoubleJump = !hasDoubleJump;

            }

        }

    }

    void FixedUpdate() {

        

    }

    void OnDrawGizmos() {
        
        // Draws a wire cube around the position of boxCastFeet
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);

    }

    public bool IsGrounded() {

        if (boxCastFeet) {

            return true;

        } else {

            return false;

        }

    }

}
