using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController instance;
    public GameObject gameOverPanel;

    void Start() {
        instance = this;
        Time.timeScale = 1;
    }

    public void ShowGameOver() {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
