using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static int totalEnergy;

    public delegate void EnergyChangeAction(int newValue);
    public static event EnergyChangeAction OnEnergyChange;

    [SerializeField]
    private int startingEnergy;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private float camPanSpeed; 
    [SerializeField]
    private float camZoomSpeed;
    [SerializeField]
    private float maxCamZ;

    [SerializeField]
    private Energy energyPrefab;

    public static Energy energy;

    private Modifier handling;
    private Vector3 panInput;
    private Vector3 zoomInput;

    private void Awake()
    {
        energy = energyPrefab;
    }

    private void Start()
    {
        Physics.IgnoreLayerCollision(6, 6);

        AddEnergy(startingEnergy);
    }

    private void Update()
    {
        if(handling != null)
        {
            Vector3 worldPosition = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -cam.transform.position.z));
            Vector3 handlingPos = IntPosition(worldPosition);
            //check for location being occupied
            RaycastHit hit;
            if (!Physics.Linecast(cam.transform.position, new Vector3(handlingPos.x, handlingPos.y, handlingPos.z), out hit))
            {
                if(hit.transform?.GetComponent<Modifier>() != handling)
                    handling.transform.position = new Vector3(handlingPos.x, handlingPos.y, handlingPos.z);
            }
        }
    }

    private void LateUpdate()
    {
        Vector3 zMove = zoomInput * camZoomSpeed * Time.deltaTime;
        Vector3 panMove = panInput * camPanSpeed * Time.deltaTime;
        if (cam.transform.position.z + zMove.z >= maxCamZ)
            zMove = Vector3.zero;

        cam.transform.position += zMove + panMove;
    }

    public static void AddEnergy(int val)
    {
        totalEnergy += val;
        OnEnergyChange.Invoke(totalEnergy);
    }

    private Vector3 IntPosition(Vector3 position)
    {
        float roundX = Mathf.RoundToInt(position.x);
        float roundY = Mathf.RoundToInt(position.y);
        float roundZ = Mathf.RoundToInt(position.z);
        return new Vector3(roundX, roundY, roundZ);
    }

    public void Click(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Ray ray = cam.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1f));
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.yellow, 3);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);

            ModifierSelector selector;
            if ((selector = hit.transform?.GetComponent<ModifierSelector>()) != null)
            {
                if (totalEnergy >= selector.cost)
                {
                    AddEnergy(-selector.cost);
                    Vector3 worldPosition = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -cam.transform.position.z));
                    Vector3 clonePos = IntPosition(worldPosition);
                    Modifier clone = hit.transform.GetComponent<ModifierSelector>().Generate();
                    clone.transform.position = clonePos;
                    handling = clone;
                    handling.handled = true;
                }
            }
        }

        if(context.canceled)
        {
            if (handling != null)
            {
                handling.handled = false;
                handling = null;
            }
        }
    }

    public void Pan(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            panInput = context.ReadValue<Vector2>();
        }
        
        if(context.canceled)
        {
            panInput = Vector3.zero;
        }
    }

    public void Zoom(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            zoomInput = new Vector3(0f, 0f, Mathf.Sign(context.ReadValue<Vector2>().y));
        }

        if(context.canceled)
        {
            zoomInput = Vector3.zero;
        }
    }
}
