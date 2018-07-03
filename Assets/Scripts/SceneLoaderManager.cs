using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoaderManager
{
    public static IEnumerator LoadSceneAsync(int scene)
    {
        #if UNITY_PRO_LICENSE
        AsyncOperation async = SceneManager.LoadSceneAsync(scene);
        while (!async.isDone)
        {
            yield return async.progress;
        }
        #else
			SceneManager.LoadScene (scene);
			yield return 0;
        #endif
    }

}
