using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Shooter : MonoBehaviour
{
    public LayerMask hittaableMask;
    public GameObject hitEffectPrefab;
    public Transform shootPoint;
    public float shootDelay = 0.1f;
    public float maxDistance = 100;
    public UnityEvent<Vector3> OnShootSuccess;
    public UnityEvent OnShootFail;

    Magazine magazine;

    private void Awake()
    {
        magazine = GetComponent<Magazine>();
    }

    void Start()
    {
        Stop();
    }
    public void Play()
    {
        StopAllCoroutines();
        StartCoroutine(Process());
    }
    public void Stop()
    {
        StopAllCoroutines();
    }

    IEnumerator Process()
    {
        var wfs = new WaitForSeconds(shootDelay);

        while (true)
        {
            if (magazine.Use())
                Shoot();
            else
                OnShootFail?.Invoke();

            yield return wfs;
        }
    }

    void Shoot()
    {
        if (Physics.Raycast(
            shootPoint.position, shootPoint.forward,
            out RaycastHit hitInfo, maxDistance, hittaableMask))
        {
            Instantiate(hitEffectPrefab, hitInfo.point, Quaternion.identity);

            var hitObject = hitInfo.transform.GetComponent<Hittable>();
            hitObject?.Hit();

            OnShootSuccess?.Invoke(hitInfo.point);
        }
        else
        {
            var hitPoint = shootPoint.position + shootPoint.forward * maxDistance;
            OnShootSuccess?.Invoke(hitPoint);
        }
    }
}

