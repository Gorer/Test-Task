using TMPro;

public class CubeController
{
    private CubeView _cubeView;
    private CubeModel _cubeModel;

    private TMP_InputField _speedInputField;
    private TMP_InputField _distanceInputField;

    public CubeController(CubeView cubeView, CubeModel cubeModel, TMP_InputField speedInputField, TMP_InputField distanceInputField)
    {
        _cubeView = cubeView;
        _cubeModel = cubeModel;

        _speedInputField = speedInputField;
        _distanceInputField = distanceInputField;

        Enable();
    }

    public void Enable()
    {
        _speedInputField.onEndEdit.AddListener(delegate { InputSpeedEndChange(_speedInputField.text); });
        _distanceInputField.onEndEdit.AddListener(delegate { InputDistanceEndChange(_distanceInputField.text); });

        _cubeModel.ChangedSpeed += SpecifyMoveSpeed;
        _cubeModel.ChangedDistance += SpecifyDestination;
    }

    private void InputSpeedEndChange(string speedInput)
    {
        if (float.TryParse(speedInput, out var result) && result > 0)
        {
            _cubeModel.SetNewSpeed(result);
        }
    }

    private void InputDistanceEndChange(string distanceInput)
    {
        if (float.TryParse(distanceInput, out var result) && result > 0)
        {
            _cubeModel.SetNewDistance(result);
        }
    }

    public void SpecifyDestination(float distance)
    {
        _cubeView.SpecifyDestination(distance);
    }

    public void SpecifyMoveSpeed(float moveSpeed)
    {
        _cubeView.SpecifyMoveSpeed(moveSpeed);
    }
}
