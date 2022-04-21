using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodBar : MonoBehaviour
{
    public Image fillBar;
    public float health;

    public void LoseHealth(int value)
    {
        health -= value;
        fillBar.fillAmount = health / 100;
        if(health < 0)
        {
            FindObjectOfType<movePlayer>().Die();
        }
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
