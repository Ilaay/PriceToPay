using UnityEngine;

namespace Application
{
    public class CameraManager : MonoBehaviour
    {
        private static GameObject _objectToFocusOn;
        private static GameObject _player;
        private static Camera _mainCamera;
        private static bool _isMainCameraNotNull;
        private static bool _zoomModeActive;

        private void Awake()
        {
            _isMainCameraNotNull = _mainCamera != null;
            _mainCamera = Camera.main;
        }

        public static void FocusCameraOnObject(GameObject objectToFocusOn)
        {
            _objectToFocusOn = objectToFocusOn;
            if (_isMainCameraNotNull) return;

            _zoomModeActive = true;
        }
        
        public static void UnfocusCamera()
        {
            if (_isMainCameraNotNull) return;
            
            _zoomModeActive = false;
        }

        public void LateUpdate()
        {
            if (_zoomModeActive)
            {
                _mainCamera.orthographicSize = Mathf.Lerp(_mainCamera.orthographicSize, 3, 0.01f);
                _mainCamera.transform.position = Vector3.Lerp(_mainCamera.transform.position, new Vector3(_objectToFocusOn.transform.position.x, _objectToFocusOn.transform.position.y, -10), 0.02f);
            }
            else
            {
                _mainCamera.orthographicSize = Mathf.Lerp(_mainCamera.orthographicSize, 5, 0.01f);
                _mainCamera.transform.position = Vector3.Lerp(_mainCamera.transform.position, new Vector3(0f, 0f, -10f), 0.02f);
            }
        }
    }
}
