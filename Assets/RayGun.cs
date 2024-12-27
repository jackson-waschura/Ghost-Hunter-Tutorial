using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGun : MonoBehaviour
{
    public OVRInput.RawButton shootingButton;
    public LineRenderer rayPrefab;
    public Transform raySpawnPoint;
    public float maxDistance = 5f;

    public float lineShowDuration = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(shootingButton))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Debug.Log("Shooting");

        LineRenderer line = Instantiate(rayPrefab);
        line.positionCount = 2;
        line.SetPosition(0, raySpawnPoint.position);
        line.SetPosition(1, raySpawnPoint.position + raySpawnPoint.forward * maxDistance);

        Destroy(line.gameObject, lineShowDuration);
    }
}
