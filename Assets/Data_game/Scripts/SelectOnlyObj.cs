using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectOnlyObj : MonoBehaviour
{
    [SerializeField] GameObject[] objs;
    public void TurnOnObj(int t)
    {
        foreach (GameObject obj in objs)
        {
            obj.gameObject.SetActive(false);
        }
        objs[t].gameObject.SetActive(true);
    }
}
