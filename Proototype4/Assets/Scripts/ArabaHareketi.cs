using UnityEngine;
using UnityEngine.AI;

public class ArabaHareketi : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 hedefNokta;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        YeniHedefBelirle();
    }

    private void Update()
    {
        if (agent.isActiveAndEnabled && agent.remainingDistance < 0.5f)
        {
            YeniHedefBelirle();
        }
    }

    private void YeniHedefBelirle()
    {
        Vector3 rastgeleNokta = new Vector3(Random.Range(-50f, 50f), 0f, Random.Range(-50f, 50f));
        agent.SetDestination(rastgeleNokta);
    }
}
