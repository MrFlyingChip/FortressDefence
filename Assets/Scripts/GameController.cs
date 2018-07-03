using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public int currentGold;
    public UIController uiController;
    public ForstressController forstressController;
    public ArcherSpawner archerSpawner;

    public List<ArcherController> archers = new List<ArcherController>();

    public int archerMaxLevel;
    public int archerBuyCost;
    public int[] archerUpgradeCost;

    public Sprite enableSprite;
    public Sprite disableSprite;

    public float minEnemySpawnTime;
    public float maxEnemySpawnTime;

    public List<EnemyController> enemies = new List<EnemyController>();
    public int pointsToWinGame;

    public EnemySpawner enemySpawner;

    // Use this for initialization
    void Start () {
        uiController.ShowGold(currentGold);
        StartCoroutine(Game());
	}
	
    public void BuyArcher()
    {
        if(currentGold >= archerBuyCost && archers.Count < 3)
        {
            archers.Add(archerSpawner.SpawnArcher(archers.Count));
            currentGold -= archerBuyCost;
            uiController.ShowGold(currentGold);
            CheckArcherUpgrade();
        }      
    }

    public void UpgradeArcher(ArcherController archer)
    {
        if(archer.level < archerMaxLevel && archerUpgradeCost[archer.level] <= currentGold)
        {           
            currentGold -= archerUpgradeCost[archer.level];
            archer.LevelUp();
            uiController.ShowGold(currentGold);
            CheckArcherUpgrade();
        }
    } 

    private void CheckArcherUpgrade()
    {
        foreach (var archer in archers)
        {
            if (archer.level == archerMaxLevel || archerUpgradeCost[archer.level] > currentGold)
            {
                archer.SetUpgradeButtonSprite(disableSprite);
            }
            else
            {
                archer.SetUpgradeButtonSprite(enableSprite);
            }
        }
    }

    public void GainGold(int gold)
    {
        currentGold += gold;
        uiController.ShowGold(currentGold);
        CheckArcherUpgrade();
    }

    IEnumerator Game()
    {
        while(pointsToWinGame > 0)
        {
            float nextEnemy = Random.Range(minEnemySpawnTime, maxEnemySpawnTime);
            if (minEnemySpawnTime > 0) minEnemySpawnTime -= 0.05f;
            if (maxEnemySpawnTime > minEnemySpawnTime) maxEnemySpawnTime -= 0.05f;
            yield return new WaitForSeconds(nextEnemy);
            EnemyController newEnemy = enemySpawner.SpawnEnemy();
            pointsToWinGame -= newEnemy.points;
            enemies.Add(newEnemy);
        }
        while(enemies.Count > 0)
        {
            yield return 0;
        }
        WinGame();
    }

    public void DeleteEnemy(EnemyController enemy)
    {
        enemies.Remove(enemy);
    }

    public void GainDamageToForstress(float damage)
    {
        forstressController.GainDamage(damage);
        if(forstressController.currentHP <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        foreach (var archer in archers)
        {
            Destroy(archer.gameObject);
        }
        Time.timeScale = 1 - Time.timeScale;
        uiController.ShowGameOver();
    }

    private void WinGame()
    {
        Time.timeScale = 1 - Time.timeScale;
        uiController.ShowWinGame();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
