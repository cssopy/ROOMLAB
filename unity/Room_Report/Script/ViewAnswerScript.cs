using UnityEngine;
using UnityEngine.UI;

public class ViewAnswerScript : MonoBehaviour
{
    private Outline outline;

    public void WhileHover()
    {
        outline = GetComponent<Outline>();
        if (outline.effectColor == Color.red)
        {
            outline.effectColor = Color.yellow;
        }
    }

    public void WhenLeave()
    {
        outline = GetComponent<Outline>();
        if (outline.effectColor == Color.yellow)
        {
            outline.effectColor = Color.red;
        }
    }

    public void WhenClicked()
    {

        // 클릭 시 정답을 토글
        outline = GetComponent<Outline>();
        if (outline.effectColor == Color.yellow)
        {
            GameObject answer = transform.parent.Find($"ViewAnswer_{name.Split("_")[1]}").gameObject;
            answer.SetActive(!answer.activeSelf);
        }
    }
}
