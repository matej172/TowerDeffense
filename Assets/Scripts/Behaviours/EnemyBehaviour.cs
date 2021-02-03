using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    
    private NavMeshAgent agent;
    private Enemy model;
    
    public void Initialize(Enemy model)
    {
        agent = GetComponent<NavMeshAgent>();
        this.model = model;
        agent.destination = this.model.GetTargetPosition();
    }

    public void StartAttack()
    {
        agent.isStopped = true;
        this.model.StartAttacking();
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        while (model.getState() == EnemyState.Attacking)
        {
            model.AttackBase();
            yield return new WaitForSeconds(model.attackFrequency);
        }
        agent.isStopped = false;
    }
}
