using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ObjectDespawn : MonoBehaviour {

    [SerializeField] float obstacleSpeed = -10.0f;
    private Rigidbody2D rigidbody;

    void Awake() {

        rigidbody = gameObject.GetComponent<Rigidbody2D>();

    }

    // Start is called before the first frame update
    void Start() {
        
        

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
