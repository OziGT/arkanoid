using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHit : MonoBehaviour
{
    public BlockStats blockStats;
    public SpriteRenderer sprite;
    public Ball ball;
    public GameObject spriteObject;
    public TextMesh text;

    private void Start()
    {
        ChangeColor(blockStats.level);
        text.text = blockStats.level.ToString();
    }

    private void Awake()
    {
        ball = GameManager.instance.ball;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer==9)
        {
            blockStats.level -= ball.power;
            if(blockStats.level<=0)
            {
                SoundManager.instance.BlockBreak();
                spriteObject.SetActive(false);
                SpawnBonus();
                GameManager.instance.breakBlock();
                ParticleManager.instance.SpawnBlockExplode(transform.position);
            }
            else
            {
                ChangeColor(blockStats.level);
                text.text = blockStats.level.ToString();
            }
        }
    }

    void ChangeColor(int level)
    {
        switch (level)
        {
            case 1:
                sprite.color = Color.white;
                break;
            case 2:
                sprite.color = Color.cyan;
                break;
            case 3:
                sprite.color = Color.blue;
                break;
            case 4:
                sprite.color = Color.green;
                break;
            case 5:
                sprite.color = Color.yellow;
                break;
            case 6:
                sprite.color = Color.red;
                break;
        };
    }

    void SpawnBonus()
    {
        if(blockStats.bonus>0)
        {
            BonusManager.instance.Spawn(blockStats.bonus, transform.position);
        }
    }
}
