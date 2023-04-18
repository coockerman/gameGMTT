using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonDestroyObject : MonoBehaviour
{
    private static DonDestroyObject _instance;
    private void Awake()
    {

        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
