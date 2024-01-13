using UnityEngine;
using UnityEngine.UI; // Required for UI classes

public class PlayerManager : MonoBehaviour
{
    public enum SlotType { Noun, Verb, Preposition, Adjective, Adverb }

    public GameObject nounSlotPrefab;
    public GameObject verbSlotPrefab;
    public GameObject prepositionSlotPrefab;

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
        foreach (var slotType in slotOrder)
        {
            GameObject slotPrefab = GetPrefabForSlotType(slotType);
            if (slotPrefab != null)
            {
                Instantiate(slotPrefab, playerArea);
            }
            else
            {
                Debug.LogError("Prefab not found for slot type: " + slotType);
            }
        }
    }

    private GameObject GetPrefabForSlotType(SlotType slotType)
    {
        switch (slotType)
        {
            case SlotType.Noun:
                return nounSlotPrefab;
            case SlotType.Verb:
                return verbSlotPrefab;
            case SlotType.Preposition:
                return prepositionSlotPrefab;
            // Add cases for other slot types as needed
            default:
                return null;
        }
    }
}
