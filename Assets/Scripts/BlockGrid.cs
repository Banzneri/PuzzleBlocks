using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGrid : MonoBehaviour {
	[SerializeField] private int _gridX;
	[SerializeField] private int _gridY;
	[SerializeField] private GameObject _basicBlockPrefab;

	private float _width;
	private float _height;

	private Vector2 _currentHoveredCoord = Vector2.zero;

	void Start () {
		_width = transform.lossyScale.x / _gridX * 10;
		_height = transform.lossyScale.z / _gridY * 10;
	}
	
	void Update () {
		HandleClicking();
	}

	private void OnDrawGizmos() {
		_gridX = 20;
		_gridY = 20;
		for (int y = 0; y < _gridY; y++)
		{
			for (int x = 0; x < _gridX; x++)
			{
				Gizmos.color = Color.red;
				if (x == (int)_currentHoveredCoord.x && y == (int)_currentHoveredCoord.y)
				{
					Debug.Log("Yes");
					Gizmos.color = Color.green;
				}
				float width = transform.lossyScale.x / _gridX * 10;
				float height = transform.lossyScale.z / _gridY * 10;
				Vector3 center = new Vector3(x * width + width / 2 - _gridX * width / 2, y * height + height / 2 - _gridY * height / 2, 0);
				Vector3 size = new Vector3(_width - 0.03f, _height - 0.03f, 0);

				Gizmos.DrawWireCube(center, size);
			}
		}
	}

	private Vector2 GetLocationFromIndex(int x, int y)
	{
		Vector2 center = new Vector2((x + _gridX * _width / 2) * _width, (y + _gridX * _height / 2) * _height);
		return center;
	}

	private Vector3 GetCenterFromIndex(int x, int y)
	{
		Vector3 center = new Vector3(x * _width + _width / 2 - _gridX * _width / 2, y * _height + _height / 2 - _gridY * _height / 2, 0);
		return center;
	}

	private void HandleClicking()
	{
		RaycastHit hit;
		if (Input.GetMouseButtonDown(0))
        {
            if(GetComponent<Collider>().Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f))
			{
				_currentHoveredCoord = GetLocationFromIndex(Mathf.FloorToInt(hit.point.x), Mathf.FloorToInt(hit.point.y));
				Instantiate(_basicBlockPrefab, GetCenterFromIndex((int)_currentHoveredCoord.x, (int)_currentHoveredCoord.y), Quaternion.Euler(Vector3.zero));
			}
			//Debug.Log(hit.point.x + " " + hit.point.y);
			Debug.Log(_currentHoveredCoord);
        }
	}
}
