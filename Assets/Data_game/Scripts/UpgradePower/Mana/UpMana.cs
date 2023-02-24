using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpMana : MonoBehaviour
{
    public PlayerManaManager playerMana;
    private int TangMana;
    private void Awake()
    {
        playerMana = GetComponent<PlayerManaManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        TangMana = 5;
    }

    public void UpMoreMana()
    {
        if (PlayerPrefs.GetInt("VatPham1") > 0)
        {
            playerMana.UpMana(TangMana);
            PlayerPrefs.SetInt("VatPham1", PlayerPrefs.GetInt("VatPham1") - 1);

        }
       

    }
}
