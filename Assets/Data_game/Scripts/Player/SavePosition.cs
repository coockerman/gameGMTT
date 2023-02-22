using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class SavePosition : MonoBehaviour
{
    private string dataPositonX = "DataPositionx";
    private string dataPositonY = "DataPositiony";
    private string dataScene = "DataScene";
    private void Update()
    {
        ControlSave();
    }
    protected virtual void ControlSave()
    {
        if (Input.GetKeyDown(KeyCode.Y)) LoadDataPosition();
        if (Input.GetKeyDown(KeyCode.T)) SaveDataPosition();
    }
    protected virtual void LoadDataPosition()
    {
        if (SceneManager.GetActiveScene().buildIndex != PlayerPrefs.GetInt(dataScene))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt(dataScene));

        }
        gameObject.transform.position = new Vector3(PlayerPrefs.GetFloat(dataPositonX), PlayerPrefs.GetFloat(dataPositonY), 0);
    }
    protected virtual void SaveDataPosition()
    {
        PlayerPrefs.SetFloat(dataPositonX, gameObject.transform.position.x);
        PlayerPrefs.SetFloat(dataPositonY, gameObject.transform.position.y);
        PlayerPrefs.SetInt(dataScene, SceneManager.GetActiveScene().buildIndex);
    }
}
