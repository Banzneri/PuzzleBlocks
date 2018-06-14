using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGrid : MonoBehaviour {
	[SerializeField] private int _gridX;
	[SerializeField] private int _gridY;
	[SerializeField] private Transform _startBlockTransform;
	[SerializeField] private Transform _endBlockTransform;
	[SerializeField] private GameObject _basicBlockPrefab;
	[SerializeField] private GameObject _woodBlockPrefab;
	[SerializeField] private GameObject _goldBlockPrefab;
	[SerializeField] private GameObject _grassBlockPrefab;
	[SerializeField] private GameObject _hoverBlock;
	[SerializeField] private BlockPanel _blockPanel;

	[HideInInspector] public bool _canPlace = true;

	private float _width;
	private float _height;
	private bool[,] _gridSpace;

	private Vector2 _currentActiveCoord = Vector2.zero;
	private Vector2 _currentHoverCoord = Vector2.zero;

	void Start () {
		_width = transform.lossyScale.x / _gridX * 10;
		_height = transform.lossyScale.z / _gridY * 10;
		_gridSpace = new bool[_gridX, _gridY];
		_hoverBlock.SetActive(false);
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
				if (x == (int)_currentActiveCoord.x && y == (int)_currentActiveCoord.y)
				{
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
		if (!_canPlace)
		{
			return;
		}
		RaycastHit hit;

		if (GetComponent<Collider>().Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f))
		{
			_currentActiveCoord = GetLocationFromIndex(Mathf.FloorToInt(hit.point.x), Mathf.FloorToInt(hit.point.y));

			if (Input.GetMouseButton(0) && !_gridSpace[(int)_currentActiveCoord.x, (int)_currentActiveCoord.y])
			{
				_gridSpace[(int)_currentActiveCoord.x, (int)_currentActiveCoord.y] = true;
				switch (_blockPanel._currentBlockType)
				{
					case Block.BlockType.Basic: 
						Instantiate(_basicBlockPrefab, GetCenterFromIndex((int)_currentActiveCoord.x, (int)_currentActiveCoord.y), Quaternion.Euler(Vector3.zero));
						break;
					case Block.BlockType.Wood:
						Instantiate(_woodBlockPrefab, GetCenterFromIndex((int)_currentActiveCoord.x, (int)_currentActiveCoord.y), Quaternion.Euler(Vector3.zero));
						break;
					case Block.BlockType.Gold:
						Instantiate(_goldBlockPrefab, GetCenterFromIndex((int)_currentActiveCoord.x, (int)_currentActiveCoord.y), Quaternion.Euler(Vector3.zero));
						break;
					case Block.BlockType.Grass:
						Instantiate(_grassBlockPrefab, GetCenterFromIndex((int)_currentActiveCoord.x, (int)_currentActiveCoord.y), Quaternion.Euler(Vector3.zero));
						break;
				}
			}
			else if (Input.GetMouseButton(1) && _gridSpace[(int)_currentActiveCoord.x, (int)_currentActiveCoord.y])
			{
				_gridSpace[(int)_currentActiveCoord.x, (int)_currentActiveCoord.y] = false;
			}
			else
			{
				_hoverBlock.SetActive(true);
				_hoverBlock.transform.position = GetCenterFromIndex((int)_currentActiveCoord.x, (int)_currentActiveCoord.y);
			}
		}
		else
		{
			_hoverBlock.SetActive(false);
		}
	}
}
