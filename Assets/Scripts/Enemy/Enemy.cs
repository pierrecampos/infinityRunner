using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int health;
    public int damage;

    protected virtual void ApplyDamage(int dmg) {
        Debug.Log(dmg);
        health -= dmg;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("bullet")) {
            int dmg = collision.GetComponent<Projectile>().dmg;
            ApplyDamage(dmg);
        }
    }


}
