using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] BossManager boss;
    public Slider slider;
    public int health;
    // Update is called once per frame
    void Update()
    {
        if (slider.value != health)
        {
            slider.value = health;
        }
    }
    public void Setup()
    {
        gameObject.SetActive(true);
        health = boss.health;
    }
}
