using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_CutsceneManager : MonoBehaviour
{
    [SerializeField] float m_timeUntilChange;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CutsceneCountdown());
    }

    IEnumerator CutsceneCountdown ()
    {
        yield return new WaitForSeconds(m_timeUntilChange);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        
    }
   
}
