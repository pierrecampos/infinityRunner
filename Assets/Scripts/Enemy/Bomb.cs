using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    private Rigidbody2D rig;
    public float xAxis;
    public float yAxis;
    public int dmg;
    private Animator anim;

    private Player player;

    private bool explosion;

    void Start() {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector2(xAxis, yAxis), ForceMode2D.Impulse);
        Destroy(gameObject, 5f);
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.CompareTag("Player") && !explosion) {
            player.OnHit(dmg);
            DestroyBomb();
        }
        if (coll.gameObject.layer == 6 && !explosion) {
            DestroyBomb();
        }

    }

    void DestroyBomb() {
        explosion = true;
        anim.SetTrigger("BombExplosion");
        Destroy(gameObject, 1f);
        PlaySound();
    }

    void PlaySound() {
        float distance = player.transform.position.x - transform.position.x;        
        if (distance >= -10 && distance <= 10) {
            AudioController.instance.Play(AudioController.instance.bombExplosion);
        }
    }
}
