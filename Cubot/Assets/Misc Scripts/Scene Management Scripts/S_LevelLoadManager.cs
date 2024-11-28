using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoadManager : MonoBehaviour
{
    GameStates m_gameStates;
    
    public void LoadSceneSelected(Component _sender, object _data)
    {
        if (_data is int)
        {
            int a = (int) _data;
            m_gameStates = (GameStates)a;
        }
        print(m_gameStates);
        SceneManager.LoadScene((int)m_gameStates);
    }

        
}
