using UnityEngine;
using UnityEngine.Events;

public class EventBridge : MonoBehaviour
{
    public UnityEvent OnCall;

    public void Call()
    {
        OnCall?.Invoke();
    }
}
