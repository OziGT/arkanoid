using UnityEngine;
using System.IO;

public class GenLevel : MonoBehaviour
{
    public GameObject blockPrefab;
    public Transform blockRoot;
    public Transform topEdge, leftEdge, rightEdge;

	public void Generate(int level, int maxBlockLevel, int maxBlockBonus, int maxAllBonuses,int maxLines, int minumAllBlockLevels, float fallingSpeed)
    {
        string path = @"D:\arkanoid\Assets\Resources\Levels\"+level+".txt";
        if (File.Exists(path))
        {
            File.Delete(path);
        }

        //string text = "5,0.4,0.3,0.2,0.1,0$";
        string text=null;
        int x = 0;
        int y = 0;
        int allBlockLevels = 0;
        int blockBonus, blockLevel, bonusCount = 0; ;
        while(y<=maxLines || allBlockLevels<=minumAllBlockLevels)
        {
            
                if (bonusCount < maxAllBonuses && Random.Range(0, maxLines * 5) < maxAllBonuses)
                {
                    blockBonus = Random.Range(1, maxBlockBonus );
                    bonusCount++;
                }
                else
                {
                    blockBonus = 0;
                }
            
            blockLevel = Random.Range(0, maxBlockLevel + 1);
            text += blockLevel.ToString() + "," + blockBonus.ToString();
            x++;
            allBlockLevels += blockLevel;
            if(x==5)
            {
                y++;
                x = 0;
                text += "$"+System.Environment.NewLine;
            }
            else
            {
                text += ".";
            }
        }
        text += "$";
        File.WriteAllText(path, text);
        Debug.Log(text);
        Debug.Log("wrote level" + level);
    }

    public void Build(int level)
    {
        //string path = @"D:\arkanoid\Assets\Levels\" + level + ".txt";
        //string levelString = File.ReadAllText(path);
        string path = @"Levels\" + level;
        TextAsset levelTxt = Resources.Load(path) as TextAsset;
        string levelString = levelTxt.text;


        string tmp = null;
        int blockLevel=0, blockBonus=0;
        char current;
        int x = 0,y=0;

        for (int i=0;i<levelString.Length;i++)
        {
            current = levelString[i];
            switch(current)
            {
                case ',':
                    int.TryParse(tmp, out blockLevel);
                    tmp = null;
                    break;
                case '.':
                    int.TryParse(tmp, out blockBonus);
                    tmp = null;
                    SpawnBlock(blockLevel, blockBonus, x,y);
                    x++;
                    break;
                case '$':
                    int.TryParse(tmp, out blockBonus);
                    tmp = null;
                    SpawnBlock(blockLevel, blockBonus, x,y);
                    x=0;
                    y++;
                    break;
                default:
                    tmp = tmp + current;
                    break;
            }
        }
        topEdge.localPosition = new Vector3(3.72f, y*0.55f*1.2f+5);
        topEdge.GetComponent<TopEdgeSaveStartPos>().pos = topEdge.localPosition;
        /*
        leftEdge.localScale = new Vector3(3, y * 20,0);
        leftEdge.localPosition = new Vector3(0.66f, (y * 0.55f * 1.2f + 5) / 2, 0);
        rightEdge.localScale = leftEdge.localScale;
        rightEdge.localPosition = new Vector3(6.83f, (y * 0.55f * 1.2f + 5) / 2, 0);
        */
    }
    void SpawnBlock(int blockLevel,int blockBonus,int x,int y)
    {
        if (blockLevel > 0)
        {
            GameObject block = Instantiate(blockPrefab) as GameObject;
            block.transform.parent = blockRoot.transform;
            block.transform.localPosition = new Vector3(0.55f+x * 1.13f, y * 0.55f);
            block.GetComponent<BlockStats>().level = blockLevel;
            block.GetComponent<BlockStats>().bonus = blockBonus;
        }
    }
}
