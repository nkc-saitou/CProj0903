using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseUI : MonoBehaviour
{
    public Image clickLeft;
    public Image clickRight;

	void Update ()
    {
        clickLeft.enabled  = Input.GetMouseButton(0);
        clickRight.enabled = Input.GetMouseButton(1);
	}
}
