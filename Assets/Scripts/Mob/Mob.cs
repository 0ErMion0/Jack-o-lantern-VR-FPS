using UnityEngine;
using UnityEngine.Events;

public class Mob : MonoBehaviour
{
    public float destroyDelay = 1;
    bool isDestroyed = false;

    public UnityEvent OnCreated;
    public UnityEvent OnDestroyed;

    void Start()
    {
        OnCreated?.Invoke();
        //Invoke(nameof(Destroy), 3);
        MobManager.Instance.OnSpawned(this);
    }

    public void Destroy()
    {
        if (isDestroyed)
            return;
        isDestroyed = true;

        Destroy(gameObject, destroyDelay);
        OnDestroyed?.Invoke();
        MobManager.Instance.OnDestroyed(this);
    }
}

