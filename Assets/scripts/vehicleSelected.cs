using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class vehicleSelected : MonoBehaviour {

	public static string ID = "";
	public string[] vehicleList;

	public GameObject pin;

	public static Vector3[] waypoints;

	public Text vehicleSelectedText;

	public GameObject[] pins;

	int i = 0;
	int j = 0;
	void Start () {
		vehicleList = new string[3];

		vehicleList [0] = "combine";
		vehicleList [1] = "truck";
		vehicleList [2] = "tractor";

		waypoints = new Vector3[10];
		pins = new GameObject[10];


	}
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Tab)) {
			i ++;
			if(i == 3)
			{
				i = 0;
			}
		}
		if (Input.GetKey(KeyCode.LeftShift)) {
			assignWaypoints();
		}
		ID = vehicleList[i];
		vehicleSelectedText.text = "controlling " + ID;
		Debug.Log (j);
		if (j == 10) {

			destroyPins();
		}
	}
	void assignWaypoints()
	{
		if (Input.GetKey (KeyCode.LeftShift)) {
			if (Input.GetMouseButtonDown(0) && j < 10) {

				j ++;

				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out hit))
				{
					if (hit.collider != null)
					{
						waypoints[j] = hit.point;
						Instantiate(pin, hit.point, Quaternion.identity);
					}
				}
			}
		}
	}
	void destroyPins()
	{
		pins = GameObject.FindGameObjectsWithTag ("pin");
		
		for(int k = 0 ; k < pins.Length ; k ++)
		{
			Destroy(pins[k]);
		}
	}
	
}
