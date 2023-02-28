using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitObject : MonoBehaviour
{
    public PlayerCtrl playerCtrl;
    private void Start()
    {
        playerCtrl = FindObjectOfType<PlayerCtrl>();
    }
    public void ExitObjectt()
    {
        Time.timeScale = 1;
        playerCtrl.moveActiveUiSetting = true;
        gameObject.SetActive(false);
    }
}
