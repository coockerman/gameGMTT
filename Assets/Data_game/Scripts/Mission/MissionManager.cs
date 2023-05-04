using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMission;
    [SerializeField] string[] missionData;
    [SerializeField] BagCtrl bagCtrl;
    int indexNV = 1;
    //NV7

    [Header("NV7")]
    private static MissionManager _instance;


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        indexNV = 1;
    }

    void Update()
    {
        SetNV();
    }
    protected virtual void SetNV()
    {
        if (indexNV == 1) NV1();
        else if (indexNV == 2) NV2();
        else if (indexNV == 3) NV3();
        else if (indexNV == 4) NV4();
        else if (indexNV == 5) NV5();
        else if (indexNV == 6) NV6();
        else if (indexNV == 7) NV7();
        else if (indexNV == 8) NV8();
        else if (indexNV == 9) NV9();
        else if (indexNV == 10) NV10();
        else if (indexNV == 11) NV11();
    }
    void NV1()
    {
        textMission.text = missionData[1];

        if (PlayerPrefs.GetInt("BonDialog1") == 1)
        {
            indexNV = 2;
        }
    }
    void NV2()
    {
        textMission.text = missionData[2];
        if (PlayerPrefs.GetInt("NV2Check") != 1)
        {
            PlayerPrefs.SetInt("NV2Check", 1);
        }
        if (PlayerPrefs.GetInt("BrumDialog1") == 1)
        {
            indexNV = 3;
        }
    }
    void NV3()
    {
        textMission.text = missionData[3];
        if (PlayerPrefs.GetInt("playerLV") >= 3)
        {
            indexNV = 4;
        }
    }
    void NV4()
    {
        textMission.text = missionData[4];
        if (PlayerPrefs.GetInt("NV4Check") != 1)
            PlayerPrefs.SetInt("NV4Check", 1);
        if (PlayerPrefs.GetInt("BrumDialog2") == 1)
        {
            indexNV = 5;
        }
    }
    void NV5()
    {
        textMission.text = missionData[5];
        if (PlayerPrefs.GetInt("NV5Check") != 1)
        {
            PlayerPrefs.SetInt("NV5Check", 1);
        }
        if (PlayerPrefs.GetInt("KaLinDialog3") == 1)
        {
            indexNV = 6;
        }
    }
    void NV6()
    {
        textMission.text = missionData[6];
        
        if (PlayerPrefs.GetInt("playerLV") >= 4)
        {
            indexNV = 7;
        }
    }
    void NV7()
    {
        textMission.text = missionData[7];
        if (PlayerPrefs.GetInt("NV7Check") != 1)
        {
            PlayerPrefs.SetInt("NV7Check", 1);
        }
        if (PlayerPrefs.GetInt("AtanDialogs1") == 1)
        {
            indexNV = 8;
        }
    }
    void NV8()
    {
        textMission.text = missionData[8];
        if (PlayerPrefs.GetInt("NV8Check") != 1)
        {
            PlayerPrefs.SetInt("NV8Check", 1);
        }
        if (PlayerPrefs.GetInt("AnTromDialog1") == 1)
        {
            indexNV = 9;
        }
    }
    void NV9()
    {
        textMission.text = missionData[9];
        if (PlayerPrefs.GetInt("NV9Check") != 1)
        {
            PlayerPrefs.SetInt("NV9Check", 1);
        }
        if (PlayerPrefs.GetInt("AtanDialog2") == 1)
        {
            if(PlayerPrefs.GetInt("NhanQuaNV9")==0)
            {
                bagCtrl.TangVatPham(1, 10);
                PlayerPrefs.SetInt("NhanQuaNV9", 1);
            }
            indexNV = 10;
        }
    }
    void NV10()
    {
        textMission.text = missionData[10];
        if (PlayerPrefs.GetInt("NV10Check") != 1)
        {
            PlayerPrefs.SetInt("NV10Check", 1);
        }
        if (PlayerPrefs.GetInt("BonDialog4") == 1)
        {
            indexNV = 11;
        }
    }
    void NV11()
    {
        textMission.text = missionData[11];

    }
}
