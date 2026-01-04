
using UnityEngine;
using System.Collections;

public class SteamVent : MonoBehaviour
{
    public ParticleSystem steamParticles;
    public Collider steamTrigger;
    public float activeDuration = 2f;
    public float inactiveDuration = 2f;

    void Start()
    {
        if (steamParticles == null || steamTrigger == null)
        {
            Debug.LogError("SteamVent: References NOT assigned!");
            return;
        }

        StartCoroutine(SteamCycle());
    }

    IEnumerator SteamCycle()
    {
        while (true)
        {
            steamParticles.Play();
            steamTrigger.enabled = true;
            yield return new WaitForSeconds(activeDuration);

            steamParticles.Stop();
            steamTrigger.enabled = false;
            yield return new WaitForSeconds(inactiveDuration);
        }
    }
}