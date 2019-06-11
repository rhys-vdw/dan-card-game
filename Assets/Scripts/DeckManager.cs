using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageEffect {
    NoEffect = 0,
    DoubleDamage = 1
}

public class Card {
    public int DamageModifier;
    public DamageEffect DamageEffect;

    public Card(int damageModifier, DamageEffect effect) {
        DamageModifier = damageModifier;
        DamageEffect = effect;
    }
}

public class DeckManager : MonoBehaviour
{
    const int PlayerCount = 2;
    public int DeckSize = 40;
    Card[][] _decks = new Card[][] {
        null,
        null,
    };
    int[] _drawnCardCount = new [] { 0, 0 };


    void Start()
    {
        _decks[0] = CreateDeck();
        _decks[1] = CreateDeck();
        ResetDeck(0);
        ResetDeck(1);
    }

    Card[] CreateDeck() {
        var result = new Card[DeckSize];
        for (int i = 0; i < DeckSize; i++) {
            var card = new Card(
                Random.Range(1, 6),
                (DamageEffect) Random.Range(0, 2)
            );
            result[i] = card;
        }
        return result;
    }

    public int CardsRemaining(int playerId) {
        return DeckSize - _drawnCardCount[playerId];
    }

    public Card GetNextCard(int playerId) {
        Card[] deck = _decks[playerId];
        var nextCardIndex = _drawnCardCount[playerId];
        _drawnCardCount[playerId]++;
        return deck[DeckSize - nextCardIndex - 1];
    }

    public void ResetDeck(int playerId) {
        _drawnCardCount[playerId] = 0;
        ArrayUtility.Shuffle(_decks[playerId]);
    }
}
