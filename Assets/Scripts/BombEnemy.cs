using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : MonoBehaviour {

    public Transform firePoint;
    public GameObject bombPrefab;
    public float throwTime;
    private float throwCount;


    void Start() {

    }


    void Update() {
        throwCount += Time.deltaTime;
        if (throwCount > throwTime) {
            Instantiate(bombPrefab, firePoint.position, firePoint.rotation);
            throwCount = 0f;
        }

    }
}
