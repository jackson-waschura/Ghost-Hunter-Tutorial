using System.Collections;
using System.Collections.Generic;
using Meta.XR.MRUtilityKit;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    public float spawnTimer = 1f;
    public float minEdgeDistance = 0.2f;
    public float normalOffset = -1f;
    public int spawnTries = 10;
    public MRUKAnchor.SceneLabels spawnLabels;
    public GameObject ghostPrefab;
    private float timer;
    private LabelFilter spawnLabelsFilter;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnLabelsFilter = new LabelFilter(spawnLabels);
    }

    // Update is called once per frame
    void Update()
    {
        if (!MRUK.Instance.GetCurrentRoom() && !MRUK.Instance.IsInitialized)
        {
            return;
        }

        timer += Time.deltaTime;
        if (timer > spawnTimer)
        {
            TrySpawnGhost();
            timer -= spawnTimer;
        }
    }

    private bool TrySpawnGhost()
    {
        int currentTry = 0;
        MRUKRoom room = MRUK.Instance.GetCurrentRoom();
        while (currentTry < spawnTries) {
            bool hasFoundPosition = room.GenerateRandomPositionOnSurface(MRUK.SurfaceType.VERTICAL, minEdgeDistance, spawnLabelsFilter, out Vector3 pos, out Vector3 normal);
            if (hasFoundPosition)
            {
                Vector3 randomPositionNormalOffset = pos + normal * normalOffset;
                randomPositionNormalOffset.y = 0;
                Instantiate(ghostPrefab, randomPositionNormalOffset, Quaternion.identity);
                return true;
            }
            currentTry++;
        }
        return false;
    }
}
