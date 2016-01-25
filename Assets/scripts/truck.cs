using UnityEngine;
using System.Collections;

public class truck : MonoBehaviour {

	private NavMeshAgent agent;
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	

	void Update () {
		if(vehicleSelected.ID.Equals("truck"))
		{
			agent.SetDestination(mouseTarget.target);
		}
	}
}
