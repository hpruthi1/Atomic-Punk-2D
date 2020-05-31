using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{

    Rigidbody2D enemyRigidBody2D;
    public int UnitsToMove = 1;
    public float EnemySpeed = 30;
    public bool _isFacingup;
    private float _startPos;
    private float _endPos;
    public bool _moveup = true;
    public GameObject bombprefab;
    public GameObject explosionprefab;
   
   public void Awake()
    {
        enemyRigidBody2D = GetComponent<Rigidbody2D>();
        _startPos = transform.position.y;
        _endPos = _startPos + UnitsToMove;
        _isFacingup = transform.localScale.y > 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_moveup)
        {
            enemyRigidBody2D.AddForce(Vector2.up * EnemySpeed * Time.deltaTime);
            if (!_isFacingup)
                Flip();
        }

        if (enemyRigidBody2D.position.y >= _endPos)
            _moveup = false;

        if (!_moveup)
        {
            enemyRigidBody2D.AddForce(-Vector2.up * EnemySpeed * Time.deltaTime);
            if (_isFacingup)
                Flip();
        }
        if (enemyRigidBody2D.position.y <= _startPos)
            _moveup = true;
    }
    public void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        _isFacingup = transform.localScale.y > 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("bomb"))
        {
           
            Destroy(gameObject);
            //bombprefab.GetComponent<CircleCollider2D>().enabled = false ;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("explosion"))
        {
           
            Destroy(gameObject);
            //explosionprefab.GetComponent<CircleCollider2D>().enabled = false;
            // DestroyImmediate(explosionprefab, true);
            Destroy(explosionprefab);
       
            Debug.Log("Destroy explosion");
        }
    }
    
}



