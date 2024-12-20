using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem hitParticles; // Reference to the particle system

    public void PlayHitEffect()
    {
        hitParticles.Play();
    }
}
