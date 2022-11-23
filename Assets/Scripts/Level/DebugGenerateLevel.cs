using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGenerateLevel : MonoBehaviour {

    public GenLevel genLevel;
    public int level, maxBlockLevel, maxBlockBonus, maxAllBonuses, maxLines, minumAllBlockLevels;
    public float fallingSpeed;

    public void Generate()
    {
        genLevel.Generate(level, maxBlockLevel, maxBlockBonus, maxAllBonuses, maxLines, minumAllBlockLevels, fallingSpeed);
    }
}
