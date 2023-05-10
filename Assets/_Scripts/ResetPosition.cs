using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            M3S10PlayerCtrl.instance.PositionStart();
            M3S10PlayerCtrl.instance.QuitarVida();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
