using System;
using System.Collections;
using System.Collections.Generic;
using Models;
using UnityEngine;

public class BaseBehaviour : MonoBehaviour
{
    private Base model;

    public void Initialize(Base model)
    {
        this.model = model;
        transform.position = new Vector3(model.position.x, 0.5f, model.position.y);
        App.levelManager.OnDestroyBase.AddListener(DestroyThisBase);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyBehaviour>().StartAttack();
        }
    }

    private void DestroyThisBase(Base baseModel)
    {
        if (model.Equals(baseModel))
        {
            Destroy(gameObject);
        }
    }
}
