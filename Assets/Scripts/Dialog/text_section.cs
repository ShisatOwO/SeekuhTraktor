using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Dialog
{
  public class TextSection : MonoBehaviour, IEnumerable<TimedCharacter>
  {
    private string _text;
    private float _charDelay;
    private float _wordDelay;
    private float _sentenceDelay;
    private float _pauseDelay;

    public TextSection(string text = "", float charDelay = 0.05f, float wordDelay = 0.1f, float sentenceDelay = 0.2f, float pauseDelay = 0.5f)
    {
      this._text = text;
      this._charDelay = charDelay;
      this._wordDelay = wordDelay;
      this._sentenceDelay = sentenceDelay;
      this._pauseDelay = pauseDelay;
    }

    public string sectionText         {get => _text;          set => _text = value;}
    public float sectionCharDelay     {get => _charDelay;     set => _charDelay = value;}
    public float sectionWordDelay     {get => _wordDelay;     set => _wordDelay = value;}
    public float sectionSentenceDelay {get => _sentenceDelay; set =>  _sentenceDelay = value;}
    public float sectionPauseDelay    {get => _pauseDelay;    set =>  _pauseDelay = value;}

    public IEnumerator<TimedCharacter> GetEnumerator()
    {
      foreach (char c in _text)
      {

        float delay = c switch
        {
          '.' or '!' or '?' or ',' => _sentenceDelay,
          ' ' => _wordDelay,
          '@' => _pauseDelay,
          _ => _charDelay,
        };

        string character = c.ToString();
        if (c == '@') character = "";

        yield return new TimedCharacter(character, delay);
      }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
  }
}
