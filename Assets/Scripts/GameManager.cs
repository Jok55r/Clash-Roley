using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int cardsInDeck;

    public Canvas canvas;
    public GameObject uiPrefab;
    public GameObject cardPrefab;
    public List<EntityStats> cards;

    public Color team1Color;
    public Color team2Color;

    void Start()
    {
        MakeDecks(team1Color, 540);
        MakeDecks(team2Color, 40);
    }

    public void MakeDecks(Color teamColor, int posY)
    {
        for (int i = 0; i < cardsInDeck; i++)
        {
            Button obj = Instantiate(uiPrefab, canvas.transform).GetComponent<Button>();
            obj.transform.position = new Vector2(350f + 60 * i, posY);
            obj.transform.localScale = new Vector2(0.5f, 0.5f);

            obj.GetComponent<Image>().sprite = cards[i].sprite;
            obj.GetComponent<PlayableCard>().card = cards[i];
            obj.GetComponent<PlayableCard>().teamColor = teamColor;
            obj.GetComponent<PlayableCard>().prefab = cardPrefab;
        }
    }
}