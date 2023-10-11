using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarGancho : MonoBehaviour
{
    public float vel;
    [Header("Keybinds")]
    public KeyCode rotarDerecha;
    public KeyCode rotarIzquierda;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(rotarDerecha))
        {
            transform.Rotate(0f, 0f, vel * Time.deltaTime);
        }
        else if (Input.GetKey(rotarIzquierda))
        {
            transform.Rotate(0f, 0f, -vel * Time.deltaTime);
        }
    }
}
