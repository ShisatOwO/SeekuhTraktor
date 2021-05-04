using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void toSceneGame() {SceneManager.LoadScene("Game");}
    public void toSceneMenu() {SceneManager.LoadScene("MainMenu");}

    public void toSceneHighscore() {SceneManager.LoadScene("HighscoreAfterGame");}

    public void toSceneHighscoreMenu() {SceneManager.LoadScene("HighscoreFromMenu");}
}
