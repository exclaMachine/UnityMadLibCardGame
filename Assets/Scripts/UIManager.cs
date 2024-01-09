using UnityEngine;
using UnityEngine.UI; // Required for UI classes
using TMPro; // Include this namespace for Text Mesh Pro

public class UIManager : MonoBehaviour
{
    public Image[] cardImages; // Array to hold references to the card UI Images
    public TMP_Text[] cardTexts; // Array to hold references to the card Texts

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
        // Draw 5 cards from the deck and display them
        for (int i = 0; i < 5; i++)
        {
            Card card = deck.DrawCard(); // Implement this method in Deck
            cardImages[i].sprite = GetCardSprite(card); // Implement GetCardSprite based on card type
            cardTexts[i].text = $"{card.Type}: {card.Word1} {card.Word2}";
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
