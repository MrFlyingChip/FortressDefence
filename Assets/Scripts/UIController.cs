using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject pauseMenu;
    public Text goldText;
    public GameController gameController;
    public GameObject gameOverObject;
    public GameObject winGameObject;

    public void OnPauseButtonPressed()
    {
        Time.timeScale = 1 - Time.timeScale;
        pauseMenu.SetActive(!pauseMenu.active);
    }

    public void OnMenuButtonPressed()
    {
        Time.timeScale = 1f;
        StartCoroutine(SceneLoaderManager.LoadSceneAsync(0));
    }

    public void OnRetryButtonPressed()
    {
        Time.timeScale = 1f;
        StartCoroutine(SceneLoaderManager.LoadSceneAsync(1));
    }

    public void ShowGold(int gold)
    {
        goldText.text = gold.ToString();
    }

    public void OnBuyArcherButtonPressed()
    {
        gameController.BuyArcher();
    }

    public void ShowGameOver()
    {
        gameOverObject.SetActive(true);
    }

    public void ShowWinGame()
    {
        winGameObject.SetActive(true);
    }
}
