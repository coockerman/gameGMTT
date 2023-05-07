using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] Vector3 StartMove;
    [SerializeField] Transform target;
    [SerializeField] float speed;
    [SerializeField] float TimeMove;
    private void OnEnable()
    {
        StartMove = transform.position;
        Invoke("OffObj", TimeMove);
    }
    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance <= 0)
            {
                OffObj();
            }

        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.tag == "Player")
    //    {
    //        OffObj();
    //    }
    //}
    void OffObj()
    {
        Debug.Log("v");
        gameObject.SetActive(false);
    }
}
