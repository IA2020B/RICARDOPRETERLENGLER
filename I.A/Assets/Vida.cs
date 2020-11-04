using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    public float health;
    public float maxHealth;

    void Start()
    {
        health = maxHealth;
    }

    public Image Healthbar;
    void Update()
    {
        Healthbar.fillAmount = health / maxHealth;
    }

    public void DealDamage(float damage)
    {
        health -= damage;

        Healthbar.fillAmount = health / maxHealth;
    }
    private void CheckOverheal()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
