using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    Transform aimtransorm;
    public Transform firepoint;
    Vector3 aimDirection;
    public LineRenderer renderer;
    private void Awake()
    {
        aimtransorm = transform.Find("Aim");
    }

    private void Update()
    {
        aim();
       StartCoroutine( Shoot());
    }

    void aim()
    {
        Vector3 mousePosition = GetMouseWorldPosition();

         aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimtransorm.eulerAngles = new Vector3(0, 0, angle);
    }

    IEnumerator Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
           RaycastHit2D hitinfo= Physics2D.Raycast(firepoint.position, aimDirection);
            if (hitinfo)
            {
                Enemy enemy = hitinfo.transform.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.die();
                    GameController.instance.addscore();
                }
                renderer.SetPosition(0, firepoint.position);
                renderer.SetPosition(1, hitinfo.point);

            }
            renderer.enabled = true;
            yield return new WaitForSeconds(0.02f);

            renderer.enabled = false;
        }

    }
     Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }

     Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);

    }
     Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);

    }

     Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition,Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }



}
