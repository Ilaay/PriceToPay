using UnityEngine;

namespace Application
{
    public class CameraManager : MonoBehaviour
    {
        private static GameObject _player;
        private static Camera _mainCamera;
        private static Transform _mainCameraStandartTransform;
        private static bool _isMainCameraNotNull;

        private static GameObject _dog;
        private static bool _zoom;

        private void Awake()
        {
            _isMainCameraNotNull = _mainCamera != null;
            _mainCamera = Camera.main;
            _mainCameraStandartTransform = _mainCamera!.transform;
        }

        public static void FocusCameraOnObject(GameObject objectToFocusOn)
        {
            _dog = objectToFocusOn;
            if (_isMainCameraNotNull) return;
            
            //_mainCamera.orthographicSize = 3;
            //_mainCamera.transform.LookAt(objectToFocusOn.transform);

            _zoom = true;
        }
        
        public static void UnfocusCamera()
        {
            if (_isMainCameraNotNull) return;

            var mainCameraTransform = _mainCamera.transform;
            
            //mainCameraTransform.SetPositionAndRotation(_mainCameraStandartTransform.position, Quaternion.Euler(0f, 0f, 0f));
            //_mainCamera.orthographicSize = 5;

            _zoom = false;
        }

        public void LateUpdate()
        {
            if (_zoom)
            {
                _mainCamera.orthographicSize = Mathf.Lerp(_mainCamera.orthographicSize, 3, 0.01f);
                _mainCamera.transform.position = Vector3.Lerp(_mainCamera.transform.position, new Vector3(_dog.transform.position.x, _dog.transform.position.y, -10), 0.02f);
            }
            else
            {
                _mainCamera.orthographicSize = Mathf.Lerp(_mainCamera.orthographicSize, 5, 0.01f);
                _mainCamera.transform.position = Vector3.Lerp(_mainCamera.transform.position, new Vector3(0f, 0f, -10f), 0.02f);

            }
        }
    }
}
