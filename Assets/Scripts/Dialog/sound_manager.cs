using UnityEngine;


namespace Dialog
{
  public class SoundManager : MonoBehaviour
  {
      public static SoundManager instance {get; private set;}

      public AudioClip clip{get; private set;}
      public bool playing {get => audioSource.isPlaying;}

      private AudioSource audioSource;

      private void Awake()
      {
        instance = this;
        audioSource = GetComponent<AudioSource>();
      } 

      public void playOnceExclusive(AudioClip clip) 
      {
        this.clip = clip;
        audioSource.Stop();
        audioSource.PlayOneShot(clip);
      }

      public void playOnce(AudioClip clip)
      {
        this.clip = clip;
        audioSource.PlayOneShot(clip);
      }

   }
}
