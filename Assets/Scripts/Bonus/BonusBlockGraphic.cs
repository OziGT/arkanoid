using UnityEngine;

public class BonusBlockGraphic : MonoBehaviour
{
    public GameObject[] sprites;
    public BonusBlock bonusBlock;
    
    public void Show() 
    { 
        foreach(var sprite in sprites)
        {
            sprite.SetActive(false);
        }
        sprites[bonusBlock.bonus-1].SetActive(true);
    }
}
