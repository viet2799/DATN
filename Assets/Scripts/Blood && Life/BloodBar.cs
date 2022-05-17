using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodBar : MonoBehaviour
{
    public Image fillBar;
    public float health;
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void LoseHealth(int value)
    {
        health -= value;
        fillBar.fillAmount = health / 100;
        if(health < 0)
        {
            FindObjectOfType<movePlayer>().Die();
        }
    }

    public void UpHealth(int value)
    {
        if (health < 100)
        {
            health += value;
        }
        else return;
    }

    private void Update()
    {
        //if (Input.GetKeyUp(KeyCode.Return))
        //{
        //    LoseHealth(20);
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == Constants.Enemy)
        {
            LoseHealth(20);
        }
    }
}
