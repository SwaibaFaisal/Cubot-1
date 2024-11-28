using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerDeathTrigger : MonoBehaviour
{
    [SerializeField] GameEvent m_DeathEvent;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if( collision.GetComponent<PlayerMovementFunctionality>() )
        {
            m_DeathEvent.Raise(this, 1);
            print("Death");
        }

    }


}
