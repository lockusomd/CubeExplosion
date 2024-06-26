using UnityEngine;

public class RaycastClicker : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Ray _ray;
    [SerializeField] private float _radius = 2f;

    private RaycastHit _hit;

    private void Update()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_ray, out _hit, Mathf.Infinity))
            {
                Transform objectHit = _hit.transform;

                if(objectHit.tag == "DestroyableObject")
                {
                    objectHit.gameObject.GetComponent<Destroyer>().DestroyPrefab();
                }
            }
        }
    }
}