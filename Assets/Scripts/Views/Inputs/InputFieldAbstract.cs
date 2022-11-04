using TMPro;
using UnityEngine;

public abstract class InputFieldAbstract : MonoBehaviour
{
    [SerializeField] TMP_InputField _inputField;

    void OnEnable()
    {
        //Register InputField Events
        RegisterEvent(_inputField);
    }

    private void inputEndEdit()
    {
        Debug.Log("Input Submitted");
    }

    void OnDisable()
    {
        UndoRegisterEvent(_inputField);
    }

    #region Reusable Methods

    private void RegisterEvent(TMP_InputField inputField)
    {
        inputField.onEndEdit.AddListener(delegate { inputEndEdit(); });
    }

    private void UndoRegisterEvent(TMP_InputField inputField)
    {
        inputField.onEndEdit.RemoveAllListeners();
    }

    #endregion Reusable Methods
}
