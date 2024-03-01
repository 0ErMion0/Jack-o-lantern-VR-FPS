using UnityEngine;
using UnityEngine.Events;

public class Hittable : MonoBehaviour
{
    public UnityEvent OnHit;

    public void Hit()
    {
        OnHit?.Invoke();
    }
}

