using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//cambiar los datos del monumento
public class MonumentManager : MonoBehaviour
{

    public GameObject objectHit;
    public float direction = 0;

    [Header("Panels selection biblios:")]
    public GameObject panel_semelles;
    public GameObject panel_socles;
    public GameObject panel_steles;

    [Header("REHAUSSES")]
    public List<ElementBiblioParams> biblioElementsRehausses = new List<ElementBiblioParams>();

    [Header("SEMELLES")]
    public List<ElementBiblioParams> biblioElementsSemelles = new List<ElementBiblioParams>();

    [Header("SEMELLES disymetriques")]
    public List<ElementBiblioParams> biblioElementsSemellesDisymetriques = new List<ElementBiblioParams>();

    [Header("BANDEAUX")]
    public List<ElementBiblioParams> biblioElementsBandeaux = new List<ElementBiblioParams>();

    [Header("TOMBALES")]
    public List<ElementBiblioParams> biblioElementsTombales = new List<ElementBiblioParams>();

    [Header("SOCLES")]
    public List<ElementBiblioParams> biblioElementsSocles = new List<ElementBiblioParams>();

    [Header("SOCLES Larges")]
    public List<ElementBiblioParams> biblioElementsSoclesLarges = new List<ElementBiblioParams>();

    [Header("STELES")]
    public List<ElementBiblioParams> biblioElementsSteles = new List<ElementBiblioParams>();

    [Header("STELES Composees")]
    public List<ElementBiblioParams> biblioElementsStelesComposees = new List<ElementBiblioParams>();

    [Header("STELES Rustiques")]
    public List<ElementBiblioParams> biblioElementsStelesRustiques = new List<ElementBiblioParams>();

    private MonumentController _monumentController;

    private GameObject _biblio;
    private GameObject _biblioREHAUSSES_2places_standard;
    private GameObject _biblioSEMELLES_2places_standard;
    private GameObject _biblioSEMELLES_disymetriques;
    private GameObject _biblioBANDEAUX_standard;
    private GameObject _biblioTOMBALES_standard;
    private GameObject _biblioSocles;
    private GameObject _biblioSocles_larges;
    private GameObject _biblioSteles_composees;
    private GameObject _biblioSteles_rustiques;
    private GameObject _biblioSteles;

    private int counter = 0;
    public int Counter 
    {
        get => counter;
        set => counter = value;

    }


    private void Start()
    {

     biblioElementsRehausses = GetElementBiblioParamsList(BiblioType.Rehausses);
        biblioElementsSemelles = GetElementBiblioParamsList(BiblioType.Semelles);
        biblioElementsSemellesDisymetriques = GetElementBiblioParamsList(BiblioType.Semelles_disymetriques);
        biblioElementsBandeaux = GetElementBiblioParamsList(BiblioType.Bandeaux);
        biblioElementsTombales = GetElementBiblioParamsList(BiblioType.Tombales);
        biblioElementsSocles = GetElementBiblioParamsList(BiblioType.Socles);
        biblioElementsSoclesLarges = GetElementBiblioParamsList(BiblioType.Socles_larges);
        biblioElementsSteles = GetElementBiblioParamsList(BiblioType.Steles);
        biblioElementsStelesComposees = GetElementBiblioParamsList(BiblioType.Steles_composees);
        biblioElementsStelesRustiques = GetElementBiblioParamsList(BiblioType.Steles_rustiques);

        _monumentController =  FindObjectOfType<MonumentController>();

        _biblio = GameObject.Find("BIBLIO_ELEMENTS");

        _biblioREHAUSSES_2places_standard = GameObject.Find("REHAUSSES_2places_standard");
        _biblioSEMELLES_2places_standard = GameObject.Find("Semelles_2places_standard");
        _biblioSEMELLES_disymetriques = GameObject.Find("Semelles_disymetriques");
        _biblioBANDEAUX_standard = GameObject.Find("BANDEAUX_standard");
        _biblioTOMBALES_standard = GameObject.Find("TOMBALES_standard");
        _biblioSocles = GameObject.Find("Socles");
        _biblioSocles_larges = GameObject.Find("Socles_larges");
        _biblioSteles = GameObject.Find("Steles");
        _biblioSteles_composees = GameObject.Find("Steles_composees");
        _biblioSteles_rustiques = GameObject.Find("Steles_rustiques");


        panel_semelles.SetActive(false);
        panel_socles.SetActive(false);
        panel_steles.SetActive(false);

    }


