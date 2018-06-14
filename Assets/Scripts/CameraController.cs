using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	[SerializeField] private GameObject _player;
	[SerializeField] private float _offsetY;
	
	void Start () {
		
	}
	
	void Update () {
		Vector3 pos = transform.position;
		pos.x = _player.transform.position.x;
		pos.y = _player.transform.position.y + _offsetY;
		transform.position = pos;
	}
}
