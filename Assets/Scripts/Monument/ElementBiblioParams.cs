using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementBiblioParams : MonoBehaviour
{
    [Header("Types(rehausse,semelles,etc):")]
    public BiblioType type;

    [TextArea]
	public string description = "";

    [Header("Heures de faconnage special(en plus-value):")]
	public float HeuresFacon = 0;

	[Header("Limites mini de changements dimensionnels: ")]
	public float LongueurMin;
	public float LargeurMin;
	public float HauteurMin;
	[Header("Limites maxi de changements dimensionnels: ")]
	public float LongueurMax;
	public float LargeurMax;
	public float HauteurMax;

    [Header("Gráficos:")]
    public MeshFilter mesh;
    public Material material;


	private void Start()
	{
		if(!TryGetComponent(out mesh))
		{
            Debug.LogWarning("ERROR: NO EXISTE MESH");
        }
        material = GetComponent<Renderer>().material;
		if(!material)
		{
 			Debug.LogWarning("ERROR: NO EXISTE MATERIAL");
		}

    }

}
