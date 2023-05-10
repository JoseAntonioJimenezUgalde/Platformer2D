using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrilCtrl : MonoBehaviour
{
  public float fuerzaLanzamiento;
  private bool isPlayerIn = false;
  private GameObject playerRef;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetButtonDown("Jump") && isPlayerIn)
    {
      isPlayerIn = false;
      playerRef.GetComponent<Rigidbody2D>().gravityScale = 1;
      playerRef.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right * fuerzaLanzamiento);
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Player")
    {
      isPlayerIn = true;
      playerRef = other.gameObject;
      playerRef.GetComponent<Rigidbody2D>().gravityScale = 0;
      playerRef.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
      playerRef.GetComponent<Rigidbody2D>().angularVelocity = 0;
      playerRef.transform.position = gameObject.transform.position;
    }
  }
}
