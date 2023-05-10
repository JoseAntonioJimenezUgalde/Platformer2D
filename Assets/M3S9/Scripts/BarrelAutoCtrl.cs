using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelAutoCtrl : MonoBehaviour
{
  public float barrelForce;
  public Vector2 dir;
  private Rigidbody2D playerRigidBodyRef;

  private void OnTriggerEnter2D(Collider2D other)
  {
    Debug.Log(other.gameObject);
    if (other.gameObject.tag == "Player")
    {
      other.gameObject.transform.position = gameObject.transform.position;
      playerRigidBodyRef = other.gameObject.GetComponent<Rigidbody2D>();

      playerRigidBodyRef.velocity = Vector2.zero;
      playerRigidBodyRef.angularVelocity = 0;

      playerRigidBodyRef.AddForce(dir * barrelForce);
    }
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    if (other.gameObject.tag == "Player")
    {
      playerRigidBodyRef = null;
    }
  }
}
