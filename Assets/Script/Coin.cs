using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip[] audioClipArr;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        int coinAudio = 0;
        if (collision.gameObject.tag == "Coin")
        {
            audioSource.PlayOneShot(audioClipArr[coinAudio]);
        }
    }
}
