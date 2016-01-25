using UnityEngine;
using System.Collections;

public class combine : MonoBehaviour {

	private NavMeshAgent agent;
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	

	void Update () {
		if(vehicleSelected.ID.Equals("combine"))
		{
			agent.SetDestination(mouseTarget.target);
		}

	}
}
