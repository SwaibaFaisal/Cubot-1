using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_Spawning : MonoBehaviour
{
    [SerializeField] Transform m_spawnPoint;
    [SerializeField] Rigidbody2D m_rb;
    [SerializeField] GameEvent m_deathEvent;

    public void SetNewStartPoint(Transform _startPoint)
    {
        m_spawnPoint = _startPoint;
    }
    public void Respawn()
    {
        m_rb.velocity = Vector2.zero;
        transform.position = m_spawnPoint.position;
    }

   public void RespawnPressed(InputAction.CallbackContext _context)
    {
        if(_context.started)
        {
            Respawn();
            m_deathEvent.Raise(this, 0);
        }
    }

}
