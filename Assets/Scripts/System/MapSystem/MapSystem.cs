using System.Collections.Generic;
using UnityEngine;
using _.Scripts.Tools;
using System.Data;

public class MapSystem : Singleton<MapSystem>, ISystem
{
    public GameObject[] mainChunks; // 主要區塊預製物
    public GameObject[] transitionChunks; // 過渡區域預製物
    public int maxChunks = 5; // 保持的最大區塊數量
    public float chunkSize = 100f; // 每個區塊的大小

    private LinkedList<GameObject> activeChunks = new LinkedList<GameObject>();
    private int currentChunkIndex = 0; // 記錄玩家所在的區塊索引
    private Transform player;
    public int chunkIndex;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        GenerateInitialChunks();
    }

    void GenerateInitialChunks()
    {
        for (int i = 0; i < maxChunks; i++)
        {
            SpawnChunk(i);
        }
        chunkIndex = maxChunks - 1;

    }


    public void SpawnChunk(int index)
    {
        Vector3 position = new Vector3(index * chunkSize, 0, 0);
        GameObject prefab = (index % 2 == 0) ? GetRandomChunk(mainChunks) : GetRandomChunk(transitionChunks);
        GameObject chunk = Instantiate(prefab, position, Quaternion.identity);
        activeChunks.AddLast(chunk);
    }
    public void SpawnChunk()
    {
        chunkIndex++;

        Vector3 position = new Vector3(chunkIndex * chunkSize, 0, 0);
        GameObject prefab = (chunkIndex % 2 == 0) ? GetRandomChunk(mainChunks) : GetRandomChunk(transitionChunks);
        GameObject chunk = Instantiate(prefab, position, Quaternion.identity);
        activeChunks.AddLast(chunk);
    }


    GameObject GetRandomChunk(GameObject[] chunkArray)
    {
        return chunkArray[Random.Range(0, chunkArray.Length)];
    }



    public void RemoveOldChunk()
    {
        if (activeChunks.Count > maxChunks)
        {
            GameObject oldChunk = activeChunks.First.Value;
            activeChunks.RemoveFirst();
            Destroy(oldChunk);
        }
    }

    public void InitSystem()
    {
    }

    public void ShutDownSystem()
    {
    }
}
