using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBlock : Block {

    private void Start() {
        _blockType = Block.BlockType.Basic;
    }
}