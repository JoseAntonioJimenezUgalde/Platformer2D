using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerCtrl : MonoBehaviour
{
  private Vector3 initialPosition;
  // Start is called before the first frame update
  void Start()
  {
    initialPosition = gameObject.transform.position;
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void ResetPosition()
  {
    gameObject.transform.position = initialPosition;
    gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    gameObject.GetComponent<Rigidbody2D>().angularDrag = 0;
  }
}
