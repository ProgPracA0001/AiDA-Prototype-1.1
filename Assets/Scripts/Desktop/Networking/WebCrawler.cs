using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebCrawler : MonoBehaviour
{
    public GameController controller;

    public GameObject rescueBitInstallWindow;

    public GameObject alreadyInstalledWindow;

    public Text webText;

    public InputField searchInput;

    public GameObject RescueBitDownloadButton;

    // Start is called before the first frame update

    public string[] RestorationSoftware =
    {
        "RescueBit\n",
        "Your Data, Recovered Instantly\n",
        "\n",
        "Have you lost an important file? Or is a corrupted file preventing you from accessing your valuable data? RescueBit is here to help! Our software quickly and securely restores lost or damaged files. With a powerful yet user-friendly interface, you can recover your data in just a few clicks—no technical skills required.\n",
        "\n",
        "Our journey began in 2002, when personal computers became more common in everyday homes—and so did the frustration of file loss and corruption. We saw an opportunity to develop a solution, focusing on repairing corrupted and damaged files, the most frequent issues users faced.\n",
        "As technology advanced, so did RescueBit. In 2010, we introduced Lost File Retrieval, allowing users to recover deleted files with ease. This major upgrade inspired a full redesign of the software, enhancing both its features and its intuitive design.",
        "\n",
        "Today, RescueBit offers a flexible subscription model. Our monthly plan includes full access to all tools, along with fast-track support from data recovery experts—one of the most popular perks among our customers.\n",
        "\n",
        "For users with lighter needs, we offer alternative versions of the software with limited tool access. These still provide reliable recovery for damaged and corrupted files, making RescueBit accessible to everyone.\n",
        "To download our free version, please click the link below and start recovering your lost files today\n"

    };

    public string[] AdminPasswords =
    {
        "Admin Passwords\n",
        "\n",
        "Using admin passwords is a great way to manage access to certain parts of your machine, as well as files you want to protect/restrict access to. The Aministrator-level grants full control over system configurations, software installations, and user permissions.\n",
        "Unlike standard user passwords, admin passwords provide elevated privileges, making them essential for system management and security.\n",
        "\n",
        "WHY ARE THEY IMPORTANT?\n",
        "Security Control:",
        "Security and Protection:\n",
        "Troubleshooting and Maintenance: \n",
        "Data Management: \n",
        "\n",
        "\n"

    };

    void Start()
    {
        ResetText();
        searchInput.text = string.Empty;
        webText.text = string.Empty;
    }
    public void Home()
    {
        ResetText();
        searchInput.text = string.Empty;
        webText.text = string.Empty;
    }

    public void SearchWeb()
    {
        ResetText();
        if (searchInput.text.ToLower() == "restoration" || searchInput.text.ToLower() == "restoration software" || searchInput.text.ToLower() == "rescue bit" || searchInput.text.ToLower() == "rescuebit")
        {
            StartCoroutine(LoadWebWithButton(RestorationSoftware, RescueBitDownloadButton));
            
        }
        else if (searchInput.text.ToLower() == "admin" || searchInput.text.ToLower() == "admin passwords")
        {
            StartCoroutine(LoadWeb(AdminPasswords));
        }
        else
        {
            webText.text = "ERROR 404: Page Not Found\n Try searching again";
        }
    }

    public void ResetText()
    {
        StopAllCoroutines();
        RescueBitDownloadButton.SetActive(false);
    }

    public void RescueBitInstall()
    {
        CheckProgramInstall(rescueBitInstallWindow, alreadyInstalledWindow, controller.currentPlayer.data.RescureBitInstalled);
    }

    public void CheckProgramInstall(GameObject downloadWindow, GameObject isDownloadedWindow, bool isDownloaded)
    {
        if (isDownloaded)
        {
            isDownloadedWindow.GetComponent<WindowControllerScript>().Open();

        }
        else
        {
            downloadWindow.GetComponent<WindowControllerScript>().Open();
        }
    }

    IEnumerator LoadWebWithButton(string[] webPage, GameObject Button)
    {
        webText.text = "";

        foreach (string line in webPage)
        {
            yield return StartCoroutine(TypeLine(line));

            yield return new WaitForSeconds(0.009f);
        }

            yield return new WaitForSeconds(0.01f);
            Button.SetActive(true);
        
    }
    IEnumerator LoadWeb(string[] webPage)
    {
        webText.text = "";

        foreach (string line in webPage)
        {
            yield return StartCoroutine(TypeLine(line));

            yield return new WaitForSeconds(0.009f);
        }

    }

    IEnumerator TypeLine(string currentLine)
    {

        foreach (char letter in currentLine)
        {
            webText.text += letter;
            yield return new WaitForSeconds(0.005f);

        }

    }
}
