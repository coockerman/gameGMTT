using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class SavePosition : MonoBehaviour
{
    private string dataPositonX = "DataPositionx";
    private string dataPositonY = "DataPositiony";
    private string dataScene = "DataScene";
    protected PlayerManaManager playerMana;
    protected int manaLoadPosition;
    private void Awake()
    {
        playerMana= GetComponent<PlayerManaManager>();
    }
    private void Start()
    {
        manaLoadPosition = 100;

    }
    private void Update()
    {
        ControlSave();
    }
    protected virtual void ControlSave()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if(playerMana.playerCurrentMana >= manaLoadPosition)
            {
                playerMana.GiamMana(manaLoadPosition);
                LoadDataPosition();
            }
            else
            {
                playerMana.HetMana();
            }
        }
        
        if (Input.GetKeyDown(KeyCode.T)) SaveDataPosition();
    }
    protected virtual void LoadDataPosition()
    {
        if (SceneManager.GetActiveScene().buildIndex != PlayerPrefs.GetInt(dataScene))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt(dataScene));

        }
        if(PlayerPrefs.GetFloat(dataPositonX)==0 && PlayerPrefs.GetFloat(dataPositonY)==0)
        {
            gameObject.transform.position = new Vector3(-10, 18, 0);
        }
        else
        {
            gameObject.transform.position = new Vector3(PlayerPrefs.GetFloat(dataPositonX), PlayerPrefs.GetFloat(dataPositonY), 0);
        }
    }
    protected virtual void SaveDataPosition()
    {
        PlayerPrefs.SetFloat(dataPositonX, gameObject.transform.position.x);
        PlayerPrefs.SetFloat(dataPositonY, gameObject.transform.position.y);
        PlayerPrefs.SetInt(dataScene, SceneManager.GetActiveScene().buildIndex);
    }
}
