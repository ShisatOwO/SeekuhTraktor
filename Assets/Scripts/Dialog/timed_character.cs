using UnityEngine;


namespace Dialog
{
  public class TimedCharacter
  {
    private WaitForSeconds _waitTime;
    private string _character;

    public TimedCharacter(string character, float delay) 
    {
      this._waitTime = new WaitForSeconds(delay);
      this._character = character;
    }

    public string character {get => _character;}
    public WaitForSeconds waitTime {get => _waitTime;}
  }
}
