using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : Enemy {

    public Transform firePoint;
    public GameObject bombPrefab;
    public float throwTime;
    private float throwCount;
    private Player player;


    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    void Update() {
        throwCount += Time.deltaTime;
        if (throwCount > throwTime) {
            Instantiate(bombPrefab, firePoint.position, firePoint.rotation);
            throwCount = 0f;
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision) {
        base.OnTriggerEnter2D(collision);
        if (collision.CompareTag("Player")) {
            player.OnHit(damage);
        }
    }

}
