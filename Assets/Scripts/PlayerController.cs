using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public bool dead = false;
    public GameObject player;
    public GameObject door;
    public float speed;
    private Rigidbody2D rb;
    public GameObject Destructibe_tile;
    public GameObject pistol1;
    public GameObject pistol2;
    public GameObject treasurebox;
    public GameObject boxscene2;
    public GameObject bombprefab;
    public GameObject explosionprefab;
    public GameObject bigenemy;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public GameObject enemy6;
    public GameObject enemy7;
    public GameObject enemy8;
    public GameObject enemy9;
    public GameObject enemy10;
    public GameObject enemy11;
    public GameObject enemy12;
    public GameObject powerup;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(x) >= Mathf.Abs(y))
            y = 0;

        if (Mathf.Abs(y) >= Mathf.Abs(x))
            x = 0;

        Vector2 movement = new Vector2(x, y)*speed*Time.deltaTime;
        rb.velocity = movement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.CompareTag("door"))
        {
            Time.timeScale = 1f;
            Destroy(gameObject);
            SceneManager.LoadScene(3);

        }

        if (collision.gameObject.CompareTag("enemies"))
        {
            Time.timeScale = 1f;
            Destroy(player);
            SceneManager.LoadScene(5);
           // FindObjectOfType<Audiomanager>().Play("");
        }


        if (collision.gameObject.CompareTag("bomb"))
        {
            
            Destroy(player);
            SceneManager.LoadScene(5);
            //FindObjectOfType<Audiomanager>().Play("");
        }

        if (collision.gameObject.CompareTag("explosion"))
        {
            Destroy(player);
            SceneManager.LoadScene(5);
            //FindObjectOfType<Audiomanager>().Play("");
        }

        if (collision.gameObject.CompareTag("powerup"))
        {

            Destroy(collision.gameObject);
            //Debug.Log("aaaa");
            enemy1.GetComponent<Enemies>().EnemySpeed = 10;
            enemy2.GetComponent<Enemymovright>().EnemySpeed = 10;
            enemy3.GetComponent<Enemies>().EnemySpeed = 10;
            enemy4.GetComponent<Enemies>().EnemySpeed = 10;
            enemy5.GetComponent<Enemies>().EnemySpeed = 10;
            enemy6.GetComponent<Enemies>().EnemySpeed = 10;
            enemy7.GetComponent<Enemymovright>().EnemySpeed = 10;
            enemy8.GetComponent<Enemymovright>().EnemySpeed = 10;
            enemy9.GetComponent<Enemymovright>().EnemySpeed = 10;
            enemy10.GetComponent<Enemymovright>().EnemySpeed = 10;
            enemy11.GetComponent<Enemymovright>().EnemySpeed = 10;
            enemy12.GetComponent<Enemies>().EnemySpeed = 10;


            // enemy.GetComponent<Enemymovright>().EnemySpeed = 20;
            
        }

       /* if (collision.gameObject.CompareTag("bigenemy"))
        {
            if (pistol==true)
            {
                Destroy(bigenemy);
            }
            else
            {
                Destroy(gameObject);
            }
        }*/
        
       


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        
            if (collision.gameObject.CompareTag("treasurebox"))
            {
                Destroy(treasurebox);
                pistol1.SetActive(true);
                // Time.timeScale = 0f;

            }

       

        if (collision.gameObject.CompareTag("boxscene2"))
        {
            Destroy(boxscene2);
            pistol1.SetActive(true);
            pistol2.SetActive(true);
        }
        
    }

}
