using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Tiledestroyer : MonoBehaviour
{
    public GameObject explosionPrefab;
    public LayerMask levelMask;
    private bool exploded = false;
    public GameObject tile;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", 2f);
      
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void Explode()
    {
        Vector3 p = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        StartCoroutine(CreateExplosions(Vector3.up));
        StartCoroutine(CreateExplosions(Vector3.right));
        StartCoroutine(CreateExplosions(Vector3.down));
        StartCoroutine(CreateExplosions(Vector3.left));
        CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
        FindObjectOfType<Audiomanager>().Play("Explosion");
        Destroy(tile);
        exploded = true;
        Destroy(gameObject, .3f);
     

    }

    private IEnumerator CreateExplosions(Vector3 direction)
    {
        //1
        for (int i = 1; i < 3; i++)
        {
            //2
            RaycastHit hit;
            //3
            Physics.Raycast(transform.position + new Vector3(0, .5f, 0), direction, out hit,
              i, levelMask);

            //4
            if (!hit.collider)
            {
                Instantiate(explosionPrefab, transform.position + (i * direction),
                  //5 
                  explosionPrefab.transform.rotation);
                //6
            }
            else
            { //7
                break;
            }

            //8
            yield return new WaitForSeconds(.05f);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!exploded && other.CompareTag("Explosion"))
        { // 1 & 2  
            CancelInvoke("Explode"); // 2
            Explode(); // 3
        }

    }

}








