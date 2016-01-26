using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class combine : MonoBehaviour {
	public int deadzone = 0;
	private NavMeshAgent agent;
	public Button executePins;

	public bool tracking = false;

	public int currentWaypoint = 0;

	public Text enabledDisabled;

	void Start () {
		agent = GetComponent<NavMeshAgent>();
		executePins.onClick.AddListener(delegate() { tracking = !tracking; });

	}
	

	void Update () {

		if (tracking) {
			enabledDisabled.text = "enabled";
			enabledDisabled.color = Color.green;
		} else {
			enabledDisabled.text = "disabled";
			enabledDisabled.color = Color.red;
		}
		if(vehicleSelected.ID.Equals("combine"))
		{
			if(!tracking)
			{
				agent.SetDestination(mouseTarget.target);
			}
			else{
				Vector3 tempLocalPosition;
				Vector3 tempWaypointPosition;

				tempLocalPosition = transform.position;
				tempLocalPosition.y = 0f;
				tempWaypointPosition = vehicleSelected.waypoints[currentWaypoint];
				tempWaypointPosition.y = 0f;

				if (Vector3.Distance (tempLocalPosition, tempWaypointPosition) <= deadzone) {
					currentWaypoint ++;
					if(vehicleSelected.waypoints[currentWaypoint].Equals(new Vector3(0,0,0)))
					{
						tracking = false;
						currentWaypoint = 0;
						vehicleSelected.deletePins = true;
					}
					                                         
				}

				agent.SetDestination (vehicleSelected.waypoints[currentWaypoint]);
			}
		}
	}
}
