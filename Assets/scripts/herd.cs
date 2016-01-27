using UnityEngine;
using System.Collections;

public class herd : MonoBehaviour {

	public float x;
	public float y;
	public int w;
	public int h;
//	private Bounds range;
	public float timer;
	public float timerMax = 20;
	public int moveRange = 3;
	public int grazingRange = 10;

	private NavMeshAgent agent;

	public Vector3 dest;

	public bool moving;

	// Use this for initialization
	void Start () {
		this.x = this.transform.position.x;
		this.y = this.transform.position.z;
//		this.y = 0;
		this.w = 40;
		this.h = 40;
		this.timer = timerMax;
		this.agent = GetComponent<NavMeshAgent>();
		dest = this.transform.position;
//		this.range = new Bounds (Vector3 (0, 0, 0), Vector3 (10, 0, 10));
		moving = false;
	}

	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer < 0) {
			timer = timerMax * Random.Range (0.9f,1.2f);
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
			dest = new Vector3(x,0,y);
			agent.SetDestination(dest);
//			Debug.Log ("Moving by: " + rx + ", " + ry);
//			Debug.Log ("New location: " + x + ", " + y);
			moving = true;
		}

		if (Vector3.Distance (this.transform.position, this.dest) <= 1) {
			// has reached destination
			moving = false;
		}

	}
}
