using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static soundManager instance;
    [SerializeField]
    private AudioSource soundFX;
    [SerializeField]
    private AudioClip landClip, deathClip, iceBreakClip, gameOverClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void landSound()
    {
        soundFX.clip = landClip;
        soundFX.Play();
    }

    public void iceBreakSound()
    {
        soundFX.clip = iceBreakClip;
        soundFX.Play();
    }

    public void deathSound()
    {
        soundFX.clip = deathClip;
        soundFX.Play();
    }

    public void gameOverSound()
    {
        soundFX.clip = gameOverClip;
        soundFX.Play();
    }
}
