using UnityEngine;
using System.Collections;

public class ChanTouchMove : MonoBehaviour {
	public GameObject Chan;
	public Camera cam;
	public LayerMask inputMask;
	private Vector3 targetPos;
	private Vector3 lookRotation;
	public float movSpeed=0.5f;
	//private Animator ani;
	//public SapphiArtChan_AnimManager AnimManger;
	public int flag=2;
	// Use this for initialization
	void Start () {
		cam = this.gameObject.GetComponent<Camera>();
		//ani = this.gameObject.GetComponent<Animator> ();
		//AnimManger = GameObject.FindGameObjectWithTag ("Player").GetComponent<SapphiArtChan_AnimManager>();;
		targetPos = Chan.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//AnimatorStateInfo stateInfo = ani.GetCurrentAnimatorStateInfo(0);
		if (Input.GetMouseButton (0)) {
			Vector3 ms = Input.mousePosition;
			Ray ray = cam.ScreenPointToRay (ms);
			RaycastHit hit;
			bool iscast = Physics.Raycast (ray,out hit,1000,inputMask);
			if (iscast) {
				targetPos = new Vector3 (hit.point.x,Chan.transform.position.y,hit.point.z);
				lookRotation = targetPos - Chan.transform.position;
			}

		}

		Chan.transform.position = Vector3.MoveTowards (Chan.transform .position,targetPos,Time.deltaTime*movSpeed);
		Chan.transform.rotation = Quaternion.Lerp (Chan.transform.rotation,Quaternion.LookRotation(lookRotation),Time.deltaTime*5f);

		if (Vector3.SqrMagnitude(targetPos-Chan.transform.position)<0.01f) 
		{
			 //ani.SetBool ("param_idletowalk", false);
			  //AnimManger._SapphiArtChanAnimation  = null;
			flag=0;
			Debug.Log ("Success");
		} 
		else
		{
			//ani.SetBool ("param_idletowalk",true);
			//AnimManger._SapphiArtChanAnimation  = "walk"; 
			flag=1;
			Debug.Log ("Fail");
		}
	}
}
