using System.Collections;
using UnityEngine;

public class RayVisualizer : MonoBehaviour
{
    [Header("Ray")]
    public LineRenderer ray;
    public LayerMask hitRayMask;
    public float distance = 100;

    [Header("Recticle Point")]
    public GameObject recticlePoint;
    public bool showRecticle = true;

    private void Awake()
    {
        Off();
    }

    public void On()
    {
        StopAllCoroutines();
        StartCoroutine(Process());
    }

    public void Off()
    {
        StopAllCoroutines();
        ray.enabled = false;
        recticlePoint.SetActive(false);
    }

    IEnumerator Process()
    {
        while (true)
        {
            if (Physics.Raycast(
                transform.position, transform.forward,
                out RaycastHit hitInfo, distance, hitRayMask))
            {
                ray.SetPosition(1, transform.InverseTransformPoint(hitInfo.point));
                ray.enabled = true;
                recticlePoint.transform.position = hitInfo.point;
                recticlePoint.SetActive(showRecticle);
            }
            else
            {
                ray.enabled = false;
                recticlePoint.SetActive(false);
            }
            yield return null;
        }
    }
}

