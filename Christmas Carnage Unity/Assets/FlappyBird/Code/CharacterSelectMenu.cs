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
    public SpriteRenderer backgroundSpriteRenderer;
    public List<Sprite> backgroundSprites;

    public SpriteRenderer groundSpriteRenderer;
    public List<Sprite> groundSprites;

    public Image playButtonImage;
    public List<Image> playButtonSprites;

    public List<TextMeshProUGUI> allText;
    public List<TMP_FontAsset> TMPFontAssets;

    //PIPES
    //public List



    private void Awake()
    {
        ActivateCharacter();
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
}
