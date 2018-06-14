using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockButton : MonoBehaviour {
	private BlockGrid _grid;

	private void Start() {
		_grid = GameObject.FindGameObjectWithTag("BlockGrid").GetComponent<BlockGrid>();
	}

	public void DisablePlacement() {
		_grid._canPlace = false;
	}

	public void EnablePlacement() {
		_grid._canPlace = true;
	}
}
