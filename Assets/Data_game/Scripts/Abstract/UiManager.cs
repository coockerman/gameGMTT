using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UiManager : MonoBehaviour
{
    public Slider healthBar;
    // Start is called before the first frame update

    private void Start()
    {
        healthBar = gameObject.GetComponentInChildren<Slider>();

    }
    // Update is called once per frame
    void Update()
    {
        NowHealth();
    }
    protected virtual void NowHealth()
    {
        
    }
}
