using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public Healthbar healthbar;
    public Ending loser;
    [SerializeField] public int health, maxHealth = 10;
    private bool trigger,triggerpow = true;
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
    }
    //when enemy reaches, take damage
    private void OnTriggerStay2D(Collider2D Enemy)
    {
        //Will not use is Colliding bool found in MonsterHealth script. Encourages a need to avoid.
        if ((Enemy.gameObject.name == "Monster Sprite") && (trigger == true))
        {
            TakeDamage(1);
            StartCoroutine(Counter(1));

        }
        if ((Enemy.gameObject.name == "source")&& (triggerpow == true)) 
        {
            TakeDamage(4);
            StartCoroutine(CounterPow(3));

        }
        //Debug.Log("Triggered on: " + Enemy.gameObject.name);
    }
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        healthbar.SetHealth(health);
        if (health <= 0)
        {
            Destroy(gameObject);
            loser.Fail();
        }
    }
    public IEnumerator Counter(int value)
    {
        trigger = false;
        yield return new WaitForSeconds(value);
        trigger = true;
    }
    public IEnumerator CounterPow(int value)
    {
        triggerpow = false;
        yield return new WaitForSeconds(value);
        triggerpow = true;
    }
   
}
