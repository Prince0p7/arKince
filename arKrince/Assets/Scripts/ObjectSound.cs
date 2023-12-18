using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip objectSound;

    [SerializeField]
    private AudioSource objectSoundSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            objectSoundSource.PlayOneShot(objectSound);
        }
    }
}
