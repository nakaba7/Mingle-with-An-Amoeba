using UnityEngine;

/// <summary>
/// ��ɃJ�����̕�������L�����o�X
/// </summary>
public class LookAtCameraCanvas : MonoBehaviour
{

    [SerializeField]
    private Transform _camera = null;

    private void Update()
    {
        transform.LookAt(_camera);
    }

}