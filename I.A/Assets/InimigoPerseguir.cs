using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPerseguir : MonoBehaviour
{

    public bool drawDebugLines = true;

    public Transform player;
    private Rigidbody2D rb;

    public bool encontrouinimigo;
    public float chaseRange;

    private float waitTime;
    public float startWaitTime;

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    bool indop1 = true;
    bool indop2 = false;

    public Transform posiçao1;
    public Transform posiçao2;


    private bool isTooClose;
    private Vector2 disPos1;
    private Vector2 disPos2;
    public float tooCloseDis;
    private float curCloseDis;

    public float distanciaMinimaAtaque;
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;

    public float speed;
    public float damage;
    private VidaInimigo vidaa;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
        rb = GetComponent<Rigidbody2D>();

        encontrouinimigo = false;

        waitTime = startWaitTime;

        timeBtwAttack = startTimeBtwAttack;
    }

    
    void Update()
    {
        float distanceToTarget = (transform.position - player.position).sqrMagnitude;

        if (distanceToTarget > chaseRange * chaseRange)
        {
            encontrouinimigo = false;
        }
        else if (distanceToTarget <= chaseRange * chaseRange)
        {
            encontrouinimigo = true;
           
        }

        if (encontrouinimigo == false)
        {

            if (indop1 == true)
            {
                if (transform.position.x > posiçao1.position.x)
                {
                    Vector3 scaler = transform.localScale;
                    scaler.x = -1f;
                    transform.localScale = scaler;
                }
                if (transform.position.x < posiçao1.position.x)
                {
                    Vector3 scaler = transform.localScale;
                    scaler.x = 1f;
                    transform.localScale = scaler;
                }

                Irp1();

                if (Vector2.Distance(transform.position, posiçao1.position) > 0.2f)
                {
                    return;
                }
                else if (Vector2.Distance(transform.position, posiçao1.position) < 0.2f)
                {
                    if (waitTime > 0)
                    {
                        waitTime -= Time.deltaTime;
                    }
                    else if (waitTime <= 0)
                    {
                        indop2 = true;
                        indop1 = false;
                        waitTime = startWaitTime;
                    }

                }
            }
            else if (indop2 == true)
            {
                Irp2();
                if (transform.position.x > posiçao2.position.x)
                {
                    Vector3 scaler = transform.localScale;
                    scaler.x = -1f;
                    transform.localScale = scaler;
                }
                if (transform.position.x < posiçao2.position.x)
                {
                    Vector3 scaler = transform.localScale;
                    scaler.x = 1f;
                    transform.localScale = scaler;
                }

                if (Vector2.Distance(transform.position, posiçao2.position) > 0.2f)
                {
                    return;
                }
                else if (Vector2.Distance(transform.position, posiçao2.position) < 0.2f)
                {
                    if (waitTime > 0)
                    {
                        waitTime -= Time.deltaTime;
                    }
                    else if (waitTime <= 0)
                    {
                        indop2 = false;
                        indop1 = true;
                        waitTime = startWaitTime;
                    }
                }
            }
           
        }
        else if (encontrouinimigo == true)
        {
            Debug.Log("Ta ali o loco");
             vidaa = GetComponent<VidaInimigo>();
            if (vidaa.health <= 4)
            {
                if (player.position.x > transform.position.x)
                {

                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                    Debug.Log("pra frente");
                }
                if (player.position.x < transform.position.x)
                {

                    rb.velocity = new Vector2(speed, rb.velocity.y);
                    Debug.Log("pra tras");
                }
                if (player.position.x > transform.position.x)
                {
                    Vector3 scaler = transform.localScale;
                    scaler.x = -1f;
                    transform.localScale = scaler;

                }
                if (player.position.x < transform.position.x)
                {
                    Vector3 scaler = transform.localScale;
                    scaler.x = 1f;
                    transform.localScale = scaler;
                }
            }
            else
            {
                if (distanceToTarget <= distanciaMinimaAtaque)
                {
                    isTooClose = true;
                    Debug.Log("ta perto");
                }
                //parar e atacar
                if (distanceToTarget <= distanciaMinimaAtaque && timeBtwAttack <= 0 && isTooClose == true)
                {

                    rb.velocity = new Vector2(0, rb.velocity.y);

                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        var enemy = enemiesToDamage[i].GetComponent<Vida>();
                        enemy.DealDamage(damage);
                        timeBtwAttack = startTimeBtwAttack;
                    }



                }


                else if (distanceToTarget <= distanciaMinimaAtaque && timeBtwAttack > 0 && isTooClose == true)
                {
                    timeBtwAttack -= Time.deltaTime;
                    Debug.Log("esperando");

                }

                else if (distanceToTarget > distanciaMinimaAtaque)
                {
                    isTooClose = false;
                    Debug.Log("ta longe");
                }


                //mov
                if (isTooClose == false)
                {
                    if (player.position.x > transform.position.x)
                    {

                        rb.velocity = new Vector2(speed, rb.velocity.y);
                        Debug.Log("pra frente");
                    }
                    if (player.position.x < transform.position.x)
                    {

                        rb.velocity = new Vector2(-speed, rb.velocity.y);
                        Debug.Log("pra tras");
                    }
                }
                //virar
                if (player.position.x > transform.position.x)
                {
                    Vector3 scaler = transform.localScale;
                    scaler.x = 1f;
                    transform.localScale = scaler;

                }
                if (player.position.x < transform.position.x)
                {
                    Vector3 scaler = transform.localScale;
                    scaler.x = -1f;
                    transform.localScale = scaler;
                }
            }
            
        }
    }
    public void Irp1()
    {
        transform.position = Vector2.MoveTowards(transform.position, posiçao1.position, speed * Time.deltaTime);
       
    }
    public void Irp2()
    {
        transform.position = Vector2.MoveTowards(transform.position, posiçao2.position, speed * Time.deltaTime);
        
    }

    void OnDrawGizmos()
    {
        if (drawDebugLines)
        {
            //cor do ataque
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPos.position, attackRange);
            //cor da visao
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, chaseRange);
        }
    }
}
