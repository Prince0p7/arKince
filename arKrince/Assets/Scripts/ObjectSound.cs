using UnityEngine;

public class ObjectSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip objectSound;

    [SerializeField]
    private AudioSource objectSoundSource;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            objectSoundSource.PlayOneShot(objectSound);
        }
    }
}
