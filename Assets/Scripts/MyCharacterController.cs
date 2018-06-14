using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterController : MonoBehaviour {
	[SerializeField] private float _moveSpeed = 1;
	[SerializeField] private float _fallSpeed = 100;
	[SerializeField] private float _jumpSpeed = 1;
	[SerializeField] private float _jumpTime = 0.8f;

	private bool _jumping = false;
	private Rigidbody _rb;
	
	void Start () {
		_rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
		Move();
		Jump();
	}

	void Move()
	{
		Vector3 velocity = _rb.velocity;
		velocity.x = 0f;

		if (Input.GetKey(KeyCode.D))
		{
			Vector3 rot = transform.rotation.eulerAngles;
 			rot.y = 90;
			transform.rotation = Quaternion.Euler(rot);
			velocity.x = 4f;
		}
		else if (Input.GetKey(KeyCode.A))
		{
			Vector3 rot = transform.rotation.eulerAngles;
 			rot.y = -90;
 			transform.rotation = Quaternion.Euler(rot);
			velocity.x = -4f;
		}

		_rb.velocity = velocity;
	}

	void Jump()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			_rb.AddForce(Vector3.up * 240, ForceMode.Impulse);	
		}
	}
}
