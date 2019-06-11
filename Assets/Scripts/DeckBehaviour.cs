using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckBehaviour : MonoBehaviour
{
    public Color BackColor = Color.blue;
    public Color FaceColor = Color.white;
    public TextMesh DamageEffectText;
    public TextMesh DamageModifierText;
    public Renderer DeckRenderer;

    public int PlayerId;
    public DeckManager DeckManager;

    void Awake() {
        HideCard();
    }

    void HideCard() {
        DeckRenderer.material.color = BackColor;
        DamageEffectText.gameObject.SetActive(false);
        DamageModifierText.gameObject.SetActive(false);
    }

    void ShowCard(Card card) {
        DeckRenderer.material.color = FaceColor;
        DamageEffectText.gameObject.SetActive(true);
        DamageModifierText.gameObject.SetActive(true);
        DamageEffectText.text = card.DamageEffect.ToString();
        DamageModifierText.text = card.DamageModifier.ToString();
    }

    void OnMouseDown() {
        if (DeckManager.CardsRemaining(PlayerId) == 0) {
            DeckManager.ResetDeck(PlayerId);
            HideCard();
        } else {
            var card = DeckManager.GetNextCard(PlayerId);
            ShowCard(card);
        }
    }
}

