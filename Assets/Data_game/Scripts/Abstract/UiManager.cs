using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UiManager : MonoBehaviour
{
    public Slider healthBar;
    public Slider manaBar;
    
    protected virtual void NowHealth()
    {
        
    }
    protected virtual void NowMana()
    {

    }
}
