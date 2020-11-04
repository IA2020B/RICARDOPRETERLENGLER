using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VidaInimigo : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image vida;

    void Start()
    {
        health = maxHealth;
    }


    void Update()
    {
        vida.fillAmount = health / maxHealth;
       
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        CheckDeath();
    }

    private void CheckOverheal()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }

    }

    public void CheckDeath()
    {
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }


}
