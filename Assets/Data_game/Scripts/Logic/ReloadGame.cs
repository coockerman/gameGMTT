using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class ReloadGame : MonoBehaviour
{
    
    public void ButtonReloadGame()
    {
        PlayerPrefs.DeleteAll();
    }
}
