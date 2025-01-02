using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;
using Meta.XR.MRUtilityKit;
public class RuntimeNavMeshBuilder : MonoBehaviour
{
    private NavMeshSurface navMeshSurface;

    // Start is called before the first frame update
    void Start()
    {
        navMeshSurface = GetComponent<NavMeshSurface>();

        MRUK.Instance.RegisterSceneLoadedCallback(OnSceneLoaded);
    }

    private void OnSceneLoaded()
    {
        Debug.Log("Scene loaded");
        StartCoroutine(OnSceneLoadedCoroutine());
    }

    private IEnumerator OnSceneLoadedCoroutine()
    {
        yield return new WaitForEndOfFrame();
        navMeshSurface.BuildNavMesh();
        Debug.Log("NavMesh built");
    }
}
