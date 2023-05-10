using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class EnemyCtrl : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Player")
    {
      other.gameObject.GetComponent<PlayerCtrl>().ResetPosition();
    }
  }
}
