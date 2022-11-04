using System;

public class CubeModel
{
    public event Action<float> ChangedSpeed;
    public event Action<float> ChangedDistance;

    private float _speed;
    private float _distance;

    public CubeModel()
    {
        _speed = 0f;
        _distance = 0f;
    }

    public void SetNewSpeed(float speed)
    {
        _speed = speed;
        ChangedSpeed?.Invoke(_speed);
    }

    public void SetNewDistance(float distance)
    {
        _distance = distance;
        ChangedDistance?.Invoke(_distance);
    }
}