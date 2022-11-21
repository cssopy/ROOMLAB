using System.Collections;
using UnityEngine;


public class CompassCylinder : MonoBehaviour
{
    [SerializeField]
    GameObject magnet;
    [SerializeField]
    GameObject compass;
    Vector3 magnetCenter;
    Vector3 magnetNorth;
    Vector3 magnetSouth;
    Vector3 compassCenter;
    
    float mx, my, mnx, mny, msx, msy; 
    float cx, cy;
    float angleDiff;

    public void ChangeCylinder()
    {
        // Get the position of magnet and compass
        magnetNorth = magnet.transform.Find("NorthPoint").position;
        magnetSouth = magnet.transform.Find("SouthPoint").position;
        magnetCenter = (magnetNorth + magnetSouth) / 2;
        compassCenter = compass.transform.position;

        mx = magnetCenter.x;
        my = magnetCenter.z;
        mnx = magnetNorth.x;
        mny = magnetNorth.z;
        msx = magnetSouth.x;
        msy = magnetSouth.z;
        cx = compassCenter.x;
        cy = compassCenter.z;

        // If the magnet is close to compass,
        if(Vector3.Distance(compassCenter, magnetCenter) <= 0.5f)
        {
            if (Vector3.Distance(compassCenter, magnetNorth) <= 0.2f && Vector3.Distance(compassCenter, magnetSouth) <= 0.2f)
            {
                // Change the angle of the needle(compass) based on the angle between magnet and compass
                if (cy >= my)
                {
                    
                    if (cx >= mx) 
                        angleDiff = Mathf.Atan2(cy - msy, cx - msx) * Mathf.Rad2Deg -40;
                    else
                        angleDiff = -90 + (Mathf.Atan2(cy - msy, cx - msx) * Mathf.Rad2Deg + 120);
                } else
                {
                    if (cx >= mx)
                        angleDiff = -90 + (Mathf.Atan2(cy - mny, cx - mnx) * Mathf.Rad2Deg - 60);
                    else
                        angleDiff = (Mathf.Atan2(cy - mny, cx - mnx) * Mathf.Rad2Deg + 160);
                }

            } else
            {
                if (cy >= my)
                {
                    angleDiff = Mathf.Atan2(cy - msy, cx - msx) * Mathf.Rad2Deg;
                }
                else
                {
                    angleDiff = 180 +  Mathf.Atan2(cy - mny, cx - mnx) * Mathf.Rad2Deg;

                }
            }
            StartCoroutine(VibrateCylinderCoroutine(angleDiff));
        } 
    }
    IEnumerator VibrateCylinderCoroutine(float angleDiff) 
    {
        float runningTime = 0;
        float MAX_DEGREE = 40.0f;
        float angle;
        float speed = 10;
        float END_TIME = 30.0f;
        Quaternion rotation;

        // Give some vibration on the needle When we put the compass on the table.
        while (runningTime < END_TIME)
        {
            runningTime += Time.deltaTime * speed;
            angle = Mathf.Sin(runningTime) * MAX_DEGREE * (END_TIME - runningTime) / END_TIME;
            rotation = Quaternion.Euler(new Vector3(0, - 90 - angleDiff + angle, 90));
            transform.rotation = rotation;
            yield return null;
        }
        yield break;
    }

}



