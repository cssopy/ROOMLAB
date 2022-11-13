using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

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
    private List<string> selected = new List<string>();

    void Awake()
    {
        // ���� �ð� �ҷ����� �� ���͸� �غ�
        date = DateTime.Now;
        startedDateTime = $"com.oculus.shellenv-{date.ToString($"yyyyMMdd-HHmmss")}.jpg";
        ResetPictures();
    }

    private void OnEnable()
    {
        ResetPictures();
    }

    private void ResetPictures()
    {
        // ������ ����� ���
        string path = "C:/Users/multicampus/Desktop/Screenshots";
        // string path = "This-Headset/Oculus/Screenshots";
        // string path = "�� PC/Quest 2/���� ���� ����뷮/Oculus/Screenshots";
        // string path = "/sdcard/my_folder/my_file";


        // ���� �ҷ����� ����
        string[] images = Directory.GetFiles(path, "*jpg");
        
        // �ֽż����� �ҷ����� ���� ��������
        Array.Reverse(images);

        imgPaths = new List<string>{ };

        // ������ ������� ���͸�
        for (int i = 0; i < images.Length; i++)
        {
            if (string.Compare(Path.GetFileName(images[i]), startedDateTime) < 0)
            {
                imgPaths.Add(images[i]);
            }
        }

        // ���� ����
        for (int j = pageIdx; j < imgPaths.Count; j++)
        {
            // ������ �� ���� 8����
            if (j-pageIdx == 8)
            {
                break;
            }

            else
            {
                picture = transform.Find($"Picture_{j}").gameObject;
                byte[] bytes = File.ReadAllBytes(imgPaths[j]);
                Texture2D texture = new Texture2D(2, 2);
                texture.LoadImage(bytes);
                picture.GetComponent<RawImage>().texture = texture;
                picture.SetActive (true);
            }
        }

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
            return false;
        }

        // ������ �߰� & Ȱ��ȭ
        else
        {
            selected.Add(imgPaths[pageIdx * 8 + m]);
            return true;
        }
    }


    // 3. ������ �ѱ�� ��� ���� (��, �Ʒ��� �ٲٰ�, �� ���� �� �Ʒ������� �� �������� �� ���� �ؾ���) + ������ ���������� ������ �� ��� off ���Ѿ���
    // 4. ���� �ۼ� ���� ���� ��� �ʿ�(�ݱ�)

}
