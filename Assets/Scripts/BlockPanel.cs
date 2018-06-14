using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPanel : MonoBehaviour {

	public GameObject _hoverBlock;
	public Material _hoverBlockMaterial;
	public Material _woodMaterial;
	public Material _basicMaterial;
	public Material _goldMaterial;
	public Material _grassMaterial;

	[HideInInspector]
	public Block.BlockType _currentBlockType = Block.BlockType.Basic;

	public void SetCurrentBlockBasic()
	{
		_currentBlockType = Block.BlockType.Basic;
		Color color = _basicMaterial.color;
		color.a = _hoverBlockMaterial.color.a;
		_hoverBlockMaterial.color = color;
	}

	public void SetCurrentBlockWood()
	{
		_currentBlockType = Block.BlockType.Wood;
		Color color = _woodMaterial.color;
		color.a = _hoverBlockMaterial.color.a;
		_hoverBlockMaterial.color = color;
	}

	public void SetCurrentBlockGold()
	{
		_currentBlockType = Block.BlockType.Gold;
		Color color = _goldMaterial.color;
		color.a = _hoverBlockMaterial.color.a;
		_hoverBlockMaterial.color = color;
	}

	public void SetCurrentBlockGrass()
	{
		_currentBlockType = Block.BlockType.Grass;
		Color color = _grassMaterial.color;
		color.a = _hoverBlockMaterial.color.a;
		_hoverBlockMaterial.color = color;
	}
}
