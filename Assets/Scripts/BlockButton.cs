using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockButton : MonoBehaviour {
	private BlockGrid _grid;
	private BlockPanel _blockPanel;

	private void Start() {
		_grid = GameObject.FindGameObjectWithTag("BlockGrid").GetComponent<BlockGrid>();
		_blockPanel = GetComponentInParent<BlockPanel>();
	}

	public void MyOnHoverEnter()
	{
		_grid.HoverBlock.SetActive(false);
		_grid._canPlace = false;
		_blockPanel._hoverBorder.SetActive(true);
		_blockPanel._hoverBorder.transform.position = transform.position;
	}

	public void MyOnHoverExit()
	{
		_grid.HoverBlock.SetActive(true);
		_grid._canPlace = true;
		_blockPanel._hoverBorder.SetActive(false);
	}
}
