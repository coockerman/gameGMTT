using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{
    [SerializeField] private PlayerCtrl thePlayer;
    [SerializeField] private CameraCtrl theCamera;
    // Start is called before the first frame update

    public string pointName;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerCtrl>();
        theCamera = FindObjectOfType<CameraCtrl>();

        if (thePlayer.StartPoint == pointName)
        {
            thePlayer.transform.position = this.transform.position;
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
