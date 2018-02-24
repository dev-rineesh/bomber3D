using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHandler : MonoBehaviour {

	public WallCubeItemHandler cubeItem1;
	public WallCubeItemHandler cubeItem2;

	WallCubeItemHandler [,] wallItems;

	// Use this for initialization
	void Start () {
		designGrid ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void designGrid(){
		WallCubeItemHandler cube = null;
		wallItems = new WallCubeItemHandler[15,21];
		ushort[,] design = new ushort[15,21]{
			{0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0},
			{0,1,0,1,0,1,0,1,0,1,0,1,2,1,0,1,0,1,0,1,0},
			{0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,0},
			{0,1,0,1,0,1,2,1,0,1,0,1,0,1,0,1,0,1,0,1,0},
			{0,0,0,0,0,0,2,0,0,0,2,0,0,0,0,0,0,0,0,0,0},
			{0,1,2,1,0,1,2,1,0,1,2,1,0,1,2,1,0,1,0,1,0},
			{2,0,2,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0},
			{0,1,2,1,0,1,0,1,0,1,2,1,2,1,2,1,0,1,0,1,0},
			{0,0,0,0,2,2,0,0,0,0,2,2,0,0,0,0,2,2,2,0,0},
			{0,1,0,1,2,1,0,1,0,1,2,1,0,1,0,1,0,1,0,1,0},
			{0,0,0,2,2,2,2,2,2,2,0,0,0,0,0,0,2,2,0,0,0},
			{0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0},
			{0,0,2,2,2,0,0,0,0,0,0,0,0,2,2,2,2,0,0,0,0},
			{0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
		};

		for (int i = 0; i < design.GetLength(0); i++) {//Row
			for (int j = 0; j < design.GetLength (1); j++) {//Column
				switch (design [i, j]) {
				case 0:					
					cube = null;
					break;
				case 1:
					cube = Instantiate (cubeItem1.gameObject).GetComponent<WallCubeItemHandler> ();	
					break;
				case 2:
					cube = Instantiate (cubeItem2.gameObject).GetComponent<WallCubeItemHandler>();
					break;
				default:
					break;
				}
				if(cube != null)
					cube.transform.position = new Vector3 (
					-1*(design.GetLength(1)/2)+j*cube.transform.localScale.x, 
					cube.transform.position.y,
					(design.GetLength(0)/2)-i*cube.transform.localScale.z);
				wallItems [i, j] = cube;
			}
		}
	}
}
