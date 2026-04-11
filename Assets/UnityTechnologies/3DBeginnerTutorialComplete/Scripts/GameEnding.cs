using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public AudioSource exitAudio;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource caughtAudio;

    public float endDelay = 1f;
    public MonoBehaviour playerMovement;
    public ParticleSystem deathParticles;
    public AudioSource walkingAudio;

    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    float m_Timer;
    bool m_HasAudioPlayed;
    
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    public void CaughtPlayer ()
    {
        m_IsPlayerCaught = true;
    }

    void Update ()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel (exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if (m_IsPlayerCaught)
        {
            EndLevel (caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }


    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        // stop player movement
        if (playerMovement.enabled)
        {
            playerMovement.enabled = false;
        }

        // hide player model
        if (player.activeSelf)
        {
            SkinnedMeshRenderer[] smrs = player.GetComponentsInChildren<SkinnedMeshRenderer>();
            foreach (SkinnedMeshRenderer s in smrs)
            {
                s.enabled = false;
            }
        }

        // show particles
        if (deathParticles != null)
        {
            deathParticles.Play();
        }

        //stop walking sound effects
        if (walkingAudio != null)
        {
            walkingAudio.Stop();
        }

        m_Timer += Time.deltaTime;
        if (m_Timer < endDelay)
            return;

        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }

        float fadeTimer = m_Timer - endDelay;
        imageCanvasGroup.alpha = fadeTimer / fadeDuration;

        if (fadeTimer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene (0);
                // turn on mesh render
            }
            else
            {
                Application.Quit ();
            }
        }
    }
}
