using Mirror;
using UnityEngine;

public class ServerMove : NetworkBehaviour
{
    [SerializeField] private float _speed = 1f;

    private void Update()
    {
        if (!isLocalPlayer) return;

        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection -= transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection -= transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += transform.right;
        }

        CmdMove(moveDirection);
    }    

    [Command]
    private void CmdMove(Vector3 moveDirection)
    {
        transform.position += moveDirection.normalized * _speed * Time.deltaTime;
    }
}
