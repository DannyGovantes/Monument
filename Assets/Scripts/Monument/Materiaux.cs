using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materiaux : MonoBehaviour
{
    public string nom;

    [TextArea]
    public string descriptionPourDevis = "";

    [Header("Majoration pour difficult� propre au mat�riau(en coeficient):")]
    public float coefMajorationMat = 0;

    public float prixM3;
    public float poidsM3;
}
