using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinewave : MonoBehaviour
{
    public BreathListener myBreath;
    public LineRenderer myLine;
    public int points;
    public float amplitude = 1f;
    public float speed = 1f;
    public float frequency = 1f;
    public Vector2 xLimits = new Vector2(0, 1);
    private List<Vector2> prevValues = new List<Vector2>();
    public bool hold;

    void Start()
    {
        myLine = GetComponent<LineRenderer>();
        speed = 0f;
        prevValues.Clear();
    }

    void DrawSine()
    {
        myLine.positionCount = points;
        for (int currentPoint = 0; currentPoint < points; currentPoint++)
        {
            float progress = (float)currentPoint / (points - 1);
            float x = Mathf.Lerp(xLimits.x, xLimits.y, progress);
            float y = Mathf.Sin(x + (Time.timeSinceLevelLoad * speed));
            Vector2 previousPos = new Vector2(x, y);
            
            if (hold)
            {
                //myLine.SetPosition(currentPoint, new Vector3(prevValues[currentPoint].x, prevValues[currentPoint].y, 0));
            }
            else
            {
                prevValues.Add(previousPos);
                if (prevValues.Count > currentPoint)
                    prevValues.RemoveAt(0);

                myLine.SetPosition(currentPoint, new Vector3(x, y, 0));
            }
        }
    }

    void Update()
    {
        DrawSine();
    }
}
