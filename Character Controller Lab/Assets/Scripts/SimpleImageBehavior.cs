using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SimpleImageBehavior : MonoBehaviour
{
    public SimpleFloatData dataObj;
    private Image _imageObj;
    
    private void Start()
    {
        _imageObj = GetComponent<Image>();
    }

    public void UpdateWithFloatData()
    {
        _imageObj.fillAmount = dataObj.value;
    }
}
