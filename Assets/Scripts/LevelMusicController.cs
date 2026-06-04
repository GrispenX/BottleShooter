using Unity.VisualScripting;
using UnityEngine;

enum MusicState
{
    Stopped,
    Started,
    Paused
}

public class LevelMusicController : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] public AudioClip audioClip;

    private double startDspTime = 0;
    private double pauseDspTime;
    private MusicState state = MusicState.Stopped;
    public double CurrentTime
    {
        get
        {
            if(state == MusicState.Started) return AudioSettings.dspTime - startDspTime;
            if(state == MusicState.Paused) return pauseDspTime - startDspTime;
            return 0;
        }
    }

    public void StartMusic()
    {
        if(state != MusicState.Stopped) return;
        state = MusicState.Started;
        startDspTime = AudioSettings.dspTime + 0.1f;
        musicSource.clip = audioClip;
        musicSource.PlayScheduled(startDspTime);
    }

    public void StopMusic()
    {
        state = MusicState.Stopped;
        musicSource.Stop();
    }

    public void PauseMusic()
    {
        if(state != MusicState.Started) return;
        state = MusicState.Paused;
        pauseDspTime = AudioSettings.dspTime;
        musicSource.Pause();
    }

    public void UnpauseMusic()
    {
        if(state != MusicState.Paused) return;
        state = MusicState.Started;
        startDspTime += AudioSettings.dspTime - pauseDspTime;
        musicSource.UnPause();
    }
}
