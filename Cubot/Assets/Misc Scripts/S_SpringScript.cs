using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class S_SpringScript : MonoBehaviour
{
 


    private void OnCollisionEnter2D(Collision2D collision)
    {
       PlayerMovementFunctionality _playerScript = collision.gameObject.GetComponent<PlayerMovementFunctionality>();
        
        if( _playerScript != null )
        {
            _playerScript.SpringBounce();
            print("TriggerFound");
        }
    }



}
