using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTag : MonoBehaviour
{
    public string newTag;

    public PlayerMovement playerOneMove;
    public PlayerMovement playerTwoMove;

    private SpriteRenderer spRender;

    public float mSpeed;

    // Start is called before the first frame update
    void Start()
    {
        spRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerOne")
        {
            gameObject.tag = newTag;
            spRender.color = Color.yellow;
            //Destroy(gameObject);
        }

        if (collision.gameObject.tag == "PlayerTwo")
        {
            gameObject.tag = newTag;
            spRender.color = Color.yellow;
            //Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerOne")
        {
            playerOneMove.KBCounter = playerOneMove.KBTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                playerOneMove.KnockFromRight = true;
            }
            if (collision.transform.position.x > transform.position.x)
            {
                playerOneMove.KnockFromRight = false;
            }

            //Destroy(gameObject);
        }

        if (collision.gameObject.tag == "PlayerTwo")
        {
            playerTwoMove.KBCounter = playerTwoMove.KBTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                playerTwoMove.KnockFromRight = true;
            }
            if (collision.transform.position.x > transform.position.x)
            {
                playerTwoMove.KnockFromRight = false;
            }

            //Destroy(gameObject);
        }
    }

    public void MoveToRay(Vector2 origin) //Apenas se mueve hacia el origen del raycast
    {
        print("Impacto raycast");

        //transform.position = Vector2.MoveTowards(transform.position, origin, 0.05f); //No se Movio

        transform.position = Vector3.Lerp(transform.position, origin, mSpeed); //No se mueve

        //Vector2 moveDirection = (origin - (Vector2)transform.position).normalized;
        //Vector2 newpos = Vector2.MoveTowards(transform.position, origin, mSpeed * Time.deltaTime);
        //transform.position = newpos;

        //transform.Translate(moveDirection * mSpeed * Time.deltaTime); //NO SE MUEVE .gpt

        //ULTIMA ACTUALIZACION: YA NO SE MUEVE
    }

}
