using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Player")) {
            GameController.instance.ShowGameOver();
        }
    }

}
