using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class EnemyControll : MonoBehaviour
{

    public float speed = 5f; // Velocidad de movimiento del enemigo

    private Rigidbody2D rb;
    private bool movingRight = true; // Variable para controlar la dirección del enemigo
    [SerializeField] private float forceImpulse; //Fuerza de impulso hacia el jugador

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (movingRight)
        {
            // Mover hacia la derecha
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            // Mover hacia la izquierda
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Cambiar de dirección al chocar con la pared
            movingRight = !movingRight;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            M3S10PlayerCtrl.instance.QuitarVida(); // Quitarle una vida al player
            Vector2 posicionPlayer =  collision.gameObject.transform.position; // Obtener su posicion del player
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(posicionPlayer * forceImpulse, ForceMode2D.Impulse); // Agregarle una fuerza de impulso desde su posicion del player
        }
    }
}
