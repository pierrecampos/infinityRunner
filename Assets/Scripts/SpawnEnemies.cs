using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {
    public List<GameObject> enemies = new List<GameObject>();

    private float timeCount;
    public float spawnTime;

    void Update() {

        timeCount += Time.deltaTime;
        if (timeCount > spawnTime) {
            SpawnEnemy();
            timeCount = 0f;
        }
    }

    void SpawnEnemy() {
        Instantiate(enemies[0], transform.position + new Vector3(0f, transform.position.y + Random.Range(0f, 3f), 0f), transform.rotation);
    }
}
