using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BarrelCtrl : MonoBehaviour
{
  public float barrelForce;
  public Vector2 dir;
  private Rigidbody2D playerRigidBodyRef;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetButtonDown("Jump") && playerRigidBodyRef != null)
    {
      playerRigidBodyRef.gravityScale = 1;
      playerRigidBodyRef.AddForce(dir * barrelForce);
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    Debug.Log(other.gameObject);
    if (other.gameObject.tag == "Player")
    {
      other.gameObject.transform.position = gameObject.transform.position;
      other.gameObject.transform.SetParent(gameObject.transform);
      playerRigidBodyRef = other.gameObject.GetComponent<Rigidbody2D>();
      playerRigidBodyRef.gravityScale = 0;
      playerRigidBodyRef.velocity = Vector2.zero;
      playerRigidBodyRef.angularVelocity = 0;
    }
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    if (other.gameObject.tag == "Player")
    {
      playerRigidBodyRef = null;
      other.gameObject.transform.parent = null;
    }
  }

  public void NextDirectionX(float x)
  {
    dir.x = x;
  }
  public void NextDirectionY(float y)
  {
    dir.y = y;
  }
}
