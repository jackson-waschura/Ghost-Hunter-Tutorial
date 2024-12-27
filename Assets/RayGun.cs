using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGun : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip shootingSound;
    public LayerMask layerMask;
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
        audioSource.PlayOneShot(shootingSound);
        
        Ray ray = new Ray(raySpawnPoint.position, raySpawnPoint.forward);

        bool hasHit = Physics.Raycast(ray, out RaycastHit hit, maxDistance, layerMask);

        Vector3 endPoint;
        if (hasHit)
        {
            endPoint = hit.point;
        } else
        {
            endPoint = ray.origin + ray.direction * maxDistance;
        }

        LineRenderer line = Instantiate(rayPrefab);
        line.positionCount = 2;
        line.SetPosition(0, raySpawnPoint.position);
        line.SetPosition(1, endPoint);

        Destroy(line.gameObject, lineShowDuration);
    }
}
