using UnityEngine;
using System.Collections;

public class FirstPersonScript : MonoBehaviour {

	[SerializeField]

	public float walkSpeed = 5.0f;

	public Vector3 initPosition = new Vector3(-270.0f,10.0f,170.0f);

	public bool isMove = false;

	private CharacterController characterController = null ;

	private bool isTrigger = false;

	// Use this for initialization
	void Start () {
		characterController = this.GetComponent<CharacterController> ();


	}
	
	// Update is called once per frame
	void Update () {

		float spd = isMove ? walkSpeed : 0.0f;


		if(Cardboard.SDK.Triggered){
			isMove = !isMove;
		}

		Vector3 angle = this.transform.rotation.eulerAngles;
		Vector3 speedVector = new Vector3 (-spd * Mathf.Cos ((angle.y+90.0f)*Mathf.Deg2Rad), 0.0f, spd * Mathf.Sin ((angle.y+90.0f)*Mathf.Deg2Rad));

		characterController.SimpleMove (speedVector);

		if (transform.position.y <= -10.0f)
			transform.position = initPosition;

	
	}

}
