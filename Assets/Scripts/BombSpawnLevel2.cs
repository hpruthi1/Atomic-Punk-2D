using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawnLevel2 : MonoBehaviour
{
    int count = 5;
    public GameObject bombPrefab;
    
   
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && count>0 && count<=5)
        {
            Vector3 p = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
             Instantiate(bombPrefab, new Vector3(p.x, p.y, 0.0f), Quaternion.identity);
            FindObjectOfType<Audiomanager>().Play("Bomb");
            count--;
          /*  Instantiate(bombPrefab, new Vector3(Mathf.RoundToInt(p.x),
   p.y, Mathf.RoundToInt(0.0f)),
   bombPrefab.transform.rotation);*/

        }
    }
}
