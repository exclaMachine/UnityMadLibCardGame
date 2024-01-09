using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public enum CardType { Noun, Verb, Preposition }
    public CardType Type { get; private set; }
    public string Word1 { get; private set; }
    public string Word2 { get; private set; }
    public int Points { get; private set; }

    public Card(CardType type, string word1, string word2, int points)
    {
        Type = type;
        Word1 = word1;
        Word2 = word2;
        Points = points;
    }
}

public class Deck : MonoBehaviour
{
    private List<Card> cards = new List<Card>();

    void Awake()
    {
        CreateDeck();
        ShuffleDeck();
    }


    private void CreateDeck()
    {
        // Noun cards
        AddCard(Card.CardType.Noun, "condiment", "vegetable", 2);
        AddCard(Card.CardType.Noun, "color", "genre", 3);
        AddCard(Card.CardType.Noun, "location", "time", 4);
        AddCard(Card.CardType.Noun, "clothing outfit", "machine", 5);
        AddCard(Card.CardType.Noun, "friend", "emotion", 6);
        AddCard(Card.CardType.Noun, "furniture", "appliance", 7);
        AddCard(Card.CardType.Noun, "tool", "weapon", 8);
        AddCard(Card.CardType.Noun, "bug", "monster", 9);
        AddCard(Card.CardType.Noun, "hero", "family member", 10);

        // Verb cards
        AddCard(Card.CardType.Verb, "mundane/boring action", "", 2);
        AddCard(Card.CardType.Verb, "loud action", "", 3);
        AddCard(Card.CardType.Verb, "silent action", "", 4);
        AddCard(Card.CardType.Verb, "physical action", "", 5);
        AddCard(Card.CardType.Verb, "communication action", "", 6);
        AddCard(Card.CardType.Verb, "creating action", "", 7);
        AddCard(Card.CardType.Verb, "attack action", "", 8);
        AddCard(Card.CardType.Verb, "compassion action", "", 9);
        AddCard(Card.CardType.Verb, "dance move", "", 10); // +5 points if you do the dance

        // Preposition cards
        AddCard(Card.CardType.Preposition, "over", "through", 2);
        AddCard(Card.CardType.Preposition, "before", "after", 3);
        AddCard(Card.CardType.Preposition, "among", "at", 4);
        AddCard(Card.CardType.Preposition, "in", "outside", 5);
        AddCard(Card.CardType.Preposition, "with", "without", 6);
        AddCard(Card.CardType.Preposition, "above", "below", 7);
        AddCard(Card.CardType.Preposition, "by", "around", 8);
        AddCard(Card.CardType.Preposition, "on", "off", 9);
        AddCard(Card.CardType.Preposition, "to", "behind", 10);
    }

    private void AddCard(Card.CardType type, string word1, string word2, int points)
    {
        cards.Add(new Card(type, word1, word2, points));
    }

    private void ShuffleDeck()
    {
        System.Random random = new System.Random();
        for (int i = 0; i < cards.Count; i++)
        {
            int randomIndex = random.Next(i, cards.Count);
            Card temp = cards[i];
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }
    }

    public Card DrawCard()
    {
        if (cards.Count > 0)
        {
            Card drawnCard = cards[0];
            Debug.Log(drawnCard.Word1);
            cards.RemoveAt(0);
            return drawnCard;
        }
        else
        {
            // Handle empty deck scenario here
            Debug.LogWarning("Deck is empty!");
            return null;
        }
    }

}
