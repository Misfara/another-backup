using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuguHealing : MonoBehaviour
{

    CircleCollider2D circleCollider2D;
    Health health;
   
    bool isHealingUsed= false;
    void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        health= GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D player)
    {
            if(player.CompareTag("Player"))
            {
                    StartCoroutine(CooldownHealing());
            }
    }

    private IEnumerator CooldownHealing()
    {
        if(isHealingUsed == false)
        {
            health.currentHealth = health.maxHealth;
             isHealingUsed= true;
        
        }
        yield return new WaitForSeconds(60);
        isHealingUsed = false;
       
    }
}
