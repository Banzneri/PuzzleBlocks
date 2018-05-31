using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterController : MonoBehaviour {
	[SerializeField] private float _moveSpeed = 1;
	[SerializeField] private float _fallSpeed = 100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Move();
		Fall();
	}

	void Move()
	{
		Vector3 newPos = transform.position;
		if (Input.GetKey(KeyCode.D))
		{
			newPos.x += _moveSpeed * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.A))
		{
			newPos.x -= _moveSpeed * Time.deltaTime;
		}
		transform.position = newPos;
	}

	void Fall()
	{
		RaycastHit hit;
		float dist = 0.5f;
		Vector3 dir = new Vector3(0,-1,0);

		Debug.DrawRay(transform.position, dir * dist, Color.green);

		if(!Physics.Raycast(transform.position, dir, out hit, dist))
		{
			Vector3 newPos = transform.position;
			newPos.y -= _fallSpeed * Time.deltaTime;
			transform.position = newPos;
		}
	}
}
