using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dialog;

namespace Dialog
{ 
    public class DialogTest : MonoBehaviour
    {
        [SerializeField] private TextLine firstLine;

        // Start is called before the first frame update
        void Start()
        {
            if (firstLine != null) firstLine.speak();
        }
    }
}
