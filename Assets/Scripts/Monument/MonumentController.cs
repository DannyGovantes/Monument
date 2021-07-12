using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Knife.HDRPOutline.Core;

//CONTROLAR EL MONUMENTO Y NADA MÁS
public class MonumentController : MonoBehaviour
{
    private Camera _camera;
    public GameObject activeElement;
    public GameObject Menu3dMateriaux;
    public GameObject Menu3dElements;
    public GameObject Panels_optionsBibliosElements;

    private Vector2 _mousePosition;

    private int limXscrollLeft = 200;
    private int limXscrollRight;
    private float limMinTranslationMenu3dLeft = 0.17f;
    private float limMaxTranslationMenu3dLeft = 0.01302195f;
    private float limMinTranslationMenu3dRight = 0.06f;
    private float limMaxTranslationMenu3dRight = -0.011f;
    private int limYclick;

    private MonumentManager _monumentManager;

    private Canvas Canvas;

    public void ChangeMesh(GameObject tombale, MeshFilter meshFilter)
    {
        activeElement.GetComponent<MeshFilter>().mesh = meshFilter.mesh;
    }
    public void ChangeMaterial(GameObject tombale, Material material)
    {
        activeElement.GetComponent<Renderer>().material = material;

    }

    private void Start()
    {
        _camera = Camera.main;
        Canvas canvas = FindObjectOfType<Canvas>();
        float h = canvas.GetComponent<RectTransform>().rect.height;
        float l = canvas.GetComponent<RectTransform>().rect.width;
        limXscrollRight = (int)(l - 250f);
        limYclick = (int)(h - 120);

        _monumentManager = FindObjectOfType<MonumentManager>();
       
        DeactivateMenus3d();
    }

    private void Update()
    {
        //GESTION DES MENUS 3D
        if (Input.mouseScrollDelta.y < 0 && Input.mousePosition.x < limXscrollLeft && Menu3dMateriaux.transform.localPosition.y > limMaxTranslationMenu3dLeft) Menu3dMateriaux.transform.Translate(0, -Time.deltaTime / 3, 0);
        if (Input.mouseScrollDelta.y > 0 && Input.mousePosition.x < limXscrollLeft && Menu3dMateriaux.transform.localPosition.y < limMinTranslationMenu3dLeft)  Menu3dMateriaux.transform.Translate(0, Time.deltaTime / 3, 0);

        if (Input.mouseScrollDelta.y < 0 && Input.mousePosition.x > limXscrollRight && Menu3dElements.transform.localPosition.y > limMaxTranslationMenu3dRight) Menu3dElements.transform.Translate(0, -Time.deltaTime / 3, 0);
        if (Input.mouseScrollDelta.y > 0 && Input.mousePosition.x > limXscrollRight && Menu3dElements.transform.localPosition.y < limMinTranslationMenu3dRight) Menu3dElements.transform.Translate(0, Time.deltaTime / 3, 0);
        //FIN DE GESTION DES MENUS 3D


        
        _mousePosition = Input.mousePosition;

        //WORKING ZONE: THE MONUMENT
        if (_mousePosition.x > limXscrollLeft && _mousePosition.x < limXscrollRight && _mousePosition.y < limYclick)
        { 

          if(Input.GetButtonDown("Fire1"))
          {
            //salir de la cámara, y va a detectar la posición del mouse y el objeto que toque, me va a regresar una información
            Ray ray = _camera.ScreenPointToRay(_mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
               GameObject monumentElementExist = hit.collider.GetComponent<ElementMonuParams>().gameObject;
               if(monumentElementExist)
               {
                    ActiveMenus3d();
                    if(activeElement.GetComponent<OutlineObject>().enabled) activeElement.GetComponent<OutlineObject>().enabled=false;// deactive outline of last active element

                    _monumentManager.Counter = 0;
                    activeElement = monumentElementExist;
                    activeElement.GetComponent<OutlineObject>().enabled = true;
                    _monumentManager.ActiveCompatiblesBiblioElements(activeElement.name);  }

            }
            else  //click dans le vide
            {
                DeactivateMenus3d();
                activeElement.GetComponent<OutlineObject>().enabled=false;
            }

          }
            // END OF "WORKING ZONE: THE MONUMENT"

            //WORKING ZONE: MENUS3D (biblio materiaux & biblios elements)    
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("suis entré");
            Ray ray = _camera.ScreenPointToRay(_mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject ObjectHit = hit.collider.gameObject;
                _monumentManager.Manage3dMenuClickHit(gameObject);
                Debug.Log(ObjectHit.name.Substring(0, 7));
                if (ObjectHit.name.Substring(0, 7) == "Matiere")
                {
                    Debug.Log("hurra!");
                }
               
            }
        }
        //END OF WORKING ZONE: MENUS3D (biblio materiaux & biblios elements)

    }

    private void DeactivateMenus3d()
    {
        Menu3dMateriaux.SetActive(false);
        Menu3dElements.SetActive(false);
        Panels_optionsBibliosElements.SetActive(false);

    }
    
    private void ActiveMenus3d()
    {
        Menu3dMateriaux.SetActive(true);
        Menu3dElements.SetActive(true);
        Panels_optionsBibliosElements.SetActive(true);

    }
    private void ActiveElements(BiblioType type)
    {
        string nameTypePrincipal;

        nameTypePrincipal = activeElement.name;

        //TODO: case de type
        Menu3dMateriaux.SetActive(true);
        Menu3dElements.SetActive(true);

    }

}
