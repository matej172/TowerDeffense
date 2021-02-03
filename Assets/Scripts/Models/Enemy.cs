using System.Collections;
using System.Collections.Generic;
using Helpers;
using Models;
using UnityEngine;

public class Enemy
{
    private int attack = 1;
    public int attackFrequency = 1; 
    private float attackDistance = 1;
    private int hp = 10;
    private Base target;
    private EnemyState state;

    public Enemy()
    {
        state = EnemyState.Searching;
        target = App.levelManager.GetNearestBase();
        App.levelManager.OnDestroyBase.AddListener(ResolveDestoryedBase);
    }

    public void StartAttacking()
    {
        state = EnemyState.Attacking;
    }
    
    public void AttackBase()
    {
        if (target == null)
        {
            state = EnemyState.Searching;
        }
        else
        {
            target.ResolveAttack(attack);
        }
    }

    public Vector3 GetTargetPosition()
    {
        return new Vector3(target.position.x, 0, target.position.y);
    }

    public EnemyState getState()
    {
        return state;
    }

    private void ResolveDestoryedBase(Base baseModel)
    {
        if (baseModel.Equals(target))
        {
            target = null;
            this.state = EnemyState.Searching;
        }
    }
}
