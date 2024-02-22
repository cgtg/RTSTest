using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class UnitController : PoolAble
{
    [SerializeField]
    private GameObject unitMarker;
    private NavMeshAgent navMeshAgent;
    private Vector3 destination;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void SelectUnit()
    {
        unitMarker.SetActive(true);
    }

    public void DeselectUnit()
    {
        unitMarker.SetActive(false);
    }

    public void MoveTo(Vector3 end)
    {
        // 거리와 이동속도를 이용해 이동시간을 구하고 이동시간이 흐른뒤 정지 하게 컨트롤?
        destination = end;
        StartCoroutine(StopMoving());
        navMeshAgent.SetDestination(destination);

        // (Flocking AI)?
    }

    IEnumerator StopMoving()
    {
        NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
        float distance = Vector3.Distance(transform.position, destination);
        float timeToArrive = distance / navMeshAgent.speed;
        //Debug.Log(timeToArrive);

        yield return new WaitForSeconds(timeToArrive);
        navMeshAgent.SetDestination(transform.position);
    }
}

