using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatelevels : MonoBehaviour
{

    public GenLevel gl;
    int maxblocklevel = 1, maxblocklevelCount = 0;
    int maxblockbonus = 0, maxblockbonusCount = 0;
    int maxAllBonus = 0, maxAllBonusCount = 0;
    int maxLines = 1, maxLinesCount = 0;

    public void gen()
    {
        StartCoroutine(genCon());
    }

    IEnumerator genCon()
    {
        for (int i = 0; i < 100; i++)
        {
            Debug.Log(i);
            gl.Generate(i, maxblocklevel, maxblockbonus, maxAllBonus,maxLines,i*4,0);

            if (maxblocklevel < 6)
            {
                if (maxblocklevelCount++ > 3)
                {
                    maxblocklevel++;
                    maxblocklevelCount = 0;
                }
            }
            if (maxblockbonus < 5)
            {
                if (maxblockbonusCount++ > 8)
                {
                    maxblockbonus++;
                    maxblockbonusCount = 0;
                }
            }
            if (maxAllBonusCount++ > 8)
            {
                maxAllBonus++;
                maxAllBonusCount = 0;
            }
            if (i < 10)
            {
                if (maxLinesCount++ > 1)
                {
                    maxLines ++;
                    maxLinesCount = 0;
                }
            }
            else if(i<30)
            {
                if (maxLinesCount++ > 2)
                {
                    maxLines+=2;
                    maxLinesCount = 0;
                }
            }
            else if (i < 60)
            {
                if (maxLinesCount++ > 2)
                {
                    maxLines ++;
                    maxLinesCount = 0;
                }
            }
            yield return null;
        }
    }
}
