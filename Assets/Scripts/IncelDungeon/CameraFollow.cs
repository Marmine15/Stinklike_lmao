using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject _player;

    private void Update()
    {
        if (_player == null)
        {
            _player = GameObject.FindWithTag("Player");
        }
        else if (_player != null)
        {
            transform.position = new Vector3(_player.transform.position.x, 0f, -10f);
        }
    }
}
