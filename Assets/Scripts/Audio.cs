using UnityEngine;

public class Audio : MonoBehaviour
{
    [Header("Audio")]
    [Tooltip("Audio Clip to play on collision")]
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void PlayAudioClip()
    {
        if (audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
