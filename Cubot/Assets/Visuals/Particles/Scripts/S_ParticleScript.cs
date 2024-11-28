using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ParticleScript : MonoBehaviour
{
    [SerializeField] ParticleSystem m_thisParticle;
    [SerializeField] float m_delayTime;
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, m_delayTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
