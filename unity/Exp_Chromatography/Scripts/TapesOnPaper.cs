using UnityEngine;

public class TapesOnPaper : MonoBehaviour
{
    [SerializeField]
    GameObject SmallTape1;
    [SerializeField]
    GameObject SmallTape2;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "SmallTape1" || other.gameObject.name == "SmallTape2")
        {
            other.gameObject.SetActive(false);
            SmallTape1.SetActive(true);
            SmallTape2.SetActive(true);
        }
    }
}
