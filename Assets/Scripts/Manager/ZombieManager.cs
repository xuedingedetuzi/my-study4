using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum SpawnState
{
    NotStart,Spawning,End
}

public class ZombieManager : MonoBehaviour
{
    // Start is called before the first frame update
    private SpawnState spawnState = SpawnState.NotStart;
    public static ZombieManager Instance { get; private set; }

    public Transform[] spawnPointList;

    public GameObject zombiePrefab;

    private List<Zombie> zombielist= new List<Zombie>();
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        if (spawnState == SpawnState.NotStart && zombielist.Count == 0)
        {
            GameManager.Instance.GameEndSuccess();
        }
    }

    public void StartSpawn()
    {
        spawnState = SpawnState.Spawning;
        StartCoroutine(SpanwnZombie());
    }

    public void Pause()
    {
        spawnState= SpawnState.End;
        foreach(Zombie zombie in zombielist) 
        {
            zombie.TransitionToPause(); 
        }
    }

    IEnumerator SpanwnZombie()
    {
        yield return new WaitForSeconds(10);
        for (int i = 0; i < 5; i++)
        {
            SpawnARandomZombie();
            yield return new WaitForSeconds(8);
        }
        yield return new WaitForSeconds(15);
        for (int i = 0; i < 10; i++)
        {
            SpawnARandomZombie();
            yield return new WaitForSeconds(5);
        }
        yield return new WaitForSeconds(20);
        for (int i = 0; i < 15; i++)
        {
            SpawnARandomZombie();
            yield return new WaitForSeconds(3);
        }
        spawnState = SpawnState.End;
    }
    private void SpawnARandomZombie()
    {
        if (spawnState == SpawnState.Spawning) 
        { 
            int index = Random.Range(0, spawnPointList.Length);
            GameObject go=GameObject.Instantiate(zombiePrefab, spawnPointList[index].position, Quaternion.identity);
            
            zombielist.Add(go.GetComponent<Zombie>());
            go.GetComponent<SpriteRenderer>().sortingOrder = spawnPointList[index].GetComponent<SpriteRenderer>().sortingOrder;
            ;
        }
    }
    public void RemoveZombie(Zombie zombie)
    {
        zombielist.Remove(zombie);
    }
}
