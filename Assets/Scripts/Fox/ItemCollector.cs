using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;
    private int gems = 0;
    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource collectEffect;
    [SerializeField] private Text gemText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Constants.Cherry))
        {
            collectEffect.Play();
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "" + cherries;
        }
        if (collision.gameObject.CompareTag(Constants.Gem))
        {
            Destroy(collision.gameObject);
            gems++;
            gemText.text = "" + gems;
        }
    }
}
