using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{

	public void OnQuitButtonPressed()
    {
        Application.Quit();
    }

    public void OnPlayGameButtonPressed()
    {
        StartCoroutine(SceneLoaderManager.LoadSceneAsync(1));
    }
}
