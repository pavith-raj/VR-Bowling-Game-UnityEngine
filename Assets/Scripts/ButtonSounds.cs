using UnityEngine;
using UnityEngine.UI;

public class ButtonSounds : MonoBehaviour
{
    public AudioClip clickAudio;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;

        AddSounds();
    }

    private void OnEnable()
    {
        
        AddSounds();
    }
    void AddSounds()
    {
        Button[] buttons = FindObjectsOfType<Button>(true);

        foreach (Button btn in buttons)
        {
            btn.onClick.AddListener(PlayClickSound);
        }
    }
    void PlayClickSound()
    {
        audioSource.PlayOneShot(clickAudio);
    }
}
