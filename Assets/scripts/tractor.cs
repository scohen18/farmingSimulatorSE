using UnityEngine;
using System.Collections;

public class tractor : MonoBehaviour {


	private NavMeshAgent agent;
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	

	void Update () {
		if(vehicleSelected.ID.Equals("tractor"))
		{
			agent.SetDestination(mouseTarget.target);
		}
	}
}
