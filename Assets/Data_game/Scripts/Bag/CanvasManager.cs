using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public PlayerCtrl playerCtrl;
    public GameObject bag;
    public GameObject mission;
    public GameObject boxUpgrade;
    [SerializeField] GameObject settingCtrl;

    public int sceneNow;
    private void Awake()
    {
        playerCtrl = FindObjectOfType<PlayerCtrl>();

    }
    private void Start()
    {
        settingCtrl.SetActive(false);
    }
    private void Update()
    {
        ChangeStatus(ref playerCtrl.moveActiveBag, bag, KeyCode.B);
        ChangeStatus(ref playerCtrl.moveActiveMission, mission, KeyCode.Q);
        if(PlayerPrefs.GetInt("UpgradePowerBox") == 1) 
            ChangeStatus(ref playerCtrl.moveActiveUpgradePower, boxUpgrade, KeyCode.F);
        
    }
    
    public void ChangeStatus(ref bool playerActive, GameObject name, KeyCode key)
    {
        if(Input.GetKeyDown(key))
        {
            ChangeStatusClick(ref playerActive, name);
        }
    }
    

    public void ChangeStatusClick(ref bool playerActive, GameObject name)
    {
        if (name.activeSelf == false)
        {
            OnObject(ref playerActive, name);
        }
        else
        {
            OffObject(ref playerActive, name);
        }
    }
    public void OnObject(ref bool playerActive, GameObject name)
    {
        playerActive = false;
        name.SetActive(true);
    }
    public void OffObject(ref bool playerActive, GameObject name)
    {
        playerActive = true;
        name.SetActive(false);
    }

    public void ChangeStatusBagClick()
    {
        if (settingCtrl.activeSelf == true) { return; }
        ChangeStatusClick(ref playerCtrl.moveActiveBag, bag);
    }
    public void ChangeStatusMissionClick()
    {
        if (settingCtrl.activeSelf == true) { return; }
        ChangeStatusClick(ref playerCtrl.moveActiveMission, mission);
    }
    public void ChangeStatusUpgradePowerClick()
    {
        if (settingCtrl.activeSelf == true) { return; }
        ChangeStatusClick(ref playerCtrl.moveActiveUpgradePower, boxUpgrade);
    }

    public void ChangeStatusSettingClick()
    {
        if(Time.timeScale <1)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
         ChangeStatusClick(ref playerCtrl.moveActiveUiSetting, settingCtrl);

    }

}
