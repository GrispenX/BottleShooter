using Unity.VisualScripting;
using UnityEngine;

public class LevelMusicController : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip audioClip;

    private double startDspTime;
    public double CurrentTime
    {
        get
        {
            return AudioSettings.dspTime - startDspTime;
        }
    }

    public void StartMusic()
    {
        startDspTime = AudioSettings.dspTime + 0.1f;
        musicSource.clip = audioClip;
        musicSource.PlayScheduled(startDspTime);
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}
