using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody2D rb;
    bool hasHit;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (hasHit == false)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    // Update is called once per frame
    void Update()
    {
        

       

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hasHit = true;

        if (collision.gameObject.tag == "PlayerOne")
        {
            Audiomanager.PlaySound("Flecha");
        }

        if (collision.gameObject.tag == "PlayerTwo")
        {
            Audiomanager.PlaySound("Flecha");
        }

        if (collision.gameObject.tag == "Suelo")
        {
            Audiomanager.PlaySound("Flecha");
        }

        if (collision.gameObject.tag == "PlayerTwo")
        {
            Audiomanager.PlaySound("Pared");
        }

        if (collision.gameObject.tag == "Box")
        {
            Audiomanager.PlaySound("Flecha");
        }

        if (collision.gameObject.tag == "Pared")
        {
            Audiomanager.PlaySound("Flecha");
        }

        //BALASAS

        if (collision.gameObject.tag == "Misil")
        {
  
            Audiomanager.PlaySound("Flecha");
        }

        if (collision.gameObject.tag == "Arrow")
        {
            
            Audiomanager.PlaySound("Flecha");
        }

        if (collision.gameObject.tag == "Bomba")
        {
            
            Audiomanager.PlaySound("Flecha");
        }

        if (collision.gameObject.tag == "InverseBox")
        {
            
            Audiomanager.PlaySound("Flecha");
        }

        if (collision.gameObject.tag == "ParalyzeBox")
        {
            
            Audiomanager.PlaySound("Flecha");
        }

        if (collision.gameObject.tag == "SlowBox")
        {
            
            Audiomanager.PlaySound("Flecha");
        }

    }
}
