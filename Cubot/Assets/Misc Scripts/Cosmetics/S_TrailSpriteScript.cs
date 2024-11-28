using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class S_TrailSpriteScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer m_sprite;
    [SerializeField] Light2D m_light;
    [SerializeField] float m_decreaseValue;
    [SerializeField] float m_timeUntilFade;
    float m_fadeTimeCounter;
    [SerializeField] float m_fadeDuration;
    float m_fadeDurationCounter;
    bool m_hasFaded;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, m_timeUntilFade);
    }

 
        
}
