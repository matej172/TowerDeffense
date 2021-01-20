using System.Collections;
using System.Collections.Generic;
using Models;
using UnityEngine;

public class Enemy
{
    private int attack = 1;
    private int hp = 10;
    private Base target;

    public Enemy()
    {
        target = App.levelManager.GetNearestBase();
    }
    
    private void AttackBase()
    {
        target?.ResolveAttack(attack);
    }

    public Vector3 GetTargetPosition()
    {
        return new Vector3(target.position.x, 0, target.position.y);
    }
}
