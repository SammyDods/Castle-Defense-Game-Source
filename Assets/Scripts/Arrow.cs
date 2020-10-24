using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour//Class for ArcherTower projectiles
{
    public GameObject ArrowTarget;//Goblin that arrow is aimed at

    protected float moveSpeed;
    protected int damage;
    protected Vector3 movement;
    protected float timer;

    void Awake()
    {
        damage = 20;
        timer = Time.time+3;
    }

    void Update()//Autimaticly despawns after 5 seconds if for whatever reason doesn't hit a goblin
    {
        if (Time.time >= timer)
        {
            Destroy(gameObject);
        }
    }

    protected void FixedUpdate()//Every physics calculation home in arrow at goblin
    {
        HomeIn();
    }

    protected void HomeIn()//If the target isn't dead arrow will head towards the goblin
    {
        if (ArrowTarget!= null)
        {
            gameObject.GetComponent<Rigidbody2D>().MovePosition(ArrowTarget.GetComponent<Rigidbody2D>().position);
            //+ new Vector2(1.75f, 1.1f) * Time.fixedDeltaTime
        }
        else
        {
            Debug.Log("Arrow Target Null");
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)//On Collision deal damage and destroy self
    {
        
        if (collision.CompareTag("Goblin")){
            collision.GetComponent<Goblin>().health -= damage;
            Destroy(gameObject);        
        }   
    }

    protected void OnTriggerStay2D(Collider2D collision)//On Collision deal damage and destroy self
    {
        if (collision.CompareTag("Goblin"))
        {
            collision.GetComponent<Goblin>().health -= damage;
            Destroy(gameObject);
        }
    }
}
