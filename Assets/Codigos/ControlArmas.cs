using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlArmas : MonoBehaviour
{
    [SerializeField] private UnityEvent enBazooka;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bazooka")
        {
            enBazooka?.Invoke();
        }
    }

}
