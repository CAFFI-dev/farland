using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public int maxHealth;
    public Slider slider;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }

    // Update is called once per frame
    void Start()
    {
        SetMaxHealth(maxHealth);
    }

    //временно
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            slider.value -= 2;
            Debug.Log("Здоровье игрока: "+ slider.value);
        }
    }
}
