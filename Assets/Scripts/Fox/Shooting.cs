using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject shootingItem;
    public Transform shootingPoint;
    public AudioSource shootingSound;
    public bool canShoot = true;

    private void Update()
    {
        if (Input.GetButtonDown("Shotting"))
        {
            shootingSound.Play();
            Shoot();
        }
    }
    void Shoot()
    {
        if (!canShoot) return;

        GameObject si = Instantiate(shootingItem,shootingPoint);
        si.transform.parent = null;
    }
}
