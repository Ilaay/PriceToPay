using UnityEngine;

namespace Application
{
    public class CameraManager : MonoBehaviour
    {
        private static GameObject _player;
        private static Camera _mainCamera;
        private static Transform _mainCameraStandartTransform;
        private static bool _isMainCameraNotNull;

        private void Awake()
        {
            _isMainCameraNotNull = _mainCamera != null;
            _mainCamera = Camera.main;
            _mainCameraStandartTransform = _mainCamera!.transform;
        }

        public static void FocusCameraOnObject(GameObject objectToFocusOn)
        {
            if (_isMainCameraNotNull) return;
            
            _mainCamera.orthographicSize = 3;
            _mainCamera.transform.LookAt(objectToFocusOn.transform);
        }
        
        public static void UnfocusCamera()
        {
            if (_isMainCameraNotNull) return;

            var mainCameraTransform = _mainCamera.transform;
            
            mainCameraTransform.SetPositionAndRotation(_mainCameraStandartTransform.position, Quaternion.Euler(0f, 0f, 0f));
            _mainCamera.orthographicSize = 5;
        }
    }
}
