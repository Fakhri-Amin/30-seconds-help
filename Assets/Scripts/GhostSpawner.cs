using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ghostGameObject;
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;

    public bool isSpawned;

    void Start()
    {
        // ghostGameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawned)
        {
            float randomNum = UnityEngine.Random.Range(minSpawnTime, maxSpawnTime);
            Invoke("Spawn", randomNum);
            isSpawned = true;
            maxSpawnTime -= 0.5f;
        }
    }

    void Spawn()
    {
        var ghost = Instantiate(ghostGameObject, new Vector2(transform.position.x, transform.position.y + 0.8f), Quaternion.identity);
        ghost.transform.parent = transform;
    }

}
