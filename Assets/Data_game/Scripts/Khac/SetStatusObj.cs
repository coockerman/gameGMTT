using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStatusObj : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] KeyCode keyName;
    [SerializeField] bool OnObjAwake;
    [SerializeField] string NameSavePrefs;
    private void Start()
    {
        if (OnObjAwake)
        {
            if(PlayerPrefs.GetInt(NameSavePrefs) ==1)
            {
                return;
            }
            PlayerPrefs.SetInt(NameSavePrefs, 1);
            OnGameObject();
        }
    }
    public void OnGameObject()
    {
        if(obj.activeSelf ==false)
        obj.SetActive(true);
    }
    public void OffGameObject()
    {
        if(obj.activeSelf ==true)
        obj.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(keyName))
        {
            OnGameObject();
        }
    }
}
