using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputFunctionality : MonoBehaviour
{
    [SerializeField] PlayerMovementFunctionality m_MoveScript;

    public void OnJumpPressed(InputAction.CallbackContext _context)
    {
        if(_context.started)
        {
            m_MoveScript.JumpStart();
        }

        if(_context.canceled)
        {
            m_MoveScript.JumpFinish();
        }

    }

}
