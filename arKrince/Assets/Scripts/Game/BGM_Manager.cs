using UnityEngine;

public class BGM_Manager : MonoBehaviour
{
    public AudioClip[] backgroundSounds;
    private AudioSource audioSource;
    private int currentIndex = 0;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = false;

        NextBGM();
    }

    void NextBGM()
    {
        if (backgroundSounds.Length > 0)
        {
            audioSource.clip = backgroundSounds[currentIndex];
            audioSource.Play();
            currentIndex = (currentIndex + 1) % backgroundSounds.Length;

            Invoke("NextBGM", audioSource.clip.length);
        }
    }
}