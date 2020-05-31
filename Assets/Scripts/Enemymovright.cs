﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymovright : MonoBehaviour
{

    Rigidbody2D enemyRigidBody2D;
    public int UnitsToMove = 1;
    public float EnemySpeed = 30;
    public bool _isFacingRight;
    private float _startPos;
    private float _endPos;
    public bool _moveRight = true;
    public GameObject bombprefab;
    public GameObject explosionprefab;

    public void Awake()
    {
        enemyRigidBody2D = GetComponent<Rigidbody2D>();
        _startPos = transform.position.x;
        _endPos = _startPos + UnitsToMove;
        _isFacingRight = transform.localScale.x > 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_moveRight)
        {
            enemyRigidBody2D.AddForce(Vector2.right * EnemySpeed * Time.deltaTime);
            if (!_isFacingRight)
                Flip();
        }

        if (enemyRigidBody2D.position.x >= _endPos)
            _moveRight = false;

        if (!_moveRight)
        {
            enemyRigidBody2D.AddForce(-Vector2.right * EnemySpeed * Time.deltaTime);
            if (_isFacingRight)
                Flip();
        }
        if (enemyRigidBody2D.position.x <= _startPos)
            _moveRight = true;
    }
    public void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _isFacingRight = transform.localScale.x > 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("bomb"))
        { 
            Destroy(gameObject);
             //bombprefab.GetComponent<CircleCollider2D>().enabled = false;
            Destroy(bombprefab);
        }

        if (collision.gameObject.CompareTag("explosion"))
        {
           
           
            Destroy(gameObject);
            // explosionprefab.GetComponent<CircleCollider2D>().enabled = false;
            DestroyImmediate(explosionprefab,true);
        }
    } 

}
