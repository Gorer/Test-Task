using TMPro;
using UnityEngine.Events;

public class SpawnController
{
    private UnityAction<string> _inputEndChangeAction;
    private delegate void InputEndChangeDelegate(TMP_InputField textInputField, string oldText);

    private SpawnView _spawnView;
    private SpawnModel _spawnModel;

    private TMP_InputField _timeInputField;

    // ƒл€ проверки данных куба дл€ возможности спавна
    private TMP_InputField _speedInputField;
    private TMP_InputField _distanceInputField;

    public SpawnController(SpawnView spawnView, SpawnModel spawnModel, TMP_InputField timeInputField, TMP_InputField speedInputField, TMP_InputField distanceInputField)
    {
        _spawnView = spawnView;
        _spawnModel = spawnModel;

        _timeInputField = timeInputField;

        _speedInputField = speedInputField;
        _distanceInputField = distanceInputField;

        Enable();
    }

    public void Enable()
    {
        _timeInputField.onSelect.AddListener(delegate { InputValueSelect(_timeInputField); });
        _spawnModel.ChangedTimeBetweenWaves += EnableSpawn;

        _speedInputField.onSelect.AddListener(delegate { InputValueSelect(_speedInputField); });
        _distanceInputField.onSelect.AddListener(delegate { InputValueSelect(_distanceInputField); });
    }

    private void InputValueSelect(TMP_InputField textInputField)
    {
        string oldText = textInputField.text;
        _inputEndChangeAction = delegate { InputEndChange(textInputField, oldText); };
        textInputField.onEndEdit.AddListener(_inputEndChangeAction);
    }

    private void InputEndChange(TMP_InputField textInputField, string oldText)
    {
        string timeText = _timeInputField.text;
        string speedText = _speedInputField.text;
        string distanceText = _distanceInputField.text;
        if (CheckInputValue(timeText) && CheckInputValue(speedText) && CheckInputValue(distanceText))
        {
            if (!textInputField.text.Equals(oldText))
            {
                _spawnView.DisableSpawn();
                _spawnModel.SetNewTime(float.Parse(timeText));
            }
        }
        else
        {
            _spawnView.DisableSpawn();
        }
        textInputField.onEndEdit.RemoveListener(_inputEndChangeAction);
    }

    private void EnableSpawn(float timeBetweenWaves)
    {
        _spawnView.EnableSpawn(timeBetweenWaves);
    }

    private bool CheckInputValue(string text)
    {
        if (float.TryParse(text, out var result) && result > 0)
            return true;
        else
            return false;
    }
}
