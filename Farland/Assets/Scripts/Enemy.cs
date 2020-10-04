using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public enum Who
{
    cannibal, player
}
[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [Header("Характеристики")]
    public float health = 100f;
    [Range(0,1)]
    public float armorCent = .25f;
    [Header("PVP игрок или PVE каннибал?")]
    public Who currentTypeOfEnemy;
    [Header("Звук попадания")]
    public AudioSource[] screamHits;
    public void TakeDamage (float amount)
    {
        amount = amount - (amount * armorCent);
        health -= amount;
        if (screamHits.Length > 0)
        {
            AudioSource screamHit = screamHits[Random.Range(0, screamHits.Length)];
            screamHit.Play();
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
}
