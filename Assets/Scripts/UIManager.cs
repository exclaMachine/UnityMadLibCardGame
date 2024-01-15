using UnityEngine;
using UnityEngine.UI; // Required for UI classes
using TMPro; // Include this namespace for Text Mesh Pro

public class UIManager : MonoBehaviour
{

    public GameObject cardPrefab; // Assign your card prefab in the Inspector
    public Transform cardParent; // Assign a parent transform to organize instantiated cards in the UI

    private Deck deck; // Reference to the Deck script

    public Sprite nounSprite; // Assign a gray sprite in the Inspector
    public Sprite verbSprite; // Assign a yellow sprite in the Inspector
    public Sprite prepositionSprite; // Assign a pink sprite in the Inspector

    void Start()
    {
        deck = FindObjectOfType<Deck>(); // Find the Deck script in the scene
        Debug.Log(deck == null ? "Deck not found" : "Deck found");
        DisplayCards();
    }

    void DisplayCards()
    {

        for (int i = 0; i < 5; i++)
        {
            // Instantiate a new card GameObject
            GameObject newCard = Instantiate(cardPrefab, cardParent);

            // Position the card, set the image and text, etc.
            Card cardData = deck.DrawCard();
            newCard.GetComponent<Image>().sprite = GetCardSprite(cardData);
            newCard.GetComponentInChildren<TMP_Text>().text = $"{cardData.Type}: {cardData.Word1} {cardData.Word2}";
            // Debug.Log($"{cardData.Type}");

            Draggable draggableComponent = newCard.GetComponent<Draggable>();
            if (draggableComponent != null)
            {
                draggableComponent.cardType = cardData.Type;
            }
        }

    }

    Sprite GetCardSprite(Card card)
    {
        switch (card.Type)
        {
            case SlotType.Noun:
                return nounSprite;
            case SlotType.Verb:
                return verbSprite;
            case SlotType.Preposition:
                return prepositionSprite;
            default:
                return null; // Or a default sprite
        }
    }
}
