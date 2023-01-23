using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform _target;
    private float _speedX = 360.0f;
    private float _speedY = 240.0f;
    private float _limitY = 40.0f;
    private float _hideDistance = 2.0f;
    private float _maxDistance;
    private Vector3 _localPos;
    private float _currentYRotation;

    public LayerMask worldLayer;
    public LayerMask player;
    private LayerMask _camOriginMask;

    private Vector3 _position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }
    
    void Start()
    {
        _localPos = _target.InverseTransformPoint(_position);
        _maxDistance = Vector3.Distance(_position, _target.position);
    }
    
    void LateUpdate()
    {
        _position = _target.TransformPoint(_localPos);
        CameraRotation();
        ObstaclesReact();
        _localPos = _target.InverseTransformPoint(_position);
    }

    void CameraRotation()
    {
        var _mouseX = Input.GetAxis("Mouse X");
        var _mouseY = Input.GetAxis("Mouse Y");

        if (_mouseY != 0)
        {
            var tmp = Mathf.Clamp(_currentYRotation + _mouseY * _speedY * Time.deltaTime, -_limitY, _limitY);
            if (tmp != _currentYRotation)
            {
                var rot = tmp - _currentYRotation;
                transform.RotateAround(_target.position, transform.right, rot);
                _currentYRotation = tmp;
            }
        }

        if (_mouseX != 0)
        {
            transform.RotateAround(_target.position, Vector3.up, _mouseX * _speedX * Time.deltaTime);
        }
        transform.LookAt(_target);
    }

    void ObstaclesReact()
    {
        var distance = Vector3.Distance(_position, _target.position);
        RaycastHit hit;
        if (Physics.Raycast(_target.position, transform.position - _target.position, out hit, _maxDistance, worldLayer))
        {
            _position = hit.point;
        } else if (distance < _maxDistance && !Physics.Raycast(_position, -transform.forward, 0.1f,worldLayer ))
        {
            _position -= transform.forward * .05f;
        }
        

    }

    void PlayerReact()
    {
        var distance = Vector3.Distance(_position, _target.position);
        if (distance < _hideDistance)
        {
            UnityEngine.Camera.current.cullingMask = player;
        }
        else
        {
            UnityEngine.Camera.current.cullingMask = _camOriginMask;
        }

    }
}
