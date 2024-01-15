using UnityEngine;
using UnityEngine.UI; // Required for UI classes
using TMPro;

public enum SlotType { Noun, Verb, Preposition, Adjective, Adverb }
public class PlayerManager : MonoBehaviour
{

    public GameObject slotPrefab;

    public Transform[] playerAreas; // Assign in the Inspector, each area corresponds to a player

    void Start()
    {
        SetupPlayer(0, new SlotType[] { SlotType.Noun, SlotType.Verb, SlotType.Preposition, SlotType.Noun });
    }

    public void SetupPlayer(int playerIndex, SlotType[] slotOrder)
    {
        if (playerIndex < 0 || playerIndex >= playerAreas.Length)
        {
            Debug.LogError("Invalid player index");
            return;
        }

        Transform playerArea = playerAreas[playerIndex];
        Vector3 nextSlotPosition = playerArea.position; // Starting position

        foreach (var slotType in slotOrder)
        {
            GameObject slotObject = Instantiate(slotPrefab, nextSlotPosition, Quaternion.identity, playerArea);
            ConfigureSlot(slotObject, slotType);
            nextSlotPosition.x += slotObject.GetComponent<RectTransform>().rect.width; // Adjust for spacing

            DropZone dropZone = slotObject.GetComponent<DropZone>();
            if (dropZone != null)
            {
                dropZone.expectedType = slotType; // Set the expected type for the slot
            }
        }
    }

    private void ConfigureSlot(GameObject slotObject, SlotType slotType)
    {
        // Set the text based on the slot type
        TMP_Text textComponent = slotObject.GetComponentInChildren<TMP_Text>();
        textComponent.text = slotType.ToString();

        // Set the background color based on the slot type
        Image backgroundImage = slotObject.GetComponent<Image>();
        switch (slotType)
        {
            case SlotType.Noun:
                backgroundImage.color = Color.blue;
                break;
            case SlotType.Verb:
                backgroundImage.color = Color.yellow;
                break;
            case SlotType.Preposition:
                backgroundImage.color = new Color(250 / 255f, 128 / 255f, 114 / 255f); // Salmon color
                break;
                // Add other cases as needed
        }
    }
}
