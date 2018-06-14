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
	public GameObject _hoverBorder;

	[SerializeField] private GameObject _basicBlock;
	[SerializeField] private GameObject _woodBlock;
	[SerializeField] private GameObject _goldBlock;
	[SerializeField] private GameObject _grassBlock;
	[SerializeField] private GameObject _activeBorder;

	[HideInInspector]
	public Block.BlockType _currentBlockType = Block.BlockType.Basic;

	public void SetCurrentBlockBasic()
	{
		_currentBlockType = Block.BlockType.Basic;
		Color color = _basicMaterial.color;
		color.a = _hoverBlockMaterial.color.a;
		_hoverBlockMaterial.color = color;
		_activeBorder.transform.position = _basicBlock.transform.position;
	}

	public void SetCurrentBlockWood()
	{
		_currentBlockType = Block.BlockType.Wood;
		Color color = _woodMaterial.color;
		color.a = _hoverBlockMaterial.color.a;
		_hoverBlockMaterial.color = color;
		_activeBorder.transform.position = _woodBlock.transform.position;
	}

	public void SetCurrentBlockGold()
	{
		_currentBlockType = Block.BlockType.Gold;
		Color color = _goldMaterial.color;
		color.a = _hoverBlockMaterial.color.a;
		_hoverBlockMaterial.color = color;
		_activeBorder.transform.position = _goldBlock.transform.position;
	}

	public void SetCurrentBlockGrass()
	{
		_currentBlockType = Block.BlockType.Grass;
		Color color = _grassMaterial.color;
		color.a = _hoverBlockMaterial.color.a;
		_hoverBlockMaterial.color = color;
		_activeBorder.transform.position = _grassBlock.transform.position;
	}

	public void SetHoverOnBlock()
	{

	}
}
