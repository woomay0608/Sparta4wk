using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class AI : ItemObject
{
    [Header("Camera")]
    public Camera camera;
    public Camera AgentCamera;
    [Header("AI")]
    public NavMeshSurface meshSurface;
    public NavMeshAgent agent;
    public GameObject Destination;
    private Vector3 StartPosition;
 
    private void Start()
    {
        StartPosition = agent.transform.position;
        meshSurface = GetComponentInParent<NavMeshSurface>();
        agent = GetComponentInChildren<NavMeshAgent>();
        camera = Camera.main;
    }
  

    public override void OnInteract()
    {
        PlayerManager.Instance.PlayerController.gameObject.SetActive(false);
        CameraDonw();
        SurfaceBake();
        agent.enabled = true;
        agent.SetDestination(Destination.transform.position);
    }

    public Vector3 StartPo()
    {
        return StartPosition;
    }

    public void CameraDonw()
    {
        camera.gameObject.SetActive(false);
        AgentCamera.gameObject.SetActive(true);
    }
    public void CameraOn()
    {
        camera.gameObject.SetActive(true);
        AgentCamera.gameObject.SetActive(false);
    }

    public void SurfaceBake()
    {
        meshSurface.BuildNavMesh();
    }


 

}
