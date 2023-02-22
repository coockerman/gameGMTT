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
    }
    public void ChangeBagStatus()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (bag.gameObject.active == false)
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
            if (mission.gameObject.active == false)
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

}
