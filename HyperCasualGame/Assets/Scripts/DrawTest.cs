using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DrawTest : MonoBehaviour
{
    [SerializeField] private GameObject LinePrefab;

    private LineRenderer LR;
    private EdgeCollider2D Collider2D;
    List<Vector2> points = new List<Vector2>();

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject line = Instantiate(LinePrefab);
            LR = line.GetComponent<LineRenderer>();
            Collider2D = line.GetComponent<EdgeCollider2D>();
            points.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            LR.positionCount = 1;
            LR.SetPosition(0, points[0]);
        }
        else if(Input.GetMouseButton(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            points.Add(pos);
            LR.positionCount++;
            LR.SetPosition(LR.positionCount - 1, pos);
            Collider2D.points = points.ToArray();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            points.Clear();
        }

    }
}
