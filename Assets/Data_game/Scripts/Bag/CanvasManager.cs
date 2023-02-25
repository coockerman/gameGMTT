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

    public int sceneNow;
    private void Awake()
    {
        playerCtrl = FindObjectOfType<PlayerCtrl>();

    }
    private void Start()
    {
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
        ChangeStatusClick(ref playerCtrl.moveActiveBag, bag);
    }
    public void ChangeStatusMissionClick()
    {
        ChangeStatusClick(ref playerCtrl.moveActiveMission, mission);
    }
    public void ChangeStatusUpgradePowerClick()
    {
        ChangeStatusClick(ref playerCtrl.moveActiveUpgradePower, boxUpgrade);
    }


}
