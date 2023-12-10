using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionaDestruir : MonoBehaviour
{
    [SerializeField] private float radio;
    [SerializeField] private float fuerzaExplos;

    public GameObject objExplosion;

    public ParticleSystem humopart;
    //[SerializeField] private float timerExplosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        humopart.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerOne")
        {
            //Invoke("Explosion", timerExplosion);
            Explosion();
            //animattor.SetBool("Touch", true);
        }

        if (collision.gameObject.tag == "PlayerTwo")
        {
            //Invoke("Explosion", timerExplosion);
            Explosion();
            //animattor.SetBool("Touch", true);
        }

        if (collision.gameObject.tag == "Puas")
        {
            Explosion();
        }

        if (collision.gameObject.tag == "Box")
        {
            Explosion();
        }

        if (collision.gameObject.tag == "SpecialBox")
        {
            Explosion();
        }

        if (collision.gameObject.tag == "Pared")
        {
            Explosion();
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
       
    }

    public void Explosion()
    {
        Instantiate(objExplosion, transform.position, Quaternion.identity);

        CinemachineMovimientoCamara.Instance.MoverCamara(2, 2, 0.2f);

        Collider2D[] objetos = Physics2D.OverlapCircleAll(transform.position, radio);

        foreach (Collider2D colisionador in objetos)
        {
            Rigidbody2D rb2D = colisionador.GetComponent<Rigidbody2D>();
            if (rb2D != null)
            {
                Vector2 direccion = colisionador.transform.position - transform.position;
                float distancia = 1 + direccion.magnitude;
                float fuerzaFinal = fuerzaExplos / distancia;
                rb2D.AddForce(direccion * fuerzaFinal);
            }
        }

        Destroy(gameObject, 0.1f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, radio);
    }


}
