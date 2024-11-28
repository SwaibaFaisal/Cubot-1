using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_MenuBox : MonoBehaviour
{
    [SerializeField] GameEvent m_loadLevelEvent;
    [SerializeField] int m_index;
    
   public void OnLevelBoxPressed()
   {
        m_loadLevelEvent.Raise(this, m_index);
   }
}
