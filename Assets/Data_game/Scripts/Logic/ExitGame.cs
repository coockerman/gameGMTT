using System.Collections;
using System.Collections.Generic;

using UnityEngine.SceneManagement;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    
    public void ButtonExitGame()
    {
        SceneManager.UnloadScene(SceneManager.sceneCount);
        //Application.Quit();
        Debug.Log("a");
    }
}
