using System.Collections;
using System.Collections.Generic;

using UnityEngine.SceneManagement;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    
    public void ButtonExitGame()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();

    }
}
