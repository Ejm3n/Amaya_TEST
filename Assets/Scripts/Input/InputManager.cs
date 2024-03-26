using System;
using System.Collections;
using UnityEngine;

namespace AmayaTest
{
    public class InputManager : MonoBehaviour
    {
        public event Action<Vector3> OnInput;

        [SerializeField] 
        private float clickDeltaTime = 0.5f;
        
        private Camera _camera;

        private bool _isPlaying = false;

        private float lastClick = 0f;

        private void Awake()
        {
            _camera = Camera.main;
        }

        public void TurnOn()
        {
            if (_isPlaying)
                return;

            _isPlaying = true;
            StartCoroutine(InputProcess());
        }

        public void TurnOff()
        {
            if (!_isPlaying)
                return;

            _isPlaying = false;
            StopCoroutine(InputProcess());
        }

        /// <summary>
        /// проверка нажатия вовремя
        /// </summary>
        IEnumerator InputProcess()
        {
            while (_isPlaying)
            {
                if (Input.GetMouseButtonDown(0) && (Time.realtimeSinceStartup - lastClick > clickDeltaTime))
                {
                    OnInput?.Invoke(GetInputPosition());
                    lastClick = Time.realtimeSinceStartup;
                }
                yield return null;
            }
        }

        private Vector3 GetInputPosition()
        {
            return _camera.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}