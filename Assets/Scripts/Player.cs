using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D rig;
    public float Speed;
    public float JumpForce;

    void Start() {
        rig = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        rig.velocity = new Vector2(Speed, rig.velocity.y);
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            rig.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }
}
