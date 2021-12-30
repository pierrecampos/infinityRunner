using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    private Rigidbody2D rig;

    public float speed;
    public int dmg;
    public GameObject explosionPrefab;

    void Start() {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);
    }

    void FixedUpdate() {
        rig.velocity = Vector2.right * speed;
    }

    public void OnHit() {
        GameObject e = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(e, 0.5f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == 6) {
            OnHit();
        }
    }
}
