using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManaManager : MonoBehaviour
{
    public int playerMaxMana;
    public int playerCurrentMana;

    private int CurrentCreateMana = 1;
    public float speedCreateMana = 1;
    private float TimeCreateMana = 1;

    public GameObject textHetMana;
    
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("playerMana") == 0)
            PlayerPrefs.SetInt("playerMana", playerMaxMana);
        playerMaxMana = PlayerPrefs.GetInt("playerMana");
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
        TimeCreateMana -= (Time.deltaTime * speedCreateMana);
        if(TimeCreateMana<=0)
        {
            TimeCreateMana = 1;
            playerCurrentMana += CurrentCreateMana;
        }
    }
    
    public void SetMaxMana()
    {
        playerCurrentMana = playerMaxMana;
        if (PlayerPrefs.GetFloat("playerManaSpeed") != 0) speedCreateMana = PlayerPrefs.GetFloat("playerManaSpeed");
      
    }

    public void UpMana(int UpMana)
    {
        playerCurrentMana += UpMana;
        playerMaxMana += UpMana;
        PlayerPrefs.SetInt("playerMana", playerMaxMana);

    }
    public void GiamMana(int giamMana)
    {
        playerCurrentMana -= giamMana;
    }
    public void HoiMana(int hoiMana)
    {
        playerCurrentMana += hoiMana;
        if (playerCurrentMana > playerMaxMana) 
            SetMaxMana();
    }
    public bool GetStatusSkill1()
    {
        if (playerCurrentMana < 10) return false;
        else return true;
    }
    public bool GetStatusSkill2()
    {
        if (playerCurrentMana < 20) return false;
        else return true;
    }
    public void UpSpeedCreateMana(float Speed)
    {
        speedCreateMana = Speed;
        PlayerPrefs.SetFloat("playerManaSpeed", speedCreateMana);

    }
    public void HetMana()
    {
        Instantiate(textHetMana, transform.position, transform.rotation);
    }
}
