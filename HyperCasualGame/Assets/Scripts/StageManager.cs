using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Newtonsoft.Json.Linq;

public class StageManager : MonoBehaviour
{
    [SerializeField] private GameObject LinePrefab;
    private LineRenderer LR;
    private EdgeCollider2D Collider2D;
    List<Vector2> points = new List<Vector2>();

    private TextMeshProUGUI TimeText;
    private GameObject Aim;
    private bool isDraw;
    private Color RedColor, NormalColor = new Color(1, 1, 1, 1);
    private float red = 255;
    private void Awake()
    {
        TimeText = GameObject.Find("TimeText").GetComponent<TextMeshProUGUI>();
        Aim = GameObject.Find("Aim");
        DOTween.To(() => red, x => red = x, 0f, 5f);
        StartCoroutine(StartTime());
    }

    private void Update()
    {
        RedColor = new Color(1, red / 255f, red / 255f, 1);
        TimeText.colorGradient = new VertexGradient(NormalColor, NormalColor, RedColor, RedColor);

        if(isDraw)
        {
            Vector2 pos = Aim.transform.position;

            points.Add(pos);
            LR.positionCount++;
            LR.SetPosition(LR.positionCount - 1, pos);
            Collider2D.points = points.ToArray();
        }
    }

    public void ClickOn()
    {
        isDraw = true;

        GameObject line = Instantiate(LinePrefab);
        LR = line.GetComponent<LineRenderer>();
        Collider2D = line.GetComponent<EdgeCollider2D>();
        points.Add(Aim.transform.position);
        LR.positionCount = 1;
        LR.SetPosition(0, points[0]);
    }

    public void ClickOff()
    {
        isDraw = false;

        points.Clear();
    }

    private IEnumerator StartTime()
    {
        for (int i = 5; i > 0; i--)
        {
            TimeText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        TimeText.text = "0";
    }
}
