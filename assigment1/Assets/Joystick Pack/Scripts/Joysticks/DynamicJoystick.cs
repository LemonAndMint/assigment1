using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DynamicJoystick : Joystick
{
    public float MoveThreshold { get { return moveThreshold; } set { moveThreshold = Mathf.Abs(value); } }
    [SerializeField] private float moveThreshold = 1;
    //#EDITED BY LEMONANDMINT PLEASE GET THE OFFICIAL VERSION FROM: https://assetstore.unity.com/packages/tools/input-management/joystick-pack-107631#description
    public GameObject backg;
    //#EDITED BY LEMONANDMINT PLEASE GET THE OFFICIAL VERSION FROM: https://assetstore.unity.com/packages/tools/input-management/joystick-pack-107631#description
    protected override void Start()
    {
      //#EDITED BY LEMONANDMINT PLEASE GET THE OFFICIAL VERSION FROM: https://assetstore.unity.com/packages/tools/input-management/joystick-pack-107631#description
      backg = background.gameObject;
      //#EDITED BY LEMONANDMINT PLEASE GET THE OFFICIAL VERSION FROM: https://assetstore.unity.com/packages/tools/input-management/joystick-pack-107631#description
        MoveThreshold = moveThreshold;
        base.Start();
        background.gameObject.SetActive(false);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        background.gameObject.SetActive(true);
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        background.gameObject.SetActive(false);
        base.OnPointerUp(eventData);
    }

    protected override void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
    {
        if (magnitude > moveThreshold)
        {
            Vector2 difference = normalised * (magnitude - moveThreshold) * radius;
            background.anchoredPosition += difference;
        }
        base.HandleInput(magnitude, normalised, radius, cam);
    }
}