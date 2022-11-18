using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Must to call Initialize() first
/// </summary>
public class GaugeWithExcellentArea : Gauge
{
    private float excellentWidthRatio = 0.1f;
    private float excellentCenterRatio = 0.5f;

    [SerializeField] private GameObject excellentRectMask;

    /// <summary>
    /// this must be called
    /// </summary>
    /// <param name="showingRatio"></param>
    /// <param name="excellentWidthRatio"></param>
    /// <param name="excellentCenterRatio"></param>
    public void Initialize(float showingRatio,
        float excellentWidthRatio,
        float excellentCenterRatio)
    {
        base.Initialize(showingRatio);

        //edit excellent zone rect
        SetExcellentAreaRect(excellentWidthRatio, excellentCenterRatio);
    }

    private void SetExcellentAreaRect(float widthRatio, float centerRatio)
    {
        float centerPosX = GetHorizontalPosition(centerRatio);

        excellentRectMask.transform.localScale = new Vector2(widthRatio, excellentRectMask.transform.localScale.y);
        excellentRectMask.transform.position = new Vector2(centerPosX, excellentRectMask.transform.position.y);
    }
}
