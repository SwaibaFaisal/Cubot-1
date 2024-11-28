using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class S_CameraFollow : MonoBehaviour
{
    [SerializeField] Transform m_playerTransform;
    [SerializeField] Transform m_camObjectTransform;
    [SerializeField] Vector2 m_camFollowMultiplier;
    [SerializeField] Vector2 m_offset;
    [SerializeField] float m_frameRate = 60;
    [SerializeField] float m_cameraLerpMultiplier;
    [SerializeField] float m_minCameraDistance;
    [SerializeField] float m_maxCameraDistance;
    [SerializeField] Camera m_camera;
    float m_frameFixMultiplier;


    void FixedUpdate()
    {
        FollowPlayer();
        
    }

    private void Start()
    {
        m_camera = this.GetComponent<Camera>();

        if(m_camera != null )
        {
            print("Camera Found");
        }
    }

    private void FollowPlayer()
    {
        m_frameFixMultiplier = m_frameRate * Time.deltaTime;
        transform.position = new Vector3(
            m_playerTransform.position.x * m_camFollowMultiplier.x * m_frameFixMultiplier + m_offset.x,
           m_playerTransform.position.y * m_camFollowMultiplier.y * m_frameFixMultiplier + m_offset.y,
           transform.position.z);
    }

    private void MoveToNewPos()
    {
      
    }
      
}
