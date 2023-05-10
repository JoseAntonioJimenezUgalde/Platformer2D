using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
  private Animator animatorRef;
  // Start is called before the first frame update
  void Start()
  {
    animatorRef = gameObject.GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetButtonDown("Jump"))
    {
      animatorRef.SetTrigger("isJump");
    }

    if (Input.GetKeyDown(KeyCode.RightArrow))
    {
      animatorRef.SetTrigger("isMove");
    }
  }

  public void spawnPlanet()
  {
    Debug.Log("Evento de animación");
  }
}
