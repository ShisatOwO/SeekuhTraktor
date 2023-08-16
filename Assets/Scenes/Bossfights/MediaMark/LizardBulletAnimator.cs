using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardBulletAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Sprite NomNomOpen;
    [SerializeField] private Sprite NomNomClosed;
    [SerializeField] private float NomNomInterval;

    private float _timePassed;
    private bool _isOpen;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _timePassed = 0;
        _isOpen = true;
        _spriteRenderer.sprite = NomNomOpen;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timePassed >= NomNomInterval)
        {
            if (_isOpen) _spriteRenderer.sprite = NomNomClosed;
            else _spriteRenderer.sprite = NomNomOpen;
            _isOpen = !_isOpen;
            _timePassed = 0;
        }

        _timePassed += Time.deltaTime;
    }
}
