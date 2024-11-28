using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class InGameStateManager : MonoBehaviour
{

    [SerializeField] GameObject m_pressToStartText;
    [SerializeField] List<GameObject> m_stages;
    [SerializeField] S_Spawning m_playerSpawnScript;
    [SerializeField] PlayerMovementFunctionality m_playerMovementScript;

    [SerializeField] GameObject m_winScreen;
    [SerializeField] bool m_startFromStart;

    [SerializeField] GameEvent m_deathEvent;

    private void Start()
    {
        if(m_startFromStart)
        {
            Replay();  
        }
      
    }
    
    public void Replay()
    {
        m_winScreen.SetActive(false);
        PressToStartOn();
        ClearLevels();
        SetupStage(m_stages[0]);
    }

   

    void ClearLevels()
    {
        for (int i = 0; i < m_stages.Count; i++)
        {
            m_stages[i].SetActive(false);
        }
    }

    public void WinState(Component _sender, object _data)
    {
        if(_data is int)
        {
            ClearLevels();
            if((int)_data <= m_stages.Count) 
            { 
                SetupStage(m_stages[(int)_data]);
            }
            else
            {

                m_winScreen.SetActive(true);
                PressToStartOn();
                print("Level Complete!");
            }
            

        }
    }

    void SetupStage(GameObject _stage)
    {
        _stage.SetActive(true);
        StageScript _stageScript = _stage.GetComponent<StageScript>();

        if (_stageScript == null)
        {
            print("No stage script found");
        }
        else
        {
            m_playerSpawnScript.SetNewStartPoint(_stageScript.GetOwnStartPoint());
        }

        m_playerSpawnScript.Respawn();

    }
    public void PressToStartOn()
    {
        m_pressToStartText.SetActive(true);
        StopAllMovement();
    }

    public void PressToStartOff()
    {
        m_pressToStartText.SetActive(false);
        StartAllMovement();
    }

    public void StopAllMovement()
    {
        Time.timeScale = 0;
    }

    public void StartAllMovement()
    {
        Time.timeScale = 1f;
    }

   
    public void PauseGame()
    {
        
    }

    public void ResumeGame()
    {

    }




}
