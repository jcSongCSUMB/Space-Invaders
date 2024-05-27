using UnityEngine;

public class DestroyOnFinish : MonoBehaviour
{
    private ParticleSystem theParticle;

    void Start()
    {
        theParticle = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (theParticle && !theParticle.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}

