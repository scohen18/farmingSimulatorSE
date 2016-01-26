using UnityEngine;
using System.Collections;

public class wheatController : MonoBehaviour {
	
	public float growthSpeed = 0.0f;

	void Start () {

	}

	void Update () {
		if (this.transform.localScale.z <= 0.5f) {
			transform.localScale += new Vector3(0, 0, growthSpeed * Time.deltaTime);

		}
	}
}
