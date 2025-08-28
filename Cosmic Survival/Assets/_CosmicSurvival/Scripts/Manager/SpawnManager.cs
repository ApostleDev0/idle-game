using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;// bien luu Prefab quai vat
    public Transform spawnGate;// luu giu vi tri gate spawner
    public float spawnInterval = 2f;// thoi gian giua moi lan trieu hoi
    public float spawnTimer = 0f;// bien dem thoi gian

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer = spawnTimer + Time.deltaTime;// cong don time troi qua
        // kiem tra time trieu hoi du chua
        if(spawnTimer >= spawnInterval)
        {
            SpawnEnemy();// goi ham trieu hoi enemy
            spawnTimer = 0f;// reset dem = 0
        }
    }

    // ham spawn enemy
    void SpawnEnemy()
    {   
        // tao ban sao Prefab enemy tai gate
        Instantiate(enemyPrefab, spawnGate.position, Quaternion.identity); 
    }
}
