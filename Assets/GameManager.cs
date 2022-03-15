using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TruckController truckController;
    [SerializeField] private Gizmo check1;
    [SerializeField] private Gizmo check2;
    [SerializeField] private Gizmo check3;
    [SerializeField] private Gizmo check4;
    [SerializeField] private DirectionCheck directionCheck;
    [SerializeField] private GameObject nextLevel;

    [SerializeField] private string nextLevelName;

    private void Update()
    {
        if(check1.isIn && check2.isIn && check3.isIn && check4.isIn && directionCheck.rightPosition)
        {
            Debug.Log("Win!!");
            truckController.active = false;
            truckController.Stop();
            nextLevel.SetActive(true);
        }
    }

    public void StartNextLevel()
    {
        StartCoroutine(LoadYourAsyncScene());
    }

    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextLevelName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

}
