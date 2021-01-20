using System.Collections;
using System.Collections.Generic;
using Models;
using UnityEngine;

public class SpawnPointBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject spawnPrefab;

    private SpawnPoint model;

    void SpawnEnemy()
    {
        Enemy enemyModel = new Enemy();
        GameObject enemyObject = Instantiate(spawnPrefab);
        enemyObject.GetComponent<EnemyBehaviour>().Initialize(enemyModel);
    }

    public void Initialize(SpawnPoint model)
    {
        this.model = model;
        transform.position = new Vector3(model.position.x, 0, model.position.y);
        InvokeRepeating("SpawnEnemy", model.delay, model.frequency);
    }
}
