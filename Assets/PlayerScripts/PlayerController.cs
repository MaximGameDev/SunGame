using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float speed = 12.0f;

    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private Transform followCam;

    void Start() {

        

    }

    void Update() {

        followCam.position = transform.position;

    }

    private void FixedUpdate() {

        rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);

    }

}
