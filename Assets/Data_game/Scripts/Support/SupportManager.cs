using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SupportManager : MonoBehaviour
{
    
    [SerializeField] Image img;
    [SerializeField] Sprite[] imgs;
    int nowSprite;
    private void OnEnable()
    {
        nowSprite = 0;
        img.sprite = imgs[nowSprite];
    }
    public void nextImg()
    {
        if (nowSprite < imgs.Length-1)
        {
            img.sprite = imgs[(nowSprite+1)];
            nowSprite++;
        }
    }
    public void backImg() 
    {
        if (nowSprite > 0)
        {
            img.sprite = imgs[(nowSprite - 1)];
            nowSprite--;
        }
    }
}
