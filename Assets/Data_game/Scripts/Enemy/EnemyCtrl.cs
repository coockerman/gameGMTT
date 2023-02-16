using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    public float moveSpeed;
    //tttt
    private Rigidbody2D myRigidbody;

    private bool moving = false;

    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    private float timeBetweenTemp;

    public float timeToMove;
    private float timeToMoveCounter;
    private float timeToMoveTemp;

    private Vector3 moveDirection;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        timeBetweenTemp = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveTemp = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);

        timeBetweenMoveCounter = timeBetweenTemp;
        timeToMoveCounter = timeToMoveTemp;
    }

    private void Update()
    {
        SetMovingEnemy();
    }

    protected virtual void SetMovingEnemy()
    {
        if (moving == true) EnemyMoving();
        else EnemyStand();
    }

    protected virtual void EnemyMoving()
    {
        timeToMoveCounter -= Time.deltaTime;
        myRigidbody.velocity = moveDirection;

        if (timeToMoveCounter > 0f) return;
        moving = false;
        timeBetweenMoveCounter = timeBetweenTemp;
    }

    protected virtual void EnemyStand()
    {
        timeBetweenMoveCounter -= Time.deltaTime;
        myRigidbody.velocity = Vector2.zero;

        if (timeBetweenMoveCounter > 0f) return;
        moving = true;
        timeToMoveCounter = timeToMoveTemp;
        moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.name == "Player")
        //{
        //    collision.gameObject.SetActive(false);
        //}

    }
}
