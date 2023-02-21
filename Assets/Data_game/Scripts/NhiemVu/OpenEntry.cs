using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEntry : MonoBehaviour
{
    public GameObject entryObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OpenEntryy();

    }
    protected virtual void OpenEntryy()
    {
        if (PlayerPrefs.GetInt("dialogIndexBon") >= 5)
        {
            entryObject.SetActive(true);
        }
    }
}
