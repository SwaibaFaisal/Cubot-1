using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_LevelBox : MonoBehaviour
{
    [SerializeField] int m_StateToLoadIndex;
    [SerializeField] GameEvent m_LoadSceneEvent;
    

    public void OnLevelBoxPressed()
    {
        m_LoadSceneEvent.Raise(this, m_StateToLoadIndex);
    }


}
