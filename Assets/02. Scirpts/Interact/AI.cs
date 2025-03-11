using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class AI : ItemObject
{
    [Header("Camera")]
    public Camera camera;
    public Camera AgentCamera;
    [Header("AI")]
    public GameObject Destination;
    private NavMeshSurface MeshSurface;
    private NavMeshAgent Agent;
    private Vector3 startPosition;
 
    private void Start()
    {
        MeshSurface = GetComponentInParent<NavMeshSurface>();
        Agent = GetComponentInChildren<NavMeshAgent>();
        startPosition = Agent.transform.position;
        camera = Camera.main;
    }
  

    public override void OnInteract()
    {
        PlayerManager.Instance.PlayerController.gameObject.SetActive(false);
        MainCameraDonw();
        AISurfaceBake();
    }

    public Vector3 GetStartPosition()
    {
        return startPosition;
    }

    public void MainCameraDonw()
    {
        camera.gameObject.SetActive(false);
        AgentCamera.gameObject.SetActive(true);
    }
    public void MainCameraOn()
    {
        camera.gameObject.SetActive(true);
        AgentCamera.gameObject.SetActive(false);
    }

    ///////////////동적 베이킹 함수/////////////////////
    public void AISurfaceBake()
    {
        MeshSurface.BuildNavMesh();
        Agent.enabled = true;
        Agent.SetDestination(Destination.transform.position);
    }


 

}
