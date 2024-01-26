using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; // For working with UI elements
using TMPro;

public class DropZone : MonoBehaviour, IDropHandler
{
    public SlotType expectedType;
    public GameObject inputFieldPrefab; // Assign an input field prefab in the Inspector
    public TMP_InputField currentInputField;
    private Vector3 inputFieldPosition;
    public RectTransform textContainer;


    public void OnDrop(PointerEventData eventData)
    {
        Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        //Debug.Log($"{expectedType} OnDrop1");
        if (draggable != null && draggable.cardType == expectedType)
        {
            // Assuming Draggable has a public property SlotType
            //Debug.Log($"{expectedType} OnDrop2");
            PlaceCardInSlot(draggable);
            ShowInputField();
        }
    }

    private void PlaceCardInSlot(Draggable card)
    {
        // Logic to place the card visually in the slot
        card.transform.SetParent(transform, false);
        card.transform.position = transform.position;
    }

    private void ShowInputField()
    {

        TMP_InputField inputFieldObj = Instantiate(inputFieldPrefab, transform.position, Quaternion.identity, transform).GetComponent<TMP_InputField>();
        inputFieldObj.transform.localPosition = Vector3.zero;

        currentInputField = inputFieldObj;

        Debug.Log(currentInputField != null ? "Input Field Component Found" : "Input Field Component Not Found");

        inputFieldPosition = inputFieldObj.transform.position;

    }

    [SerializeField] private GameObject textElementPrefab; // Assign this in the inspector

    public void ConvertInputToText(string inputText)
    {


        GameObject textElementObj = Instantiate(textElementPrefab, inputFieldPosition + new Vector3(0, -30f, 0), Quaternion.identity);
        textElementObj.transform.SetParent(textContainer, false);
        textElementObj.transform.localPosition = new Vector3(0, -30f, 0); // Adjust this offset as needed
        // Set the text and background color
        TMP_Text textComponent = textElementObj.GetComponentInChildren<TMP_Text>();
        if (textElementObj != null)
        {

            textComponent.text = inputText;
        }
        else
        {
            Debug.Log("text component null");
        }

        Debug.Log("Text object position: " + textElementObj.transform.position);


        Image bgImage = textElementObj.GetComponent<Image>();
        if (bgImage != null)
        {
            bgImage.color = GetComponent<Image>().color; // Get the color of the slot and set it as the background color of the text
        }

        RectTransform rectTransform = textElementObj.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.anchoredPosition = new Vector2(0, -30f); // Adjust this as needed
            rectTransform.sizeDelta = new Vector2(200, 50); // Set a default size
        }
        else
        {
            Debug.LogError("RectTransform not found on the text element object.");
        }

        //Debug.Log(currentInputField != null ? "CurrInput Field Component Found" : "Curr Input Field Component Not Found");
        // string inputText = currentInputField.text;
        // Color slotColor = GetComponent<Image>().color; // Get the color of the slot

        // // Instantiate the text element prefab
        // GameObject textElementObj = Instantiate(textElementPrefab, currentInputField.transform.position, Quaternion.identity, transform);
        // textElementObj.transform.localPosition = Vector3.zero; // Position it at the slot's center
        // Debug.Log("text Converted");

        // // Set the text and background color
        // TMP_Text textComponent = textElementObj.GetComponentInChildren<TMP_Text>();
        // if (textComponent != null)
        // {
        //     textComponent.text = inputText;
        // }

        // Image bgImage = textElementObj.GetComponent<Image>();
        // if (bgImage != null)
        // {
        //     bgImage.color = slotColor;
        // }

        // Destroy(currentInputField.gameObject); // Remove the input field

    }

    public void HandlePlayerInput(string sUserWord)
    {
        // dropZone = FindObjectOfType<DropZone>();
        Debug.Log($"User Word {sUserWord}");
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Debug.Log(currentInputField != null ? "CurrInput Field Component Found" : "Curr Input Field Component Not Found");

            ConvertInputToText(sUserWord);
        }
    }


}



// In this `DropZone.cs` script, you need to implement logic to verify if the dropped card's type matches the expected type for that drop zone. You can extend the `Card` class to include a card type enumeration and use it for this check.

// ### 5. Assigning Scripts and Testing

// - **Attach Scripts:** Attach the `Draggable.cs` script to your card prefab, and `DropZone.cs` to each of the input areas.
// - **Set Parameters:** In the Unity Editor, set the expected card type for each drop zone using the `ExpectedType` field (you'll need to expose this in your `DropZone` script).
// - **Test Drag-and-Drop:** Enter Play mode to test the drag-and-drop functionality. Make sure cards can be dragged and check if they correctly snap or respond when dropped into the input areas.

// ### 6. Additional Considerations

// - **Visual Feedback:** Providing visual feedback (like changing the color of the drop zone when a valid card is hovering over it) can greatly enhance the user experience.
// - **Resetting Card Position:** Decide if you want to reset the card's position if it's not dropped in a valid zone or if it should remain where it was dropped.
// - **Layering and Sorting:** Ensure that the dragged cards render above other UI elements while being dragged. This might involve changing the canvas sorting order or the card's sorting layer dynamically.

// By following these steps, you should be able to set up a basic drag-and-drop mechanism for your card game in Unity, allowing players to drag cards to specific input areas to form sentences.
