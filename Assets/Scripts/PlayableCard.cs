using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayableCard : MonoBehaviour
{
    public Color teamColor;
    public EntityStats card;
    public GameObject prefab;

    private bool drag = false;

    private void Update()
    {
        if (drag)
        {
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;
            transform.position = mouseWorldPos;
        }
    }

    public void OnMouseUp()
    {
        for (int i = 0; i < card.count; i++)
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y + i);
            Entity entity = Instantiate(prefab, pos, Quaternion.identity).GetComponent<Entity>();
            entity.stats = card;
            entity.teamColor = teamColor;
        }
        Destroy(gameObject);
    }

    public void OnMouseDown()
        => drag = true;
}