using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D rig;
    private bool isJumping;
    public float Speed;
    public float JumpForce;
    public int health;
    public Animator anim;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Animator jetPack;

    void Start() {
        rig = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        rig.velocity = new Vector2(Speed, rig.velocity.y);
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            OnJump();
        }

        if (Input.GetKeyDown(KeyCode.F)) {
            OnShoot();
        }
    }

    public void OnJump() {
        if (!isJumping) {
            rig.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
            AudioController.instance.Play(AudioController.instance.playerShoot);
            isJumping = true;
        }
    }
    public void OnShoot() {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        AudioController.instance.Play(AudioController.instance.playerShoot);
    }

    public void OnHit(int dmg) {
        health -= dmg;
        if (health <= 0) {
            health = 0;
            GameController.instance.ShowGameOver();
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == 6) {
            anim.SetBool("isJumping", false);             
            isJumping = false;
        }
    }
}
