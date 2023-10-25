using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index = 0;
    private bool isTyping = false; 
    public float wordSpeed;
    public bool playerIsClose;
    public GameObject TeksInteraksi;
    public string npcName;
    public TextMeshProUGUI npcNameText;
    public GameObject NextButton;
    void Start()
    {
        dialogueText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (!dialoguePanel.activeInHierarchy)
            {
                dialoguePanel.SetActive(true);
                npcNameText.text = npcName;

                if (!isTyping) // Hanya mulai mengetik jika tidak sedang ngetik
                {
                    StartCoroutine(Typing());
                }
                
                TeksInteraksi.SetActive(false);
            }
            else if (dialogueText.text == dialogue[index])
            {
                NextLine();
            }
        }
        if(dialogueText.text == dialogue[index])
        {
            NextButton.SetActive(true);
             
        }
    }

    public void RemoveText()
    {
        // Hanya hapus teks jika pengetikan sudah selesai
        if (!isTyping)
        {
            dialogueText.text = "";
            index = 0;
            dialoguePanel.SetActive(false);
        }
    }



    IEnumerator Typing()
    {
        isTyping = true; //  pengetikan sedang berlangsung

        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }

        isTyping = false; // Pengetikan sudah selesai
    }

    public void NextLine()
    {
        NextButton.SetActive(false);

    
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            RemoveText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            TeksInteraksi.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            RemoveText();
            TeksInteraksi.SetActive(false);
        }
    }


}


