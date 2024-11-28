using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_WinTriggerScript : MonoBehaviour
{
    [SerializeField] GameEvent m_WinEvent;
    [SerializeField] int stageIndex;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerMovementFunctionality>() != null)
        {
            m_WinEvent.Raise(this, stageIndex);
            
        }
    }

}