    private List<ElementBiblioParams> GetElementBiblioParamsList(BiblioType type)
    {
        List<ElementBiblioParams> ListN = new List<ElementBiblioParams>();
        var arrayObjects =  FindObjectsOfType<ElementBiblioParams>();

        foreach(ElementBiblioParams bibloObject in arrayObjects)
        {
            if(type == bibloObject.type)
            {
                ListN.Add(bibloObject);
            }
            
        }

        return ListN;

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            OnChangeMesh(-1);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            OnChangeMesh(1);
        }
        
        
    }

    public void ActiveCompatiblesBiblioElements(string nameType)
    {
        //Deactivate biblios
        //_biblio.SetActive(false);
        

     _biblioREHAUSSES_2places_standard.SetActive(false);
     _biblioSEMELLES_2places_standard.SetActive(false);
     _biblioSEMELLES_disymetriques.SetActive(false);
     _biblioBANDEAUX_standard.SetActive(false);
     _biblioTOMBALES_standard.SetActive(false);
     _biblioSocles.SetActive(false);
     _biblioSocles_larges.SetActive(false);
     _biblioSteles_composees.SetActive(false);
     _biblioSteles_rustiques.SetActive(false);
     _biblioSteles.SetActive(false);

        panel_semelles.SetActive(false);
        panel_socles.SetActive(false);
        panel_steles.SetActive(false);

        switch (nameType)
        {

            case "REHAUSSE":
                {
                    _biblioREHAUSSES_2places_standard.SetActive(true);
                    break;
                }
            case "SEMELLES":
                {
                    panel_semelles.SetActive(true);
                    _biblioSEMELLES_2places_standard.SetActive(true);
                    break;
                }

            case "SemellesDisymetriques":
                {
                    panel_semelles.SetActive(true);
                    _biblioSEMELLES_2places_standard.SetActive(true);
                    break;
                }
            case "BANDEAU":
                {
                    _biblioBANDEAUX_standard.SetActive(true);
                    break;
                }
            case "TOMBALE":
                {
                    _biblioTOMBALES_standard.SetActive(true);
                    break;
                }
            case "SOCLE":
                {
                    panel_socles.SetActive(true);
                    _biblioSocles.SetActive(true);
                    break;
                }
            case "SoclesLarges":
                {
                    panel_socles.SetActive(true);
                    _biblioSocles_larges.SetActive(true);
                    break;
                }
            case "STELE":
                {
                    panel_steles.SetActive(true);
                    _biblioSteles.SetActive(true);
                    break;
                }
            case "StelesComposees":
                {
                    panel_steles.SetActive(true);
                    _biblioSteles_composees.SetActive(true);
                    break;
                }
            case "StelesRustiques":
                {
                    panel_steles.SetActive(true);
                    _biblioSteles_rustiques.SetActive(true);
                    break;
                }


        }
    }

    public void ManageToggle_Semelles()
    {    ActiveCompatiblesBiblioElements("SEMELLES");   }
    public void ManageToggle_SemellesDisymetriques()
    {     ActiveCompatiblesBiblioElements("SemellesDisymetriques");   }
    public void ManageToggle_Socles()
    {     ActiveCompatiblesBiblioElements("SOCLE");   }
    public void ManageToggle_SoclesLarges()
    {     ActiveCompatiblesBiblioElements("SoclesLarges");   }
    public void ManageToggle_Steles()
    { ActiveCompatiblesBiblioElements("STELE"); }
    public void ManageToggle_stelesComposees()
    { ActiveCompatiblesBiblioElements("StelesComposees"); }
    public void ManageToggle_StelesRustiques()
    { ActiveCompatiblesBiblioElements("StelesRustiques"); }

    public void OnChangeNextMaterial()
    {

        if(_monumentController && _monumentController.activeElement)
        {
            //TODO: Cambiar el material desde otra lsita de materiales
            _monumentController.ChangeMaterial(_monumentController.activeElement, biblioElementsRehausses[counter].material);
            counter++;
        }
        DevisElementProcess(objectHit);
        DevisMonumentProcess(objectHit);
        

    }


    public void Manage3dMenuClickHit(GameObject gameObject)
    {
        _monumentController.activeElement.GetComponent<MeshFilter>().mesh = objectHit.GetComponent<MeshFilter>().mesh;

        _monumentController.activeElement.GetComponent<ElementMonuParams>().description = objectHit.GetComponent<ElementBiblioParams>().description;
        _monumentController.activeElement.GetComponent<ElementMonuParams>().HeuresFacon = objectHit.GetComponent<ElementBiblioParams>().HeuresFacon;
        _monumentController.activeElement.GetComponent<ElementMonuParams>().LongueurMin = objectHit.GetComponent<ElementBiblioParams>().LongueurMin;
        _monumentController.activeElement.GetComponent<ElementMonuParams>().LargeurMin = objectHit.GetComponent<ElementBiblioParams>().LargeurMin;
        _monumentController.activeElement.GetComponent<ElementMonuParams>().HauteurMin = objectHit.GetComponent<ElementBiblioParams>().HauteurMin;
        _monumentController.activeElement.GetComponent<ElementMonuParams>().LongueurMax = objectHit.GetComponent<ElementBiblioParams>().LongueurMax;
        _monumentController.activeElement.GetComponent<ElementMonuParams>().LargeurMax = objectHit.GetComponent<ElementBiblioParams>().LargeurMax;
        _monumentController.activeElement.GetComponent<ElementMonuParams>().HauteurMax = objectHit.GetComponent<ElementBiblioParams>().HauteurMax;

        DevisElementProcess(objectHit);
        DevisMonumentProcess(objectHit);
    }

    private void OnChangeElement()
    {

    }
    private void DevisMonumentProcess(GameObject element)
    {

    }
     private void DevisElementProcess(GameObject element)
    {

    }

    private void OnChangeMesh(int direction)
    {
        counter += direction;
        
        if(_monumentController && _monumentController.activeElement)
        {

            var evaluateList = GetSelectedList(_monumentController.activeElement.GetComponent<ElementMonuParams>().Type);
            counter = Mathf.Clamp(counter, 0, evaluateList.Count - 1);
            //Checar qué type es, para así cambiar la lista
            _monumentController.ChangeMesh(_monumentController.activeElement, evaluateList[counter].mesh);
            if (counter > evaluateList.Count - 1) counter = 0;
             


        }

    }

    private List<ElementBiblioParams> GetSelectedList(BiblioType type)
    {
        switch (type)
        {
            case BiblioType.Rehausses:
                 {
                    return biblioElementsRehausses;
                    break;
                 }
            case BiblioType.Semelles:
                 {
                    return biblioElementsSemelles;
                    break;
                 }
            case BiblioType.Semelles_disymetriques:
                {
                    return biblioElementsSemellesDisymetriques;
                    break;
                }
            case BiblioType.Tombales:
                {
                    return biblioElementsTombales;
                    break;
                }
            case BiblioType.Socles:
                {
                    return biblioElementsSocles;
                    break;
                }
            case BiblioType.Socles_larges:
                {
                    return biblioElementsSoclesLarges;
                    break;
                }

            case BiblioType.Steles:
                {
                    return biblioElementsSteles;
                    break;
                }
            case BiblioType.Steles_composees:
                {
                    return biblioElementsStelesComposees;
                    break;
                }
            case BiblioType.Steles_rustiques:
                {
                    return biblioElementsStelesRustiques;
                    break;
                }
            default:
                {
                    return null;
                }
            

        }


    }



}
