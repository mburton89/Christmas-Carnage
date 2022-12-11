using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelectMenu : MonoBehaviour
{
    //CHARACTERS
    public List<GameObject> characters;
    public List<GameObject> selectionOutlines;
    public List<Button> characterButtons;

    //SKINS
    public List<GameObject> xmasSprites;
    public List<GameObject> halloweenSprites;
    public List<GameObject> sherlockSprites;
    public List<GameObject> arrowSprites;

    //FONTS
    public List<TextMeshProUGUI> texts;
    public TMP_FontAsset xmasFont;
    public TMP_FontAsset halloweenFont;
    public TMP_FontAsset sherlockFont;
    public TMP_FontAsset arrowFont;

    //PIPES
    public List<GameObject> PipePrefabs;

    private void Awake()
    {
        ActivateCharacter();
        ShowSkin();
    }

    void OnEnable()
    {
        characterButtons[0].onClick.AddListener(delegate { HandleCharacterButtonPressed(0); });
        characterButtons[1].onClick.AddListener(delegate { HandleCharacterButtonPressed(1); });
        characterButtons[2].onClick.AddListener(delegate { HandleCharacterButtonPressed(2); });
        characterButtons[3].onClick.AddListener(delegate { HandleCharacterButtonPressed(3); });
        characterButtons[4].onClick.AddListener(delegate { HandleCharacterButtonPressed(4); });
        characterButtons[5].onClick.AddListener(delegate { HandleCharacterButtonPressed(5); });
        characterButtons[6].onClick.AddListener(delegate { HandleCharacterButtonPressed(6); });
        characterButtons[7].onClick.AddListener(delegate { HandleCharacterButtonPressed(7); });
        characterButtons[8].onClick.AddListener(delegate { HandleCharacterButtonPressed(8); });
        characterButtons[9].onClick.AddListener(delegate { HandleCharacterButtonPressed(9); });
        characterButtons[10].onClick.AddListener(delegate { HandleCharacterButtonPressed(10); });
        characterButtons[11].onClick.AddListener(delegate { HandleCharacterButtonPressed(11); });

    }

    void OnDisable()
    {
        for (int i = 0; i < characterButtons.Count - 1; i++)
        {
            characterButtons[i].onClick.RemoveAllListeners();
        }
    }

    void ActivateCharacter()
    {
        characters[PlayerPrefs.GetInt("character")].SetActive(true);
        selectionOutlines[PlayerPrefs.GetInt("character")].SetActive(true);
    }

    void HandleCharacterButtonPressed(int buttonIndex)
    {
        PlayerPrefs.SetInt("character", buttonIndex);

        foreach (GameObject selectionOutline in selectionOutlines)
        {
            selectionOutline.SetActive(false);
        }
        selectionOutlines[PlayerPrefs.GetInt("character")].SetActive(true);
    }

    void ShowSkin()
    {
        int index = PlayerPrefs.GetInt("character");
        ResetSkins();

        if (index > 7)
        {
            foreach (GameObject gameObject in halloweenSprites)
            {
                gameObject.SetActive(true);
            }
            foreach (TextMeshProUGUI text in texts)
            {
                text.font = halloweenFont;
            }

            FindObjectOfType<SnowManager>().transform.localScale = Vector3.zero;
            PlayerPrefs.SetInt("pipe", 1);
        }
        else if (index == 1)
        {
            foreach (GameObject gameObject in sherlockSprites)
            {
                gameObject.SetActive(true);
            }
            foreach (TextMeshProUGUI text in texts)
            {
                text.font = sherlockFont;
            }
            FindObjectOfType<SnowManager>().transform.localScale = Vector3.zero;
            PlayerPrefs.SetInt("pipe", 2);
        }
        else if (index == 5)
        {
            foreach (GameObject gameObject in arrowSprites)
            {
                gameObject.SetActive(true);
            }
            foreach (TextMeshProUGUI text in texts)
            {
                text.font = arrowFont;
            }
            FindObjectOfType<SnowManager>().transform.localScale = Vector3.zero;
            PlayerPrefs.SetInt("pipe", 3);
        }
        else
        {
            foreach (GameObject gameObject in xmasSprites)
            {
                gameObject.SetActive(true);
            }
            foreach (TextMeshProUGUI text in texts)
            {
                text.font = xmasFont;
            }
            FindObjectOfType<SnowManager>().transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            PlayerPrefs.SetInt("pipe", 0);
        }
    }

    void ResetSkins()
    {
        foreach (GameObject gameObject in xmasSprites)
        {
            gameObject.SetActive(false);
        }
        foreach (GameObject gameObject in halloweenSprites)
        {
            gameObject.SetActive(false);
        }
        foreach (GameObject gameObject in sherlockSprites)
        {
            gameObject.SetActive(false);
        }
        foreach (GameObject gameObject in arrowSprites)
        {
            gameObject.SetActive(false);
        }
    }
}
