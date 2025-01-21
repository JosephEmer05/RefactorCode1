using UnityEngine;

public class Collision : MonoBehaviour
{
    [Header("Collision")]
    [Tooltip("Layer mask to detect walls")]
    [SerializeField] private LayerMask wallLayer;

    [Header("Audio")]
    [SerializeField] private Audio audioHandler;

    [Header("Effects")]
    [SerializeField] private Effects effectHandler;

    private void Awake()
    {
        if (audioHandler == null)
        {
            audioHandler = GetComponent<Audio>();
        }

        if (effectHandler == null)
        {
            effectHandler = GetComponent<Effects>();
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if ((wallLayer.value & (1 << hit.gameObject.layer)) > 0)
        {
            audioHandler.PlayAudioClip();
            effectHandler.PlayParticle();
        }
    }
}
