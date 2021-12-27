using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D rig;
    private bool isJumping;
    public float Speed;
    public float JumpForce;
    public Animator anim;

    void Start() {
        rig = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        rig.velocity = new Vector2(Speed, rig.velocity.y);
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping) {
            rig.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
            isJumping = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.layer == 6) {
            anim.SetBool("isJumping", false);
            isJumping = false;
        }
    }
}
