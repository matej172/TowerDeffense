using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Models;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject basePrefab;
    public GameObject spawnPointPrefab;

    public class DestoryBaseEvent : UnityEvent<Base> {};
    
    public DestoryBaseEvent OnDestroyBase = new DestoryBaseEvent();

    private List<Base> baseList = new List<Base>();
    
    void Start()
    {
        App.levelManager = this;
        App.screenManager.Hide<MenuScreen>();
        App.screenManager.Show<InGameScreen>();

        Base base1 = new Base(20, new Vector2(4, 4));
        baseList.Add(base1);
        GameObject baseGameObject1 = Instantiate(basePrefab);
        baseGameObject1.GetComponent<BaseBehaviour>().Initialize(base1);
        
        Base base2 = new Base(10, new Vector2(4, -4));
        baseList.Add(base2);
        GameObject baseGameObject2 = Instantiate(basePrefab);
        baseGameObject2.GetComponent<BaseBehaviour>().Initialize(base2);
        
        SpawnPoint spawn1 = new SpawnPoint(5, 1, new Vector2(-4, 3));
        GameObject spawnGameObject1 = Instantiate(spawnPointPrefab);
        spawnGameObject1.GetComponent<SpawnPointBehaviour>().Initialize(spawn1);
        
        SpawnPoint spawn2 = new SpawnPoint(5, 1, new Vector2(-4, -3));
        GameObject spawnGameObject2 = Instantiate(spawnPointPrefab);
        spawnGameObject2.GetComponent<SpawnPointBehaviour>().Initialize(spawn2);
    }

    public Base GetNearestBase()
    {
        //TODO find neearest
        return baseList.First();
    }

    public void RemoveBase(Base zakladna)
    {
        baseList.Remove(zakladna);
        OnDestroyBase.Invoke(zakladna);
    }
}
