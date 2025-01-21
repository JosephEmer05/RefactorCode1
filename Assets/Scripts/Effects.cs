using UnityEngine;

public class Effects : MonoBehaviour
{
    [Header("Effects")]
    [Tooltip("Particle system to play on collision")]
    [SerializeField] private ParticleSystem partSys;

    public void PlayParticle()
    {
        if (partSys != null)
        {
            partSys.Play();
        }
    }
}
