using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        App.gameManager = this;

        // load UI scene and show menu screen
        StartCoroutine(LoadSelectedScene("UIScene"));

        // alternatively synch loading:
        // SceneManager.LoadScene("UIScene", LoadSceneMode.Additive);
    }

    public void StartSceneLoading(string sceneName)
    {
        StartCoroutine(LoadSelectedScene(sceneName));
    }

    public void StartSceneUnloading(string sceneName)
    {
        StartCoroutine(UnloadSelectedScene(sceneName));
    }

    IEnumerator LoadSelectedScene(string sceneName)
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while(!loading.isDone)
        {
            Debug.Log(loading.progress);
            yield return null;
        }

        Debug.Log("Scene " + sceneName + " loaded");
    }

    IEnumerator UnloadSelectedScene(string sceneName)
    {
        AsyncOperation loading = SceneManager.UnloadSceneAsync(sceneName);

        while(!loading.isDone)
        {
            yield return null;
        }

        Debug.Log("Scene " + sceneName + " unloaded");
    }
}
