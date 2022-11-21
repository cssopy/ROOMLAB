using UnityEngine;

public class CheckForCanvas : MonoBehaviour
{
    private CanvasPageCTR canvaspage;
    // Page 1
    public bool isBeakerOnHand = false;
    public bool isGlassStickOnHand = false;
    // Page 2
    public bool isGlassStickInclined = false;
    // Page 3
    public bool isLiquidInFunnel = false;
    // Page 4
    public bool isNoLiquidFunnel = false;
    // Page 5
    public bool isPaperOnGlassPlate = false;


    private void Start()
    {
        canvaspage = GetComponent<CanvasPageCTR>();
    }
    private void Update()
    {
        // Page 1
        if (isBeakerOnHand && isGlassStickOnHand)
        {
            canvaspage.SetPage(1);
        }

        // Page 2
        if (isGlassStickInclined)
        {
            canvaspage.SetPage(2);
        }

        // Page 3
        if (isLiquidInFunnel)
        {
            canvaspage.SetPage(3);
        }

        // Page 4
        if (isNoLiquidFunnel)
        {
            canvaspage.SetPage(4);
        }

        // Page 5
        if (isPaperOnGlassPlate)
        {
            canvaspage.SetPage(5);
        }
    }

}
