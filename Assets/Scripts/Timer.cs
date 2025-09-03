using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour 
{
    public GUIStyle ClockStyle;

    private float _timer;
    private float _minutes;
    private float _seconds;

    private const float VirtualWidth = 480.0f;
    private const float VirtualHeight = 854.0f;

    private bool _stopTimer;
    private Matrix4x4 _matrix;
    private Matrix4x4 _oldMatrix;

    void Start()
    {
        _stopTimer = false;
        _matrix = Matrix4x4.TRS(pos: Vector3.zero, Quaternion.identity, s: new Vector3(x: Screen.width / VirtualWidth, y: Screen.height / VirtualHeight, z: 1.0f));
        _oldMatrix = GUI.matrix;
    }

    void Update()
    {
        if(!_stopTimer)
            _timer += Time.deltaTime;
    }

    private void OnGUI()
    {
        GUI.matrix = _matrix;

        _minutes = Mathf.Floor(f: _timer / 60);
        _seconds = Mathf.RoundToInt(f:_timer % 60);

        GUI.Label(position: new Rect(x: Camera.main.rect.x + 20, y: 10, width: 120, height: 50), text: "" + _minutes.ToString(format: "00") + ":" + _seconds.ToString(format: "00"), ClockStyle);

        GUI.matrix = _oldMatrix;
    }

    public float GetCurrentTime()
    {
        return _timer;
    }

    public void StopTimer()
    {
        _stopTimer = true; 
    }

}
