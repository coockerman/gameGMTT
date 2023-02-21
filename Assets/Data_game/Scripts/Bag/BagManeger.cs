using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BagManeger : MonoBehaviour
{
    public PlayerCtrl playerCtrl;
    public GameObject bag;
    public int sceneNow;
    private void Awake()
    {
        playerCtrl = FindObjectOfType<PlayerCtrl>();
    }
    private void Update()
    {
        ChangeBagStatus();
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
}
