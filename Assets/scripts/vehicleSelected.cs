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

	public Button erasePins;
	public Button selectCombine;
	public Button selectTruck;
	public Button selectTractor;

	public Button none;

	public static bool deletePins = false;

	int i = 0;
	int j = 0;
	void Start () {
		vehicleList = new string[4];

		vehicleList [0] = "combine";
		vehicleList [1] = "truck";
		vehicleList [2] = "tractor";
		vehicleList [3] = "none";

		waypoints = new Vector3[10];
		pins = new GameObject[10];


		erasePins.onClick.AddListener(delegate() { destroyPins(); });
		selectCombine.onClick.AddListener(delegate() {i = 0; });
		selectTruck.onClick.AddListener(delegate() {i = 1; });
		selectTractor.onClick.AddListener(delegate() {i = 2; });
		none.onClick.AddListener(delegate() {i = 3; });


	}
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Tab)) {
			i ++;
			if(i == 4)
			{
				i = 0;
			}
		}
		if (Input.GetKey(KeyCode.LeftShift)) {
			assignWaypoints();
		}
		ID = vehicleList[i];
		vehicleSelectedText.text = "controlling " + ID;

		if (j == 10) {

			destroyPins();
		}
	}
	void assignWaypoints()
	{
		if (Input.GetKey (KeyCode.LeftShift)) {
			if (Input.GetMouseButtonDown(0) && j < 10) {

				j ++;

				if(deletePins)
				{
					j = 0;
					deletePins = false;
					destroyPins();
				}

				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out hit))
				{
					if (hit.collider != null)
					{
						waypoints[j] = hit.point;
						Instantiate(pin, hit.point, Quaternion.identity);
						//Debug.Log("instinated pin " + j + " @ " + waypoints[j].x + "," + waypoints[j].x + "," + waypoints[j].x);
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
			waypoints[k] = new Vector3(0,0,0);
		}
	}
	
}
