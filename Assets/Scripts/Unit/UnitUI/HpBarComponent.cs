using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HpBarComponent : MonoBehaviour
{
    [SerializeField] GameObject background;
    [SerializeField] GameObject fill;

    PRS originPos;
    Vector3 barStartPoint;

    private float max = 1.0f;
    private float current = 1.0f;

    public float Max //Slider Value MAX
    {
        set {
            if (value > 0) max = value;
            else Debug.LogWarning("Max is zero");
        }
        get { return max; }
    }

    public float Value //Slider Value
    {
        set {
            if (value > 0) current = value;
            else current = 0;
        }
        get { return current; }
    }

    private void Awake()
    {
        if (background == null || fill == null) {
            Debug.LogError("Background or fill GameObject is not assigned in HpBarComponent.");
            return;
        }
        //HP Bar Setting
        Renderer renderer = fill.GetComponent<Renderer>();
        originPos = new PRS(fill.transform.position, fill.transform.rotation, fill.transform.localScale);
        barStartPoint = renderer.bounds.min;
    }

    /// <summary>
    /// HP bar를업데이트 합니다.
    /// </summary>
    /// <param name="current">현제 HP</param>
    public void UpdateStatus(float current)
    {
        Value = current;
        DisplayStatus();
    }


    /// <summary>
    /// HP bar를 업데이트합니다.
    /// </summary>
    /// <param name="max">최대 HP</param>
    /// <param name="current">현제 HP</param>
    public void UpdateStatus(float max, float current)
    {
        Value = current;
        Max = max;
        DisplayStatus();
    }

    /// <summary>
    /// HP bar를 디스플레이합니다.
    /// </summary>
    public void DisplayStatus()
    {
        if (max == 0) {
            Debug.LogWarning("Max is zero. Cannot display bar.");
            return;
        }

        PRS currentHpBarState = new PRS(originPos.position, originPos.rotation, originPos.scale);
        Renderer renderer = fill.GetComponent<Renderer>();
        float precent = current / max;

        currentHpBarState.position.x = barStartPoint.x + (fill.transform.position.x - renderer.bounds.min.x) * precent;
        currentHpBarState.scale.x *= precent;

        fill.transform.position = currentHpBarState.position;
        fill.transform.localScale = currentHpBarState.scale;

    }
}
