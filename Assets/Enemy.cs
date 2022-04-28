using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;

    public GameObject bullet,explosion,battery,core1,core2;

    public float Xspeed;
    public float Yspeed;
    public int score;


    public bool canShoot;
    public float fireRate;
    public float health;

    public Color bulletcolor;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Destroy(gameObject, 10);
        if (!canShoot) return;
        fireRate = fireRate + (Random.Range(fireRate / -2, fireRate / 2));
        InvokeRepeating("Shoot", fireRate, fireRate);
        
    }

    void Update()
    {
        rb.velocity = new Vector2(Xspeed,Yspeed*-1);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Spaceship>().Damage();
            Die();
        }
    }

    void Die()
    {
        if((int)Random.Range(0,3)==0)
            Instantiate(battery, transform.position, Quaternion.identity);
        if ((int)Random.Range(0, 3) == 0)
            Instantiate(core1, transform.position, Quaternion.identity);
        if ((int)Random.Range(0, 3) == 0)
            Instantiate(core2, transform.position, Quaternion.identity);
        Instantiate(explosion, transform.position, Quaternion.identity);
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + score);
        Destroy(gameObject);
    }

    public void Damage()
    {
        health--;
        if (health == 0)
            Die();
    }

    void Shoot()
    {
        GameObject temp = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
        temp.GetComponent<Bullet>().ChangeDirection();
        temp.GetComponent<Bullet>().ChangeColor(bulletcolor);
    }
}
