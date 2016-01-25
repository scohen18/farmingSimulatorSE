using UnityEngine;
using System.Collections;

public class mouseTarget : MonoBehaviour {
	public static Vector3 target;
	void Start () {
	
	}
	void Update(){
		if (Input.GetMouseButtonDown(0) && !Input.GetKey (KeyCode.LeftShift)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider != null)
				{
					target = hit.point;
				}
			}
		}
	}
}