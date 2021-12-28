using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour {

    private Rigidbody2D rig;
    public float speed;
    void Start() {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);
    }

    void FixedUpdate() {
        rig.velocity = Vector2.left * speed;
    }
}
