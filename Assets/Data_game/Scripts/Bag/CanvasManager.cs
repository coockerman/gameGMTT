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
        ChangeBagStatus();
        ChangeMissionStatus();
        ChangeUpgradePowerStatus();
    }
    public void ChangeBagStatus()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (bag.gameObject.activeSelf == false)
            {
                OnBag();
            }else           
            {
                OffBag();
            }
        }
    }
    public void OnBag()
    {
        playerCtrl.moveActiveBag = false;
        bag.SetActive(true);
    }
    public void OffBag()
    {
        playerCtrl.moveActiveBag = true;
        bag.SetActive(false);
    }

    public void ChangeMissionStatus()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (mission.gameObject.activeSelf == false)
            {
                OnMission();
            }
            else
            {
                OffMission();
            }
        }
    }
    public void OnMission()
    {
        playerCtrl.moveActiveMission = false;
        mission.SetActive(true);
    }
    public void OffMission()
    {
        playerCtrl.moveActiveMission = true;
        mission.SetActive(false);
    }
    public void ChangeUpgradePowerStatus()
    {
        if (Input.GetKeyDown(KeyCode.F) && PlayerPrefs.GetInt("UpgradePowerBox") == 1)
        {
            if (boxUpgrade.gameObject.activeSelf == false)
            {
                OnBoxPower();
            }
            else
            {
                OffBoxPower();
            }
        }
    }
    public void OnBoxPower()
    {
        playerCtrl.moveActiveUpgradePower = false;
        boxUpgrade.SetActive(true);
    }
    public void OffBoxPower()
    {
        playerCtrl.moveActiveUpgradePower = true;
        boxUpgrade.SetActive(false);
    }
}
