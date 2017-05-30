using UnityEngine;
using System.Collections;

public class SapphiArtChan_HeadMask : MonoBehaviour {
	public Camera cam;
	private Animator ani;
	// Use this for initialization
	void Start () {
		ani = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnAnimatorIK()
	{
		ani.SetLookAtWeight (0.7f,0.3f,1,1);
		ani.SetLookAtPosition (cam.transform.position);
	}
}
