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
	[SerializeField] private LayerMask _blockLayer;

	public GameObject HoverBlock
	{
		get { return _hoverBlock; }
	}

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

	/*private void OnDrawGizmos() {
		float gridX = 100;
		float gridY = 100;
		
		for (int y = 0; y < gridY; y++)
		{
			for (int x = 0; x < gridX; x++)
			{
				Gizmos.color = Color.red;
				if (x == (int)_currentActiveCoord.x && y == (int)_currentActiveCoord.y)
				{
					Gizmos.color = Color.green;
				}
				float width = transform.lossyScale.x / gridX * 10;
				float height = transform.lossyScale.z / gridY * 10;
				Vector3 center = new Vector3(x * width + width / 2 - gridX * width / 2, y * height + height / 2 - gridY * height / 2, 0);
				Vector3 size = new Vector3(_width - 0.03f, _height - 0.03f, 0);

				Gizmos.DrawWireCube(center, size);
			}
		}
	}*/

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

		if (GetComponent<Collider>().Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000f))
		{

			_currentActiveCoord = GetLocationFromIndex(Mathf.FloorToInt(hit.point.x), Mathf.FloorToInt(hit.point.y));
			Vector3 centerPos = GetCenterFromIndex((int)_currentActiveCoord.x, (int)_currentActiveCoord.y);

			if (Input.GetMouseButton(1))
			{
				Collider[] cols = Physics.OverlapSphere(centerPos, _width / 3, _blockLayer);
				if (cols.Length > 0)
				{
					_gridSpace[(int)_currentActiveCoord.x, (int)_currentActiveCoord.y] = false;
					Destroy(cols[0].transform.gameObject);
				}
			}

			if (Input.GetMouseButton(0))
			{
				if (!_gridSpace[(int)_currentActiveCoord.x, (int)_currentActiveCoord.y])
				{
					_gridSpace[(int)_currentActiveCoord.x, (int)_currentActiveCoord.y] = true;
					InstantiateBlock(_blockPanel._currentBlockType, centerPos);	
				}
			}
			_hoverBlock.SetActive(true);
			_hoverBlock.transform.position = centerPos;
		}
		else
		{
			_hoverBlock.SetActive(false);
		}
	}

	public void InstantiateBlock(Block.BlockType type, Vector3 position)
	{
		switch (type)
		{
			case Block.BlockType.Basic: 
				Instantiate(_basicBlockPrefab, position, Quaternion.Euler(Vector3.zero));
				break;
			case Block.BlockType.Wood:
				Instantiate(_woodBlockPrefab, position, Quaternion.Euler(Vector3.zero));
				break;
			case Block.BlockType.Gold:
				Instantiate(_goldBlockPrefab, position, Quaternion.Euler(Vector3.zero));
				break;
			case Block.BlockType.Grass:
				Instantiate(_grassBlockPrefab, position, Quaternion.Euler(Vector3.zero));
				break;
		}
	}
}
