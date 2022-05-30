using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeGhost : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, moveSpeed) * Time.deltaTime);
    }
}
