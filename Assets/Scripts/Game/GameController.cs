using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController instance;
    public GameObject gameOverPanel;
    public GameObject ShootBtn;
    public GameObject JumpBtn;
    public GameObject PauseBtn;
    public GameObject pausePanel;
    public Text score;

    private int _score;
    public int Score {
        get => _score;
        set => _score += value;
    }

    void Start() {
        instance = this;
        Time.timeScale = 1;
    }

    void Update() {
        score.text = "Score: " + _score.ToString();
    }

    public void ShowGameOver() {
        gameOverPanel.SetActive(true);
        ShootBtn.SetActive(false);
        JumpBtn.SetActive(false);
        PauseBtn.SetActive(false);
        Time.timeScale = 0;
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseGame() {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        AudioController.instance.MuteAll(true);
    }

    public void ContinueGame() {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        AudioController.instance.MuteAll(false);
    }

    public void GameMenu() {
        SceneManager.LoadScene(0);
    }




}
