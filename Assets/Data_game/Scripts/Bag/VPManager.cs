using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VPManager : MonoBehaviour
{
    public Image itemImage;
    public TextMeshProUGUI textCount;

    public int countItem = 0;
    private void Awake()
    {
        itemImage = GetComponentInChildren<Image>();
        textCount = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Start()
    {

        countItem = PlayerPrefs.GetInt(gameObject.name);
        countItem = 0;
    }
    private void Update()
    {
        //SetImage();
    }
    public void SetImage()
    {
        if(countItem <= 0)
        {
            itemImage.color = new Color(10f, 10f, 10f, 255f);
        }
        else
        {
            itemImage.color = new Color(255f, 255f, 255f, 255f);

        }

    }
}
