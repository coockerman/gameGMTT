using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UiManager : MonoBehaviour
{
    public Slider healthBar;
    public Slider manaBar;
    // Start is called before the first frame update

    private void Start()
    {
        //healthBar = gameObject.GetComponentInChildren<Slider>();
        //manaBar= gameObject.GetComponentInChildren<Slider>();
    }
    // Update is called once per frame
    void Update()
    {
       
    }
    protected virtual void NowHealth()
    {
        
    }
    protected virtual void NowMana()
    {

    }
}
