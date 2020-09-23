using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public enum Who
{
    monster, player
}

public class Enemy : MonoBehaviour
{
    
    [Header("Характеристики")]
    public float health = 100f;
    public float armor = 50f;
    [Header("PVP игрок или PVE монстр?")]
    public Who currentTypeOfEnemy;
    [Header("Звук попадания")]
    public AudioSource ough;
    public void TakeDamage (float amount)
    {
        if (armor > 0)
        {
            if (armor >= amount)
            {
                armor -= amount;
            }
            else
            {
                amount -= armor;
                armor = 0;
                health -= amount;
            }
            if (armor <= 0)
            {
                //Звук
                return;
            }
            ough.Play();
        }
        else
        {
            health -= amount;
            ough.Play();
        }
        if(health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
