using UnityEngine;
using System.Collections;

public class exitMap : MonoBehaviour {

	public string[] levels;
	public int levelSelected = 0;

	void Start () {
		levels = new string[10];

		levels [0] = "gameScene";
		levels [1] = "field1";
		levels [2] = "field2";
		levels [3] = "store";
		levels [4] = "storage";

	}
	

	void Update () {
	
	}

	void OnTriggerEnter(Collider col) {
	
		Debug.Log ("hit");

		if(col.gameObject.name == "combineController")
		{
			Debug.Log ("combine entered");
		}
		if(col.gameObject.name == "tractorController")
		{
			Debug.Log ("tractor entered");
		}
		if(col.gameObject.name == "truckController")
		{
			Debug.Log ("truck entered");
		}
	}
}
