using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterController : MonoBehaviour {
	[SerializeField] private float _moveSpeed = 1;
	[SerializeField] private float _fallSpeed = 100;
	[SerializeField] private float _jumpSpeed = 1;
	[SerializeField] private float _jumpTime = 0.8f;

	private bool _jumping = false;
	
	void Start () {
		
	}
	
	void Update () {
		Move();
		Fall();
		Jump();
	}

	void Move()
	{
		Vector3 newPos = transform.position;
		float smooth = 1f;

		if (Input.GetKey(KeyCode.D))
		{
			Vector3 rot = transform.rotation.eulerAngles;
 			rot.y = 90;
			transform.rotation = Quaternion.Euler(rot);
			if (HitWall())
			{
				return;
			}
			newPos.x += _moveSpeed * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.A))
		{
			Vector3 rot = transform.rotation.eulerAngles;
 			rot.y = -90;
 			transform.rotation = Quaternion.Euler(rot);
			if (HitWall())
			{
				return;
			}
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

	bool HitWall()
	{
		RaycastHit hit;
		float dist = 0.2f;
		Vector3 dir = transform.forward;

		Debug.DrawRay(transform.position, dir * dist, Color.green);

		return Physics.Raycast(transform.position, dir, out hit, dist);
	}

	void Jump()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			StartCoroutine(DoJump());
		}

		if (_jumping)
		{
			Vector3 pos = transform.position;
			pos.y += _jumpSpeed * Time.deltaTime;
			transform.position = pos;
		}
	}

	IEnumerator DoJump()
	{
		_jumping = true;
		yield return new WaitForSeconds(_jumpTime);
		_jumping = false;
	}
}
