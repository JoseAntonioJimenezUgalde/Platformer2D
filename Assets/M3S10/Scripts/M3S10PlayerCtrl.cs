using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody2D))]
public class M3S10PlayerCtrl : MonoBehaviour
{ public float moveForce;
    public float jumpForce;

    private Rigidbody2D rb;
    private bool isGround = false;

    public Vector2 positionInitial;

    public static M3S10PlayerCtrl instance;

    public int vidas;
    public GameObject[] corazones;

    void Awake()
    {
        instance = this;
    }

    public void PositionStart()
    {
        transform.position = positionInitial;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Cargar el número de vidas guardado en PlayerPrefs, si existe, de lo contrario, usar el valor predeterminado
        vidas = PlayerPrefs.GetInt("Vidas", 3);
        if (PlayerPrefs.GetInt("Vidas") <= 0)
        {
            vidas = 3;
            PlayerPrefs.SetInt("Vidas", vidas);
        }
        NumeroDeVidas();
        

        positionInitial = transform.position;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveForce, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGround)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            isGround = false;
            Debug.Log("Is Jumping");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            Debug.Log("Grounded");
        }
    }

    private void NumeroDeVidas()
    {
        if (vidas < 1)
        {
            corazones[0].SetActive(false);
            corazones[1].SetActive(false);
            corazones[2].SetActive(false);
            SceneManager.LoadScene(0);
        }
        else if (vidas < 2)
        {
            corazones[1].SetActive(false);
            corazones[2].SetActive(false);

        }
        else if (vidas < 3)
        {
            corazones[2].SetActive(false);
        }
    }

    public void ActualizarVidas()
    {
        if (vidas == 1)
        {
            corazones[0].SetActive(true);
        }

        if (vidas == 2)
        {
            corazones[1].SetActive(true);
        }

        if (vidas == 3)
        {
            corazones[2].SetActive(true);
        }

        if (vidas >= 3)
        {
            vidas = 3;
        }
    }

    public void SumarVida()
    {
        vidas++;
        ActualizarVidas();
        PlayerPrefs.SetInt("Vidas", vidas);

    }

    public void QuitarVida()
    {
        vidas--;
        NumeroDeVidas();
        PlayerPrefs.SetInt("Vidas", vidas);

    }


}