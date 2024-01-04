using UnityEngine;
using UnityEngine.UI;
using System.Collections;



namespace Dialog
{
  public class TextLine : TextSection
  {
      [Header ("Dialog Settings")]
      [SerializeField] private bool speakerIsPlayer;
      [SerializeField] private string dialogLine;
      [SerializeField] private Sprite characterPortrait;
      [SerializeField] private Image characterPortraitDisplay;
      [SerializeField] private AudioClip audio;
      [SerializeField] private TextLine nextLine;

      [Header ("Delay Settings")]
      [SerializeField] private float charDelay;
      [SerializeField] private float wordDelay;
      [SerializeField] private float sentenceDelay;
      [SerializeField] private float pauseDelay;
      [SerializeField] private float textScrollSpeed;

      [Header("Font Settings")]
      [SerializeField] private Color color;
      [SerializeField] private Font font;
      [SerializeField] private int fontSize;

      private Text text;
      private bool finished;
      private bool answered;
      private bool stopped = false;
      private bool active = false;

      public TextLine() : base() 
      {
        finished = false;
        answered = false;
      }

      public virtual void speak()
      {
        // Text Component Anpassen.
        text = GetComponent<Text>();
        text.font = font;
        text.fontSize = fontSize;
        text.color = color;

        // Text in die TextSection packen.
        // und den Text im Textfeld auf "" setzen.
        sectionText = dialogLine;
        text.text = "";

        // Setup Character Portrait.
        characterPortraitDisplay.sprite = characterPortrait;
        
        // Delay Einstellungen Übertragen und text scrollspeed einstellen.
        sectionCharDelay = charDelay * textScrollSpeed;
        sectionWordDelay = wordDelay * textScrollSpeed;
        sectionSentenceDelay = sentenceDelay * textScrollSpeed;
        sectionPauseDelay = pauseDelay * textScrollSpeed;
        active = true;
        StartCoroutine(_writer());
      }

      private IEnumerator _writer()
      {
        SoundManager soundManager = SoundManager.instance;

        if (!finished)
        {
          foreach(TimedCharacter c in this)
          {
            if(!stopped) {
              text.text += c.character;
            
              if (soundManager != null && c.character != "" && c.character != " ")
              {
                soundManager.playOnceExclusive(audio);
              }
              yield return c.waitTime;
            }

            else yield break;
            
          }
        }
       
        finished = true;
        active = false;
      }

      private void Start()
      {
        //this.enabled = false;
      }

      public void Update()
      {
        if (Input.GetKeyDown("space") || Input.GetKeyDown(KeyCode.Return))
        {
          if (finished && !answered && nextLine != null)
          {
            text.text = "";
            nextLine.speak();
            this.enabled = false;
          }

          else if (finished)
          {
            answered = true;
            active = false;
          }


          /*else
          {
            finished = true;
            answered = true;

            StopCoroutine(_writer());

            text.text = "";
            //nextLine.speak();
            //this.enabled = false;
          }*/
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && active || Input.GetKeyDown(KeyCode.RightShift) && active)
        {
          stopped = true;
          text.text = "";
          active = false;
          nextLine.speak();
          this.enabled = false;
        }


      }
      
  }
}
