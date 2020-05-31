using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    public GameObject powerUp;
    public GameObject upper, left, lower, right;
    public bool powerupspawn = true;
    private GameObject power = null;

    void speed()
    {
        if (powerUp)
            Destroy(powerUp);

        float x = Random.Range(left.transform.position.x + 0.5f, right.transform.position.x - 0.5f);
        float y = Random.Range(upper.transform.position.y - 0.5f, lower.transform.position.y + 0.5f);
        power = Instantiate(powerUp, new Vector2(x, y), Quaternion.identity);
    }


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("speed", 5, Random.Range(10, 15));
    }

    

    // Update is called once per frame
    void Update()
    {
       
    }
}
