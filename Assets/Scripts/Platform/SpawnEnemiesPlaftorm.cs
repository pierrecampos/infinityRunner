using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesPlaftorm : MonoBehaviour {

    public List<Transform> points = new List<Transform>();
    public GameObject enemy;
    private GameObject currentEnemy;

    void Start() {
        CreateEnemy();
    }


    public void SpawnEnemy() {
        if (currentEnemy == null) {
            CreateEnemy();
        } else {
            int index = Random.Range(0, points.Count);
            currentEnemy.transform.position = points[index].position;
        }

    }

    void CreateEnemy() {
        int index = Random.Range(0, points.Count);
        currentEnemy = Instantiate(enemy, points[index].position, points[index].rotation);
    }
}
