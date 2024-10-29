using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldSpaceUI_Points : MonoBehaviour
{
    [SerializeField] Text pointsText;
    // Start is called before the first frame update
    public void SetPointsText(int points)
    {
        pointsText.text=points.ToString();
    }

    public void DestroyGameObject()
    {
        Destroy(this.gameObject);
    }
}
