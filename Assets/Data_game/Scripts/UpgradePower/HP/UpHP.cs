using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpHP : MonoBehaviour
{
    public PlayerHearthManager playerHearth;
    private int TangHp;
    private void Awake()
    {
        playerHearth = GetComponent<PlayerHearthManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        TangHp = 10;
    }

    public void UpMoreHp()
    {
        
        if (PlayerPrefs.GetInt("VatPham1") > 0)
        {
            playerHearth.UpHp(TangHp);
            PlayerPrefs.SetInt("VatPham1", PlayerPrefs.GetInt("VatPham1") - 1);

        }
    }
}
