using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Block : MonoBehaviour {
    public Material _material;
    [HideInInspector] public BlockType _blockType;

    private void Start() {
        
    }

    public enum BlockType
    {
        Basic,
        Wood,
        Ladder,
        Gold,
        Grass,
        Dirt
    }
}
