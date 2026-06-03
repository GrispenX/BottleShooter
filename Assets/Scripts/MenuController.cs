using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}