using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_TrailScript : MonoBehaviour
{
    [SerializeField] GameObject m_TrailSprite;
    [SerializeField] float m_timeBetweenTrails;
    [SerializeField] float m_trailTimeCounter;
    [SerializeField] Transform m_trailSpawnTransform;
    List<GameObject> m_trailSpriteList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_trailTimeCounter <= 0)
        {
            m_trailSpriteList.Add(
                Instantiate(m_TrailSprite, m_trailSpawnTransform.position, Quaternion.Euler(0,0,Random.Range(0,360))));
       
            m_trailTimeCounter = m_timeBetweenTrails;
        }
        else 
        { 
            m_trailTimeCounter -= Time.deltaTime;  
        }
    }

    public void ResetTrail()
    {
        for (int i = 0; i < m_trailSpriteList.Count; i++) 
        {
            Destroy(m_trailSpriteList[i]);
        }
    }
}
