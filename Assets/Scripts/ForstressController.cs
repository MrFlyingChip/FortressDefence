using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForstressController : MonoBehaviour
{
    public float maxHP;
    public float currentHP;

	// Use this for initialization
	void Start () {
        currentHP = maxHP;
        GetComponent<Animator>().SetFloat("HP", currentHP);
    }

    public void GainDamage(float damage)
    {
        currentHP -= damage;
        GetComponent<Animator>().SetFloat("HP", currentHP);
    }
}
