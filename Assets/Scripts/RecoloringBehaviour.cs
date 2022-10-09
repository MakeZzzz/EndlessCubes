using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RecoloringBehaviour : MonoBehaviour
{
    [SerializeField] private float _recoloringDuration = 2f;
    private float waitingTime = 3f;
    private float timer;
    private Color _startColor;
    private Color _nextColor;
    private Renderer _renderer;

    private float _recoloringTime;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        GenerateNextColor();
    }
    private void Update()
    {
       
        _recoloringTime += Time.deltaTime;
        var progress = _recoloringTime / _recoloringDuration;
        var currentColor = Color.Lerp(_startColor, _nextColor, progress);
        _renderer.material.color = currentColor;
        timer += Time.deltaTime;
        if (timer < waitingTime)
        {
            return;
        }
        if (_recoloringTime > _recoloringDuration)
        {
            _recoloringTime = 0f;
            GenerateNextColor();
            timer = 0;
        }
    }

    private void FixedUpdate()
    {
        throw new NotImplementedException();
    }

    private void GenerateNextColor()
    {
        _startColor = _renderer.material.color;
        _nextColor = Random.ColorHSV(0, 1f, 0.8f, 1f, 1f, 1f);
        
    }
}
