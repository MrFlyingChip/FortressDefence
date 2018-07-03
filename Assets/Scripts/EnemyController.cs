using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float HP;
    public GameController gameController;

    public int minGold;
    public int maxGold;

    public float deathTime;

    public float minDamage;
    public float maxDamage;

    public float speed;

    public int points;
    // Use this for initialization
    void Start () {
        gameController = GameObject.FindObjectOfType<GameController>();

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        speed = 0;
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        while (true)
        {
            GetComponent<Animator>().SetBool("Attack", true);
            yield return new WaitForSeconds(0.5f);
            DealDamage();
            GetComponent<Animator>().SetBool("Attack", false);
            yield return new WaitForSeconds(1.5f);           
        } 
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0f));
	}

    void DealDamage()
    {
        float damage = Random.Range(minDamage, maxDamage);
        gameController.GainDamageToForstress(damage);
    }

    public void GainDamage(float damage)
    {
        HP -= damage;
        if(HP <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        GetComponent<Animator>().SetBool("Death", true);
        StartCoroutine(DeathAfterTime());
    }

    private IEnumerator DeathAfterTime()
    {
        yield return new WaitForSeconds(deathTime);
        int gold = Random.Range(minGold, maxGold);
        gameController.GainGold(gold);
        gameController.DeleteEnemy(this);
        Destroy(gameObject);
    }
}
