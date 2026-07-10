using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioClip fallSound;
    public AudioClip jumpSound;
    public AudioClip switchSound;
    public AudioClip mirrorSound;
    public AudioClip checkpointSound;
    public AudioClip enemySound;
    public AudioClip victorySound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayJump()
    {
        sfxSource.PlayOneShot(jumpSound);
    }

    public void PlaySwitch()
    {
        sfxSource.PlayOneShot(switchSound);
    }

    public void PlayMirror()
    {
        sfxSource.PlayOneShot(mirrorSound);
    }

    public void PlayCheckpoint()
    {
        sfxSource.PlayOneShot(checkpointSound);
    }

    public void PlayEnemy()
    {
        sfxSource.PlayOneShot(enemySound);
    }
      
    public void PlayVictory()
    {   
        sfxSource.PlayOneShot(victorySound);
    }

    public void PlayFall()
{
    sfxSource.PlayOneShot(fallSound);
}
}