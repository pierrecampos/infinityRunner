using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : Enemy {

    private Rigidbody2D rig;
    public float speed;

    private Player player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);
    }

    void FixedUpdate() {
        rig.velocity = Vector2.left * speed;
    }

    protected override void OnTriggerEnter2D(Collider2D collision) {
        base.OnTriggerEnter2D(collision);
        if (collision.CompareTag("Player")) {
            player.OnHit(damage);
        }
    }


}
