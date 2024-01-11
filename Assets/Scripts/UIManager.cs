using UnityEngine;
using UnityEngine.UI; // Required for UI classes
using TMPro; // Include this namespace for Text Mesh Pro

public class UIManager : MonoBehaviour
{
    public Image[] cardImages; // Array to hold references to the card UI Images
    public TMP_Text[] cardTexts; // Array to hold references to the card Texts

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
            Debug.Log($"{cardData.Type}");

            // Additional setup for the new card...
        }
    }

    Sprite GetCardSprite(Card card)
    {
        switch (card.Type)
        {
            case Card.CardType.Noun:
                return nounSprite;
            case Card.CardType.Verb:
                return verbSprite;
            case Card.CardType.Preposition:
                return prepositionSprite;
            default:
                return null; // Or a default sprite
        }
    }
}
