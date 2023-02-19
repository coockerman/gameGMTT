using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManaManager : MonoBehaviour
{
    public int playerMaxMana;
    public int playerCurrentMana;

    private int CurrentCreateMana = 1;
    private float TimeCreateMana = 1;
    // Start is called before the first frame update
    void Start()
    {
        SetMaxMana();
    }

    // Update is called once per frame
    void Update()
    {
        CreateMana();
    }    
    public void CreateMana()
    {
        if (playerCurrentMana >= playerMaxMana) return;
        TimeCreateMana -= Time.deltaTime;
        if(TimeCreateMana<=0)
        {
            TimeCreateMana = 1;
            playerCurrentMana += CurrentCreateMana;
        }
    }
    
    public void SetMaxMana()
    {
        playerCurrentMana = playerMaxMana;
    }

    public void UpMana(int UpMana)
    {
        playerCurrentMana += UpMana;
        playerMaxMana += UpMana;
    }
    public void GiamMana(int giamMana)
    {
        playerCurrentMana -= giamMana;
    }
    public bool GetStatusSkill1()
    {
        if (playerCurrentMana >= 10) return true;
        return false;
    }
    public bool GetStatusSkill2()
    {
        if (playerCurrentMana >= 20) return true;
        return false;
    }
}
