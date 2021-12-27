using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour {

    public List<GameObject> Platforms = new List<GameObject>();

    public float offset;

    void Start() {
        for (int i = 0; i < Platforms.Count; i++) {
            Instantiate(Platforms[i], new Vector2(i * 30, 0f), transform.rotation);
            offset += 30;
        }

    }


    public GameObject platTest;
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Recycle(platTest);
        }
    }

    public void Recycle(GameObject platform) {
        platform.transform.position = new Vector2(offset, 0);
        offset += 30;
    }
}
