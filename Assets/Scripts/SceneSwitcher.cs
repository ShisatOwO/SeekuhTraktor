using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void toSceneGame() {SceneManager.LoadScene("Game");}
    public void toSceneMenu() {SceneManager.LoadScene("MainMenu");}

    public void toSceneScoreboard() {SceneManager.LoadScene("ScoreBoard");}

    public void toSceneScoresubmit() {SceneManager.LoadScene("ScoreSubmit");}
}
