using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GenLevel genLevel;
    public int level,lives;
    public int maxLevel;
    public Ball ball;
    public Rigidbody2D ballRB;
    public Transform map;
    public GameObject game,menu;
    public float fallingSpeed;
    public LiveMatter[] liveMatter;
    public GameObject startHUD;
    public BarFollowBall barFollowBall;
    public FallingDown fallingDown;
    public GameObject gameOverMenu, winLevelMenu;
    public int blocksLeft;
    public GameObject shoot;
    public Save save;
    public GameObject zeroBallGetExtra;
    int previousBlockLeft = 0;
    public TopEdgeSaveStartPos topEdgeSaveStartPos;
    public bool finished = false;
    public int lastDay;
    public GameObject daily;
    public Transform ballTransform;
    public GameObject tutorial;
    public Bonus1[] bonus1;

    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        save.LoadGameValues();
        Daily();
    }

    public void GoToMenu()
    {
        game.SetActive(false);
        menu.SetActive(true);
    }

    public void Daily()
    {
        if(lastDay!= System.DateTime.Now.Day)
        {
            daily.SetActive(true);
            lives += 5;
            save.SaveGameValues();
        }
    }

    public void LevelStart()
    {
        foreach(Bonus1 bonus1s in bonus1)
        {
            bonus1s.EndBonus();
        }
        menu.SetActive(false);
        game.SetActive(true);
        map.position = new Vector3(-2.8f, 3, 0);
        foreach(Transform child in map)
        {
            GameObject.Destroy(child.gameObject);
        }
        genLevel.Build(level);
        blocksLeft = map.childCount-previousBlockLeft;
        previousBlockLeft = blocksLeft;
        shoot.SetActive(false);
        liveMatter[0].UpdateLiveMatter();
        liveMatter[1].UpdateLiveMatter();
        startHUD.SetActive(true);
        barFollowBall.enabled = false;
        fallingDown.enabled = false;
        //fallingSpeed = 12 - (level * 0.08f);
        fallingSpeed = 3.2f;
        if(level==0)
        {
            tutorial.SetActive(true);
        }
    }

    public void ContinueLevel()
    {
        gameOverMenu.SetActive(false);
        lives += 40;

        startHUD.SetActive(true);
        barFollowBall.enabled = false;
        fallingDown.enabled = false;
        fallingSpeed = 3.2f;
        map.localPosition = new Vector3(-2.8f, 3, 0);
        topEdgeSaveStartPos.ResetPos();
        liveMatter[0].UpdateLiveMatter();
        liveMatter[1].UpdateLiveMatter();

    }

    public void LostLive()
    {
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        lives--;
        save.SaveGameValues();
        if (lives < 0)
        {
            lives = -1;
            zeroBallGetExtra.SetActive(true);
            gameOverMenu.SetActive(true);
            barFollowBall.enabled = false;
            fallingDown.enabled = false;
            ballRB.velocity = Vector2.zero;
            ballTransform.position = new Vector3(0, -100, 0);
        }
        else
        {
            shoot.SetActive(false);
            liveMatter[0].UpdateLiveMatter();
            liveMatter[1].UpdateLiveMatter();
            startHUD.SetActive(true);
            barFollowBall.enabled = false;
            fallingDown.enabled = false;
        }
    }

    public void BlockHitBottom()
    {
        zeroBallGetExtra.SetActive(false);
        gameOverMenu.SetActive(true);
        barFollowBall.enabled = false;
        fallingDown.enabled = false;
        ballRB.velocity = Vector2.zero;
        ballTransform.position = new Vector3(0, -100, 0);


    }

    public void breakBlock()
    {
        blocksLeft--;
        if(blocksLeft==0)
        {
            barFollowBall.enabled = false;
            fallingDown.enabled = false;
            winLevelMenu.SetActive(true);
            lives += 2;
            level++;
            save.SaveGameValues();
            ballRB.velocity = Vector2.zero;
            ballTransform.position = new Vector3(0, -100, 0);
            AdManager.instance.InterAd();
            if(level==100)
            {
                level = 0;
                lives = 100;
                finished = true;
                save.SaveGameValues();
            }
        }
    }

    public void CheckIfAnyBlocksAreLeft()
    {
        if (blocksLeft == 0)
        {
            barFollowBall.enabled = false;
            fallingDown.enabled = false;
            winLevelMenu.SetActive(true);
            lives += 2;
            level++;
            save.SaveGameValues();
            ballRB.velocity = Vector2.zero;
            ballTransform.position = new Vector3(0, -100, 0);
            AdManager.instance.InterAd();
            if (level == 100)
            {
                level = 0;
                lives = 100;
                finished = true;
                save.SaveGameValues();
            }
        }
    }
}
