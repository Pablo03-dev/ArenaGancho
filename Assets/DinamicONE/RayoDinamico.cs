using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayoDinamico : MonoBehaviour
{
    public Transform pointo;
    public LayerMask layerOne; //CON QUE INTERACTUA

    public LineRenderer linerendere;
    public int da�o;

    //PARTI
    public int colisionesNecesarias;
    public GameObject objetoAActivar;
    public float tiempoDeActivacion;

    [SerializeField] private int colisionesActuales = 0;
    [SerializeField] private bool objetoActivado = false;
    private float tiempoPasado = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rayoHito();

        if (objetoActivado)
        {
            tiempoPasado += Time.deltaTime;

            if (tiempoPasado >= tiempoDeActivacion)
            {
                objetoActivado = false;
                objetoAActivar.SetActive(false);
                colisionesActuales = 0;
                tiempoPasado = 0.0f;
            }
        }
    }

    void rayoHito()
    {
        RaycastHit2D hit = Physics2D.Raycast(pointo.position, transform.TransformDirection(Vector2.down), 10f, layerOne);

        if (hit)
        {
            float distance = Vector2.Distance(pointo.position, hit.point);
            Debug.DrawRay(pointo.position, pointo.TransformDirection(Vector2.down) * distance, Color.red);
            //Debug.Log(hit.transform.name);
        }

        if (hit)
        {
            linerendere.SetPosition(0, pointo.position);
            linerendere.SetPosition(1, hit.point);

            if (hit.transform.gameObject.tag == "Techo")
            {
                //hit.transform.GetComponent<SpriteRenderer>().color = Color.magenta;
                //Giratorio rotaciones = hit.collider.GetComponent<Giratorio>();
                //if (rotaciones != null)
                //{
                //    rotaciones.RotarIzquierda();
                //}

            }

            //ACA PONER PARTY
            if (hit.transform.CompareTag("PlayerOne") && !objetoActivado)
            {

                GameManager.manager.HurtP1(da�o);
                //CinemachineMovimientoCamara.Instance.MoverCamara(2, 2, 0.2f);

                Reaparecer reaparecerJ1 = hit.collider.GetComponent<Reaparecer>();
                if (reaparecerJ1 != null)
                {
                    reaparecerJ1.Die();
                    Audiomanager.PlaySound("Derribado");
                    CinemachineMovimientoCamara.Instance.MoverCamara(2, 2, 0.2f);
                    Audiomanager.PlaySound("Colsionbala");
                }

                PlayerMovement movimientoJ1 = hit.collider.GetComponent<PlayerMovement>();
                if (movimientoJ1 != null)
                {
                    movimientoJ1.DesactivarReaccion();
                }


                colisionesActuales++;

                if (colisionesActuales >= colisionesNecesarias)
                {
                    objetoActivado = true;
                    objetoAActivar.SetActive(true);
                }
            }

            if (hit.transform.CompareTag("PlayerTwo") && !objetoActivado)
            {

                GameManager.manager.HurtP2();
                //CinemachineMovimientoCamara.Instance.MoverCamara(2, 2, 0.2f);

                Reaparecer reaparecerJ2 = hit.collider.GetComponent<Reaparecer>();
                if (reaparecerJ2 != null)
                {
                    reaparecerJ2.Die();
                    Audiomanager.PlaySound("Derribado");
                    CinemachineMovimientoCamara.Instance.MoverCamara(2, 2, 0.2f);
                    Audiomanager.PlaySound("Colsionbala");
                }

                PlayerTwoMovement movimientoJ2 = hit.collider.GetComponent<PlayerTwoMovement>();
                if (movimientoJ2 != null)
                {
                    movimientoJ2.DesactivarReaccion();
                }


                colisionesActuales++;

                if (colisionesActuales >= colisionesNecesarias)
                {
                    objetoActivado = true;
                    objetoAActivar.SetActive(true);
                }
            }

        }
        else
        {
            linerendere.SetPosition(0, pointo.position);
            linerendere.SetPosition(1, pointo.position - pointo.up * 10);
        }
    }
}
