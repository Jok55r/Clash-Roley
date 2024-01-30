using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject prefab;
    public EntityStats card;

    public Color team1Color;
    public Color team2Color;

    void Start()
    {
        MakeDecks(team1Color, 4);
        MakeDecks(team2Color, -4);
    }

    public void MakeDecks(Color teamColor, int posX)
    {
        GameObject obj = Instantiate(prefab, new Vector3(0, posX), Quaternion.identity);
        obj.GetComponent<SpriteRenderer>().sprite = card.sprite;
        obj.GetComponent<PlayableCard>().card = card;
        obj.GetComponent<PlayableCard>().teamColor = teamColor;
    }
}