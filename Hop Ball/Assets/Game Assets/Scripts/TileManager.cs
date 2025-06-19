using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public static TileManager _instance;

    public int tilesToInstantiate;

    [Header("Tile Prefab")]

    public List<GameObject> tilesBeingSpawned;
    public List<GameObject> tileData;
    public GameObject objToSpawn;
    public Transform storeTiles;
    
    [Header("Positions")]

    [SerializeField] private GameObject leftRangeObj;
    [SerializeField] private GameObject rightRangeObj;

    [Header("Gameplay")]

    public int itemsSpawned = 0;
    public bool isGameOver = false;
    public bool canSpawn = true;

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        tilesToInstantiate = Random.Range(100, 200);
        InstantiateTile();
    }

    private void Update()
    {
        if(!isGameOver && canSpawn && itemsSpawned < tilesToInstantiate)
        {
            ChooseGameObject();
            InstantiateTile();
        }
    }

    public void ChooseGameObject()
    {
        int child = Random.Range(0, tileData.Count);
        objToSpawn = tileData[child];   
    }

    public void InstantiateTile()
    {
        float randomPosX = Random.Range(leftRangeObj.transform.position.x, rightRangeObj.transform.position.x);
        Vector3 spawnPosition = new Vector3(randomPosX, 0f, 0f);
        GameObject _tileSpawned = Instantiate(objToSpawn, spawnPosition, Quaternion.identity, storeTiles.transform);
        itemsSpawned++;
        tilesBeingSpawned.Add(_tileSpawned);
        canSpawn = false;
        StartCoroutine(SetCanSpawnToTrue(1f));
    }

    private IEnumerator SetCanSpawnToTrue(float time)
    {
        yield return new WaitForSeconds(time);
        canSpawn = true;
    }
}