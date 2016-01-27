using UnityEngine;
using System.Collections;

public class CowMove : MonoBehaviour {

	public float x;
	public float y;
	public herd h;
	public float speed = 1;

	public float timer;
	public float timerMax = 10;
//	public Vector3 dest;

	public float moveRange = 1;
	public float grazingRange = 10;

	private NavMeshAgent agent;

//	private GameObject parent;

	// Use this for initialization
	void Start () {
//		h = transform.parent.gameObject.GetComponent<herd> ();
//		this.dest = this.transform.localPosition;
		this.x = this.transform.position.x;
		this.y = this.transform.position.z;
//		this.moveRange = 1;
//		this.grazingRange = 10;
		this.agent = GetComponent<NavMeshAgent>();
//		this.timerMax = 3;
//		this.transform.localPo
//		this.parent = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log ("ME: " + h.x + ", " + h.y);
		timer -= Time.deltaTime;
		if (timer < 0) {
//			Debug.Log ("Moving");
			timer = timerMax * Random.Range (0.9f,1.6f);
			//			Debug.Log("Time to move");
			float rx;
			float ry;
			if(this.transform.position.x>grazingRange){
				rx = Random.Range(-moveRange,0);
			}else if(this.transform.position.x<-grazingRange){
				rx = Random.Range (0,moveRange);
			}else{
				rx = Random.Range (-moveRange,moveRange);
			}
			if(this.transform.position.z>grazingRange){
				ry = Random.Range(-moveRange,0);
			}else if(this.transform.position.z<-grazingRange){
				ry = Random.Range (0,moveRange);
			}else{
				ry = Random.Range (-moveRange,moveRange);
			}
			//			int rx = Random.Range(-10,10);
			//			int ry = Random.Range (-10,10);
			x += rx;
			y += ry;

//			this
//			agent.SetDestination(new Vector3(x,0,y));
			//			Debug.Log ("Moving by: " + rx + ", " + ry);
			//			Debug.Log ("New location: " + x + ", " + y);
			agent.SetDestination(new Vector3( x,1, y));
		}
		if (timer < 5){
			agent.SetDestination(this.transform.position);
		}
//		Debug.Log ("________");
//		Debug.Log (transform.localPosition);
//		Debug.Log (new Vector3(x,0,y));
//		agent.SetDestination(new Vector3(parent.transform.position.x + x,0,parent.transform.position.z + y));
//		transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(x,0,y), speed*Time.deltaTime);

	}
}
