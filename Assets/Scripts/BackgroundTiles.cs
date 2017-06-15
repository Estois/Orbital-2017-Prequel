using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTiles : MonoBehaviour
{
	//array of prefab tiles
	public GameObject[] tile;

	//start position to spawn tiles
	public Vector3 tileStartPosition;

	//tile spacing
	Vector2 tileSpacing;

	//width of grid
	public int gridWidth;

	//height of grid
	public int gridHeight;

	void Start ()
	{
		//get exact size of tiles
		tileSpacing = tile [0].GetComponent<Renderer> ().bounds.size;

		for (int i = 0; i < gridHeight; i++) {
			for (int j = 0; j < gridWidth; j++) {
				//randomise the tiles and place it into the background
				int randomTile = Random.Range (0, tile.Length);

				//starting at our start position.x plus the tileSpacing.x width times the count of the grid width
				//done similarly with the height
				//using a quaternion.identity as there is no rotation in the z-axis

				GameObject go = Instantiate (tile [randomTile], new Vector3 (tileStartPosition.x + (j * tileSpacing.x), tileStartPosition.y + (i * tileSpacing.y)), Quaternion.identity) as GameObject;


				//add all the game objects as a child of BGTiles
				go.transform.parent = GameObject.Find ("BGTiles").transform;
			}
		}

	}

}
