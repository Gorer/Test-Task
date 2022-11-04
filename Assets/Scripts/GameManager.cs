using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Для спавна
    [SerializeField] private TMP_InputField _timeInputField;

    [SerializeField] private GameObject _spawnPrefab;
    private SpawnController _spawnController;
    private SpawnModel _spawnModel;

    // Для куба
    [SerializeField] private TMP_InputField _speedInputField;
    [SerializeField] private TMP_InputField _distanceInputField;

    [SerializeField] private GameObject _cubePrefab;
    private CubeController _cubeController;
    private CubeModel _cubeModel;

    void Start()
    {
        ManageSpawn();
        ManageCube();
    }

    private void ManageSpawn()
    {
        _spawnModel = new SpawnModel();

        var spawnView = _spawnPrefab.GetComponent<SpawnView>();

        _spawnController = new SpawnController(spawnView, _spawnModel, _timeInputField, _speedInputField, _distanceInputField);
    }

    private void ManageCube()
    {
        _cubeModel = new CubeModel();

        var cubeView = _cubePrefab.GetComponent<CubeView>();

        _cubeController = new CubeController(cubeView, _cubeModel, _speedInputField, _distanceInputField);
    }
}
