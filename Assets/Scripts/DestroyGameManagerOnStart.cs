using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameManagerOnStart : MonoBehaviour
{
    private void Awake()
    {
        var gameManager = FindObjectOfType<GameManager>();
        if (!gameManager) return;
        Destroy(gameManager.gameObject);
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
