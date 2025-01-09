using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    [SerializeField] int health, maxHealth = 5;
    Collider2D flashlight;
    public Healthbar healthbar;
    public Ending win;
    private bool trigger = true;

    //need to trigger the damage in flash without it taking constant damage
    private bool isColliding;

    // Start is called before the first frame update
    void Start()
    {
        flashlight = GameObject.FindGameObjectWithTag("Damage").GetComponent<PolygonCollider2D>();
        health = maxHealth;
        healthbar.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        isColliding = false;
    }
    private void OnTriggerEnter2D(Collider2D flashlight)
    {
        if (isColliding) return;
        isColliding = true;
        if ((flashlight.gameObject.name == "Round Light") && (trigger == true))
        {
            TakeDamage(1);
            StartCoroutine(Counter(1));
        }
        //Debug.Log("Triggered on: " + flashlight.gameObject.name);
    }
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        healthbar.SetHealth(health);

        if (health <= 0)
        {
            Destroy(gameObject);
            win.Win();
        }
    }
    public IEnumerator Counter(int value)
    {
        trigger = false;
        yield return new WaitForSeconds(value);
        trigger = true;
    }
}
