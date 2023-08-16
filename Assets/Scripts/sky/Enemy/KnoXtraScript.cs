using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnoXtraScript : NewBaseSkyE
{
	private Vector3 normKnoTransScale;
    public bool rotate;

    private int _rot_frame_border;
    private bool _reset_rot;
    private int _rot_frame_count = 0;
    // Start is called before the first frame update
    

    public void OnBecameVisible()
    {
        _wasOnScreen = true;
        normKnoTransScale = new Vector3(1f,1f,1f) + new Vector3 (Random.Range(-10f,15f)/10f, Random.Range(-1,2), 0f);
        if(normKnoTransScale.x == 0f || normKnoTransScale.y == 0f) {
            normKnoTransScale.x = 1.1f;
            normKnoTransScale.y = 0.9f;
        }
        transform.localScale = normKnoTransScale;
        Debug.Log("normKnoTransScale" + normKnoTransScale); 
    }

    void FixedUpdate() {
        Rotate();
    }

        void Rotate() {
        if(_reset_rot) {
            _rot_frame_border = Mathf.RoundToInt(Random.Range(0.7f,1f)*300f);
        _reset_rot = false;
        }
        _rot_frame_count += 1;

        if (_rot_frame_count >= _rot_frame_border) {
            _rot_frame_count = 0;
            _reset_rot = true;
            gameObject.GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-180f,180f)*100;
        }
    }
}
