using System.Collections;
using System.Collections.Generic;
using Models;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject basePrefab;
    public GameObject spawnPointPrefab;

    private List<Base> baseList = new List<Base>();
    
    void Start()
    {
        App.levelManager = this;
        App.screenManager.Hide<MenuScreen>();
        App.screenManager.Show<InGameScreen>();

        Base base1 = new Base(100);
        baseList.Add(base1);
        Instantiate(basePrefab, new Vector3(base1.position.x, 0.5f, base1.position.y), Quaternion.identity);

        SpawnPoint spawn = new SpawnPoint(1, 2, new Vector2(-4, 3));

        GameObject spawnGameObject = Instantiate(spawnPointPrefab);
        spawnGameObject.GetComponent<SpawnPointBehaviour>().Initialize(spawn);
    }

    public Base GetNearestBase()
    {
        //TODO find neearest
        return baseList[0];
    }
}
