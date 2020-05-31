using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Bomb : MonoBehaviour {

	public float countdown = 2f;


    // Update is called once per frame
    void Update () {
		countdown -= Time.deltaTime;

		if (countdown <= 0f)
		{
			FindObjectOfType<MapDestroyer>().Explode(transform.position);
            CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
			Destroy(gameObject);
		}
	}
}
