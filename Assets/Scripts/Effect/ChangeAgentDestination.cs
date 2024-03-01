using UnityEngine;
using UnityEngine.AI;

public class ChangeAgentDestination : MonoBehaviour
{
    //public Vector3 destination;

    NavMeshAgent target;

    private void Awake()
    {
        target = GetComponent<NavMeshAgent>();
    }

    public void Call()
    {
        //target.SetDestination(destination);
        target.SetDestination(Core.Instance.transform.position);
    }
}
