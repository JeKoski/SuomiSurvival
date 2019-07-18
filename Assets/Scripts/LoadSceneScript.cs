using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneScript : MonoBehaviour
{
    //[SerializeField] bool manualLevelLoad;
    [SerializeField] private bool loadSceneByName = false;

    [SerializeField] private string sceneName;
    [SerializeField] private int levelToLoad = 0;

    public void LoadScene()
    {
        if (loadSceneByName)
        {
            SceneManager.LoadScene(sceneName);
        }

        else if (!loadSceneByName)
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
