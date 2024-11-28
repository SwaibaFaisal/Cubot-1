using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Timeline.Actions;
using UnityEngine;

public class S_Debug : MonoBehaviour
{
    [SerializeField] bool m_isPaused = false;

   public void OnDebugPausePressed()
   {
        if(m_isPaused)
        {
            
            Time.timeScale = 1f;
            m_isPaused = false;
        }
        else
        {
            if(Time.timeScale != 0f)
            {
                Time.timeScale = 0f;
                m_isPaused = true;
            }
           
        }
   }
}
