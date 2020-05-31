using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pistol2 : MonoBehaviour
{
    public GameObject bigenemy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bigenemy"))
        {

            Destroy(bigenemy);
            Time.timeScale = 0f;
            SceneManager.LoadScene(6);
        }
    }
}
