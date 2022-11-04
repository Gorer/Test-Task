using System;

public class SpawnModel
{
    public event Action<float> ChangedTimeBetweenWaves;

    private float _timeBetweenWaves;

    public SpawnModel()
    {
        _timeBetweenWaves = 0f;
    }

    public void SetNewTime(float timeBetweenWaves)
    {
        _timeBetweenWaves = timeBetweenWaves;
        ChangedTimeBetweenWaves?.Invoke(_timeBetweenWaves);
    }
}
