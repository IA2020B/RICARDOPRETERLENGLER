using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ataque : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public float Damage;
    private bool atacando = false;

    int randomNumber;
    
   
    void Update()
    {
        if (timeBtwAttack <= 0) 
        {
            atacando = false;

            if (Input.GetKeyDown(KeyCode.Z))
            {
                randomNumber = Random.Range(1, 3);
                if (randomNumber == 1)
                {
                    Debug.Log("Ataco");
                    atacando = true;
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        enemiesToDamage[i].GetComponent<VidaInimigo>().DealDamage(Damage);
                    }
                    timeBtwAttack = startTimeBtwAttack;
                }
                else
                {
                    Debug.Log("esquivou");
                }
            }



        }
        else
        {

            timeBtwAttack -= Time.deltaTime;

        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPos.position, attackRange);

        }

    }
}

