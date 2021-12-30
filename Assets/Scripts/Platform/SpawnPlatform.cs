using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour {

    public List<GameObject> platforms = new List<GameObject>();

    private List<Transform> currentPlatforms = new List<Transform>();
    private Transform currentPlatformPoint;
    private Transform player;
    private int platformIndex;

    public float offset;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < platforms.Count; i++) {
            Transform p = Instantiate(platforms[i], new Vector2(i * 30, -4.48f), transform.rotation).transform;
            currentPlatforms.Add(p);
            offset += 30;
        }

        currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint;

    }

    void Update() {
        float distance = player.position.x - currentPlatformPoint.position.x;

        if (distance >= 1) {
            Recycle(currentPlatforms[platformIndex].gameObject);
            platformIndex++;

            if (platformIndex > currentPlatforms.Count - 1) {
                platformIndex = 0;
            }

            currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint;
        }

    }

    public void Recycle(GameObject platform) {
        platform.transform.position = new Vector2(offset, -4.48f);
        if (platform.GetComponent<Platform>().spawnEnemy != null) {
            platform.GetComponent<Platform>().spawnEnemy.SpawnEnemy();
        }
        offset += 30;
    }
}
