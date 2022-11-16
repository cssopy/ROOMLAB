using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.Android;

public class PictureScript : MonoBehaviour
{
    // ���� ���� ���� ������
    private DateTime date;

    // ���͸��� ���� ���ڿ� ȭ
    private string startedDateTime;

    // ���͸� �� �̹������� ��� ����
    private List<string> imgPaths = new List<string>();

    // �� �� ���������� ����ϱ�
    private int pageIdx = 0;

    // ������ ���� ��ü
    private GameObject picture;

    // ������
    public GameObject preview;

    // ���õ� ������
    public List<string> selected = new List<string>();

    // ��ư��
    public GameObject upButton;
    public GameObject downButton;

    GameObject dialog = null;

    void Awake()
    {
        // ���� �ð� �ҷ����� �� ���͸� �غ�
        date = DateTime.Now;
        startedDateTime = $"com.oculus.shellenv-{date.ToString($"yyyyMMdd-HHmmss")}.jpg";
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageRead)) 
        {
            Permission.RequestUserPermission(Permission.ExternalStorageRead);
            dialog = new GameObject();
        }
        else { ResetPictures(); }
    }

    private void OnEnable()
    {
        ResetPictures();
    }

    private void OnGUI()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageRead))
        {

            dialog.AddComponent<PermissionsRationaleDialog>();
            return;
        }
        else if (dialog != null)
        {
            Destroy(dialog);
        }
    }


    private void ResetPictures()
    {
        // ��ε��� ���� ���� ó��
        for (int a = 0; a < 8; a++)
        {
            GameObject picture = transform.Find($"Picture_{a}").gameObject;
            picture.GetComponent<Outline>().effectColor = Color.black;
            picture.transform.Find($"Check_mark_{a}").gameObject.SetActive(false);
            picture.SetActive(false);
        }



        // ������ ����� ���
        // string path = "C:/Users/multicampus/Desktop/Screenshots";
        string path = "/storage/emulated/11/Oculus/Screenshots";
        // string path = "�� PC/Quest 2/���� ���� ����뷮/Oculus/Screenshots";
        // string path = "/sdcard/my_folder/my_file";



        // ���� �ҷ����� ����
        string[] images = Directory.GetFiles(path, "*jpg");
        
        // �ֽż����� �ҷ����� ���� ��������
        Array.Reverse(images);

        imgPaths = new List<string>{ };

        // ������ ������� ���͸�
        // **********���߿��� ��Ұ��踦 �ٲ�� �Ѵ�**********
        for (int i = 0; i < images.Length; i++)
        {
            if (string.Compare(Path.GetFileName(images[i]), startedDateTime) >= 0)
            {
                imgPaths.Add(images[i]);
            }
        }

        // ���� ����
        for (int j = 0; j < imgPaths.Count - pageIdx * 8; j++)
        {
            // ������ �� ���� 8����
            if (j == 8)
            {
                break;
            }

            else
            {
                picture = transform.Find($"Picture_{j}").gameObject;
                byte[] bytes = File.ReadAllBytes(imgPaths[pageIdx * 8 + j]);
                Texture2D texture = new Texture2D(2, 2);
                texture.LoadImage(bytes);
                picture.GetComponent<RawImage>().texture = texture;
                picture.SetActive (true);

                // ���õ� �����̸� ��� ����
                if (selected.Contains(imgPaths[pageIdx * 8 + j]))
                {
                    picture.GetComponent<Outline>().effectColor = Color.magenta;
                    picture.transform.Find($"Check_mark_{j}").gameObject.SetActive(true);
                }
            }
        }

        // �������� ���� �ε��� ��ư ����
        upButton.SetActive(pageIdx != 0);
        downButton.SetActive((pageIdx + 1) * 8 < imgPaths.Count);

    }
    
    // 1. ���� ���� ȣ������ �� ū ȭ�� ����

    public void OpenPreview(int n)
    {
        byte[] bytes = File.ReadAllBytes(imgPaths[pageIdx*6+n]);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(bytes);
        preview.GetComponent<RawImage>().texture = texture;
        preview.SetActive(true);
    }

    public void ClosePreview()
    {
        preview.GetComponent<RawImage>().texture = null;
        preview.SetActive(false);
    }
    
    // 2. ���� �� �����Ͽ� ���� üũ ǥ�� �� ī��Ʈ, �׵θ� �����
    public Boolean SelectPicture(int m)
    {
        // �̹� ������ ���� & ���
        if(selected.Contains(imgPaths[pageIdx * 8 + m]))
        {
            selected.Remove(imgPaths[pageIdx * 8 + m]);
            transform.Find("Selected_count").GetComponent<Text>().text = $"{selected.Count}";
            if (selected.Count == 4)
            {
                transform.Find("Selected_count").GetComponent<Text>().color = Color.white;
            }
            return false;
        }

        // ������ �߰� & Ȱ��ȭ
        else
        {
            selected.Add(imgPaths[pageIdx * 8 + m]);
            transform.Find("Selected_count").GetComponent<Text>().text = $"{selected.Count}";
            if (selected.Count == 5)
            {
                Color color;
                ColorUtility.TryParseHtmlString("#AD34FFFF", out color);
                transform.Find("Selected_count").GetComponent<Text>().color = color;
            }
            return true;
        }

    }


    // 3. ������ �ѱ�� ��� ���� (��, �Ʒ��� �ٲٰ�, �� ���� �� �Ʒ������� �� �������� �� ���� �ؾ���) + ������ ���������� ������ �� ��� off ���Ѿ���
    public void Pagination(int k)
    {
        pageIdx += k;
        ResetPictures();
    }

}
