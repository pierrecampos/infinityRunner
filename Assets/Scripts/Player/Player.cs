using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Text life;

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

        life.text = "Life: " + health.ToString();
    }

    public void OnJump() {
        if (!isJumping) {
            rig.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
            jetPack.SetBool("JetPackEffect", true);
            AudioController.instance.PlayLoopSound(AudioController.instance.jetPack);
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
            jetPack.SetBool("JetPackEffect", false);
            isJumping = false;

            AudioController.instance.StopLoopSound();
        }
    }
}
