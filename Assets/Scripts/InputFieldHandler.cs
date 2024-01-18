using UnityEngine;
using UnityEngine.UI; // Required for UI components

public class InputFieldHandler : MonoBehaviour
{
    private InputField inputField;


    public void HandlePlayerInput(string sUserWord)
    {
        Debug.Log($"User Word {sUserWord}");
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            // Convert input field to text
            //ConvertInputToText(inputField);
        }
    }
}
