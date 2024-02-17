using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayableCard : MonoBehaviour
{
    public Color teamColor;
    public EntityStats card;
    public GameObject prefab;

    private int state = 0;

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => Click());
    }

    private void Update()
    {
        if (state == 1)
        {
            transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        }
        if (state == 2)
        {
            int scale = 30;
            int rowOffset = 0;
            for (int i = 0; i < card.count; i++)
            {
                Vector3 pos = new Vector3(transform.position.x + rowOffset, transform.position.y + i* scale - rowOffset * 2);
                Entity entity = Instantiate(prefab, pos, Quaternion.identity).GetComponent<Entity>();
                entity.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(pos).x, Camera.main.ScreenToWorldPoint(pos).y, 0);
                entity.stats = card;
                entity.teamColor = teamColor;
                if (card.count / 2 == i + 1) rowOffset += scale;
            }
            Destroy(gameObject);
        }
    }

    public void Click()
    {
        state++;
    }
}