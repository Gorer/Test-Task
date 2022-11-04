using UnityEngine;

public class CubeView : MonoBehaviour
{
    public Vector3 _targetPosition;
    public float _moveSpeed;

    void Update()
    {
        FollowDestination();
    }

    private void FollowDestination()
    {
        if (transform.position == _targetPosition)
        {
            Destroy(gameObject);
        }

        float delta = _moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, delta);
    }

    public void SpecifyDestination(float distance)
    {
        if (gameObject.transform.position != new Vector3(0, 0, 0))
            _targetPosition = gameObject.transform.position.normalized * distance;
        else
            _targetPosition = new Vector3(0, 1, 0) * distance;
    }

    public void SpecifyMoveSpeed(float moveSpeed)
    {
        _moveSpeed = moveSpeed;
    }
}
