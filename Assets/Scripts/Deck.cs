using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public SlotType Type { get; private set; }
    public string Word1 { get; private set; }
    public string Word2 { get; private set; }
    public int Points { get; private set; }

    public Card(SlotType type, string word1, string word2, int points)
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
        AddCard(SlotType.Noun, "condiment", "vegetable", 2);
        AddCard(SlotType.Noun, "color", "genre", 3);
        AddCard(SlotType.Noun, "location", "time", 4);
        AddCard(SlotType.Noun, "clothing outfit", "machine", 5);
        AddCard(SlotType.Noun, "friend", "emotion", 6);
        AddCard(SlotType.Noun, "furniture", "appliance", 7);
        AddCard(SlotType.Noun, "tool", "weapon", 8);
        AddCard(SlotType.Noun, "bug", "monster", 9);
        AddCard(SlotType.Noun, "hero", "family member", 10);

        // Verb cards
        AddCard(SlotType.Verb, "mundane/boring action", "", 2);
        AddCard(SlotType.Verb, "loud action", "", 3);
        AddCard(SlotType.Verb, "silent action", "", 4);
        AddCard(SlotType.Verb, "physical action", "", 5);
        AddCard(SlotType.Verb, "communication action", "", 6);
        AddCard(SlotType.Verb, "creating action", "", 7);
        AddCard(SlotType.Verb, "attack action", "", 8);
        AddCard(SlotType.Verb, "compassion action", "", 9);
        AddCard(SlotType.Verb, "dance move", "", 10); // +5 points if you do the dance

        // Preposition cards
        AddCard(SlotType.Preposition, "over", "through", 2);
        AddCard(SlotType.Preposition, "before", "after", 3);
        AddCard(SlotType.Preposition, "among", "at", 4);
        AddCard(SlotType.Preposition, "in", "outside", 5);
        AddCard(SlotType.Preposition, "with", "without", 6);
        AddCard(SlotType.Preposition, "above", "below", 7);
        AddCard(SlotType.Preposition, "by", "around", 8);
        AddCard(SlotType.Preposition, "on", "off", 9);
        AddCard(SlotType.Preposition, "to", "behind", 10);
    }

    private void AddCard(SlotType type, string word1, string word2, int points)
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
            //Debug.Log(drawnCard.Word1);
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
