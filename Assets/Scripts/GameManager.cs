using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int cardsInDeck;

    public GameObject prefab;
    public List<EntityStats> cards;

    public Color team1Color;
    public Color team2Color;

    void Start()
    {
        MakeDecks(team1Color, 4);
        MakeDecks(team2Color, -4);
    }

    public void MakeDecks(Color teamColor, int posX)
    {
        for (int i = 0; i < cardsInDeck; i++)
        {
            if (i == cards.Count)
            {
                Debug.Log("not enough cadrs!");
                break;
            }

            GameObject obj = Instantiate(prefab, new Vector3(-(cardsInDeck/2)+i, posX), Quaternion.identity);
            obj.GetComponent<SpriteRenderer>().sprite = cards[i].sprite;
            obj.GetComponent<PlayableCard>().card = cards[i];
            obj.GetComponent<PlayableCard>().teamColor = teamColor;
        }
    }
}