using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StyleOfAttack
{
    sword, bow
}
public class Attack : MonoBehaviour
{
    [Header("Характеристики оружия")]
    [Tooltip("Урон данного оружия")]
    public float damage = 10f;
    [Tooltip("Максимальная дистанция, на которую данное оружие может стрелять")]
    public float range = 100f;
    [Tooltip("Кулдаун на атаку")]
    public float fireRate = 15f;
    [Tooltip("Сила с которой это оружие будет отбрасывать врагов/обьекты")]
    public float impactForce = 100f;

    [Header("Прочее")]
    [Tooltip("Камера игрока - нужна для того, чтобы влиять на отдачу оружия.")]
    public Camera fpsCam;
    [Tooltip("Обьект с которого выходит Raycast")]
    public GameObject outer;
    private float nextTimeToAttack = 0f;

    public void Melee()
    {
        RaycastHit hit;
        Vector3 shootOrigin = outer.transform.position;
        if (Physics.Raycast(shootOrigin, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit);
            Enemy target = hit.transform.GetComponent<Enemy>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            if (hit.collider.tag == "Ground")
            {
                //Создать дырки из под пуль
                //Instantiate(bulletHole, hit.point, Quaternion.LookRotation(hit.normal));
            }
            //Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.time >= nextTimeToAttack)
        {
            Melee();
            nextTimeToAttack = Time.time + 1f / fireRate;
        }
    }
}
