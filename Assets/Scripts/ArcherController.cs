using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArcherController : MonoBehaviour {

    public int level;
    public float damage;
    public float attackSpeed;

    public GameObject upgradeButton;
    public GameController gameController;

    public EnemyController goalEnemy;
	// Use this for initialization
	void Start () {
        gameController = GameObject.FindObjectOfType<GameController>();
        StartCoroutine(Attack());
	}

    private void Update()
    {
        if(goalEnemy == null)
        {
            if (gameController.enemies.Count > 0)
            {
                goalEnemy = gameController.enemies[Random.Range(0, gameController.enemies.Count)];
            }
        }
    }

    IEnumerator Attack()
    {
        while (true)
        {
            if(goalEnemy != null)
            {
                GetComponent<Animator>().SetFloat("Attack", 1f);
                yield return new WaitForSeconds(1f);
                GetComponent<Animator>().SetFloat("Attack", 0);
                goalEnemy.GainDamage(damage);
                yield return new WaitForSeconds(attackSpeed);
            }
            else
            {
                yield return 0;
            }
            
        }
    }

    public void OnUpgradeButtonPressed()
    {
        gameController.UpgradeArcher(this);
    }

    public void LevelUp()
    {
        level++;
        damage *= 2;
        attackSpeed /= 1.2f;
        GetComponent<Animator>().SetFloat("Level", level);
    }

    public void SetUpgradeButtonSprite(Sprite sprite)
    {
        upgradeButton.GetComponent<Image>().sprite = sprite;
    }

    public void OnMouseDown()
    {
        upgradeButton.SetActive(!upgradeButton.active);
    }
}
