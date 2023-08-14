using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneController
{
    public enum SceneState
    {
        Gameplay,
        Cutscene,
        Dialog,
    }
    
    public abstract class SceneActor : MonoBehaviour
    {
        public void notifyState(SceneState state)
        {
            
        }
    }
}
