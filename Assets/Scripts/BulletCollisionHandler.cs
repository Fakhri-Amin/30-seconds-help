using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    [SerializeField] private GameObject destroyVFX;
    [SerializeField] private GameObject freeGhostPrefab;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ghost"))
        {
            var ghostSpawner = other.gameObject.GetComponentInParent<GhostSpawner>();
            ghostSpawner.isSpawned = false;
            Destroy(other.gameObject);
            Instantiate(freeGhostPrefab, other.gameObject.transform.position, Quaternion.identity);
            gameManager.AddScore();

        }
        Destroy(gameObject);
        var dVFX = Instantiate(destroyVFX, transform.position, Quaternion.identity);
        Destroy(dVFX, 2f);
    }
}
