using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject[] enemyPrefabs;
    public RectTransform game;

	public EnemyController SpawnEnemy()
    {
        int enemyNumber = Random.Range(0, enemyPrefabs.Length);
        GameObject enemy = Instantiate(enemyPrefabs[enemyNumber], game);
        enemy.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, Random.Range(game.rect.height * 0.1f, game.rect.height * 0.4f));
        return enemy.GetComponent<EnemyController>();
    }
}
