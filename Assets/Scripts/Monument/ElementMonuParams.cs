using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementMonuParams : MonoBehaviour
{
	// VALEURS RECUPEREES DANS LES ELEMENTS EN BIBLIOTHEQUES
	public BiblioType Type;

	public string description = "";

	public float HeuresFacon = 0;

	public float LongueurMin;
	public float LargeurMin;
	public float HauteurMin;

	public float LongueurMax;
	public float LargeurMax;
	public float HauteurMax;

	//VALEURS PROPRES AUX ELEMENTS CONSTITUANT LE MONUMENT
	//Dimensions
    public float Longueur;
	public float Largeur;
	public float Hauteur;

	//Position
	public Vector3 position;

	//Nr d'ordre de montage
	public int Niveau;

	//Poids
	public float Poids;

	//prix 
	public float PrixTransport;
	public float PrixMatiere;
	public float PrixFacon;
	public float PrixFournisseur;
	public float PrixClient;
}
