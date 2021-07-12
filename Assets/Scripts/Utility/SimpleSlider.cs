using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleSlider : MonoBehaviour
{

    public Slider _sizeSlider;
    public ElementBiblioParams _elementBiblioParamsSelected;

    public void Start(){
        SelectElementBiblioParams(_elementBiblioParamsSelected);
    }

    public void SelectElementBiblioParams(ElementBiblioParams elementBiblio)
    {
        _elementBiblioParamsSelected = elementBiblio;
        //Tenemos que cambiar los parámetros del slider
        ChangeMinMaxSliderValues(_elementBiblioParamsSelected.LongueurMin, _elementBiblioParamsSelected.LongueurMax);
    }

    private void ChangeMinMaxSliderValues(float min, float max)
    {
        _sizeSlider.maxValue = max;
        _sizeSlider.minValue = min;
        


    }

}
