using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScript : MonoBehaviour
{

    [SerializeField] Transform m_universalStartPoint;
    [SerializeField] Transform m_ownStartPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public Transform GetOwnStartPoint ()
    {
        return m_ownStartPoint;
    }
    public void SetupStage()
    {
        m_universalStartPoint = m_ownStartPoint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
