using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    //public CardType ExpectedType; // Enum for Noun, Verb, etc.

    public void OnDrop(PointerEventData eventData)
    {
        Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        // if (draggable != null && /* check card type matches ExpectedType */)
        // {
        //     eventData.pointerDrag.transform.SetParent(transform);
        //     // Additional logic for aligning the card in the drop zone
        // }
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
