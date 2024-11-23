using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;

public class ObjectController : MonoBehaviour {

    [SerializeField] float obstacleSpeed = -10.0f;
    [SerializeField] public string objectType;
    private Rigidbody2D rigidbody;

    void Awake() {

        

    }

    // Start is called before the first frame update
    void Start() {

        rigidbody = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update() {

        rigidbody.velocity = new Vector2(obstacleSpeed, 0);

    }

    void OnTriggerExit2D(Collider2D other) {

        if (other.tag == "Despawn") {

            Destroy(gameObject);

        }

    }
}
