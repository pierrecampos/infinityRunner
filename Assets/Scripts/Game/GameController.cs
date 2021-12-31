using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController instance;
    public GameObject gameOverPanel;
    public GameObject ShootBtn;
    public GameObject JumpBtn;

    void Start() {
        instance = this;
        Time.timeScale = 1;
    }

    public void ShowGameOver() {
        gameOverPanel.SetActive(true);
        ShootBtn.SetActive(false);
        JumpBtn.SetActive(false);
        Time.timeScale = 0;
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
