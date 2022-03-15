using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void FirstLevel()
    {
        StartCoroutine(LoadYourAsyncScene());
    }

    IEnumerator LoadYourAsyncScene()
    {
        
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level1");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}