using UnityEngine;
using UnityEngine.Tilemaps;


public class BombSpawner : MonoBehaviour {

	public Tilemap tilemap;

	public GameObject bombPrefab;
    int count = 2;
	

	// Update is called once per frame
	void Update ()
    {
		if (Input.GetMouseButtonDown(0) && count>0 && count <=3)
		{
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3Int cell = tilemap.WorldToCell(worldPos);
			Vector3 cellCenterPos = tilemap.GetCellCenterWorld(cell);


			Instantiate(bombPrefab, cellCenterPos, Quaternion.identity);
            FindObjectOfType<Audiomanager>().Play("Bomb");


            count--;
		}
	}
}
