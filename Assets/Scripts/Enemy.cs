using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    CircleCollider2D myCollider;
    public LayerMask playerLayer;
    
    private int attackDamage = 1;
    public int maxHealth = 10;
    int currentHealth;
    void Start()
    {
        // Start at full health
        currentHealth = maxHealth;
        myCollider = GetComponent<CircleCollider2D>();
    }

    private void Update() {

        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(this.transform.position, myCollider.radius, playerLayer);

        // Damage them
        foreach(Collider2D player in hitPlayer)
        {
            player.GetComponent<PlayerCombat>().TakeDamage(attackDamage);
            Destroy(this.gameObject);
            ScoreUI.score++;
        }
    }

    public void TakeDamage(int damage)
    {
        // Take damage from current health
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }        
    }
}
