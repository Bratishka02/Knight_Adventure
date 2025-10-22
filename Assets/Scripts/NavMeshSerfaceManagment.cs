using NavMeshPlus.Components;
using UnityEngine;

public class NavMeshSerfaceManagment : MonoBehaviour
{
    public static NavMeshSerfaceManagment Instance { get; private set; }

    private NavMeshSurface _navMeshSurface;

    private void Awake()
    {
        Instance = this;
        _navMeshSurface = GetComponent<NavMeshSurface>();
        _navMeshSurface.hideEditorLogs = true;
    }

    public void RebakeNavMeshSurface()
    {
        _navMeshSurface.BuildNavMesh();
    }

}
