using UnityEngine;
using System.Collections;

public class herd : MonoBehaviour {

	public int x;
	public int y;
	public int w;
	public int h;
//	private Bounds range;
	public int timer;
	public int timerMax = 300;
	public int moveRange = 3;
	public int grazingRange = 10;

	private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		this.x = 0;
		this.y = 0;
		this.w = 40;
		this.h = 40;
		this.timer = timerMax;
		this.agent = GetComponent<NavMeshAgent>();
//		this.range = new Bounds (Vector3 (0, 0, 0), Vector3 (10, 0, 10));

	}

	// Update is called once per frame
	void Update () {
		timer--;
		if (timer < 0) {
			timer = timerMax;
			Debug.Log("Time to move");
			int rx;
			int ry;
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
			x+= rx;
			y+= ry;
			agent.SetDestination(new Vector3(x,0,y));
			Debug.Log ("New location: " + x + ", " + y);
		}
	}
}
