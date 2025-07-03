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
        "Many modern systems ustilise this within their window controls, however some older systems utilise the ctrl + alt + delete method to gain access to the BIOS.\n"

    };

    public string[] OldHeadlines =
    {
        "The Old Post Archives\n",
        "Site ran by: J.G.Joiner\n",
        "\n",
        "**IMPORTANT** The Old Post head office caught fire in 1990, following further investigations into Dalhurst Explosion. Working there at the time I tried to save as much as possible.\n",
        "Alas, it was a poor attempt, the blaze was ferocious, consuming the buildings on either side. I have attempted to record as much as I could remember to build on the information I did manage to save.\n",
        "I returned to the office after the blaze however there was no chance of salvaging any documents, so there are unfortuantely large gaps between records.\n",
        "I have recorded all that I can on this website. I believe it is the publics right to know.\n",
        "\n",
        "\n",
        "** RECORD: 01 **\n",
        "Date: Wednesday 24th November 1986\n",
        "Headline: Abandoned Factory Goes Sky High\n",
        "\n",
        "Investigation underway as death toll remains unknown.\n",
        "Author: J. G. Joiner\n",
        "\n",
        "A thunderous explosion rocked the quiet valley of Dalhurst last night. It emanated from an abandoned factory that had long been a silent sentinel of the town's industrial past. The derelict Structure, known to have been empty for years was suddenly engulfed in flames, sending shockwaves through the community.\n",
        "Emergency services rushed to the scene finding a roaring pile of rubble. As firefighters battled the inferno, suspicions arose. Some witness present before first responders, claimed to have seen strange vehicles appraoching the area shortly after the explosion, prompting fears of foul play. Authorities swiftly cordoned off the scene, launching an investigation into the cause of the blast. The death toll if any, remains unknown as teams combat the remaining flames. Residents already uneasy due to recent vandalism expressed concerns about their safety.\n",
        "\n",
        "Questions linger about the cause of the explosion. Was it tragic accident? The truth remains elusive, shrouded in the smoke and rubble of the factory.\n",
        "\n",
        "********************************************************************",
        "\n",
        "** RECORD: 02 **\n",
        "Date: Saturday 24th January 1987\n",
        "Headline: The Dalhurst Explosion, 2 Months On\n",
        "\n",
        "Few answers, strange sighting and still the search for the truth continues.\n",
        "Author: J. G. Joiner\n",
        "\n",
        "Local authorites remain tight-lipped as invetigations into The Dalhurst Factory Explosion stretches into their second month. What was initially dismissed as a gas leak has now drawn interest from federal investiagtors, though there has been no confirmation of involvment from official agencies.\n",
        "Anonymous sources from within the emergeny services describe discovery of 'non-standard equiptment' buried in the debris, including reminents of sealed cases with serial numbers and no manufacturer. One fire chief, speaking under the condition of remaning anonymous described the interior as 'far from abandoned'.\n",
        "Reports from residents calimed unusual military presence in the weeks following the explosion, including unmarked cars parked around the factory site and sounds of helicopters flying over the valley during the night. The reason for these appearances remain unknown, with local authorities and federal investigators denying any connections. Residents have been told to remain calm with rassurance that these are most likely 'routine training operations'.\n",
        "\n",
        "The death toll still remains as 0, and no offical casualty list has been released. Despite ongoing efforts to gain access to the lower level basements of the factory, structural integrity has caused significant delay. However, the factory, previously thought to be owned by a dissolved manufacturing company in 1949, has been linked to a shell corporation under review by investigative watchdogs. Rumours among residents suggest the factory may have been part of a larger, hidden research effort. Though no records of this work exists in public archives. A valley resident living 2 streets from the main road to the factory, on 'Hoburt street' claimed a strange man had knocked on her door. She described him as being wide-eyed and shaky, then when she asked who he was he fled.\n",
        "The truth remains elusive, keep updated and purchase the next issue of the Old Post.\n",
        "\n",
        "********************************************************************",
        "\n",
        "** RECORD: 03\n",
        "Date: Tuesday 24th September 1987\n",
        "Headline: The Dalhurt Explosion One Year Anniversary\n",
        "\n",
        "\n",
        "Author: J. G. Joiner\n",
        "\n",
        "A year has passed since the night that reshaped Dalhurst Valley forever. Official Statements have dried up, but the residents have not forgotten the plume of fire that lit up the valley and the destruction left in its wake. In the absence of formal answers, theories continue to circulate with the evidence of a larger plan being found in the environmental impacts. Old factory pipes used for dumping the industrial waste in the 1900s still formed an integral part of the buildings structure. The dumping of waste in the valley was banned in 1904 after significant imapct into the waterstream wiped out 50% of the village and the pipes were blocked off but never removed.\n",
        "Inspection of the lower levels from authorities reported no damage with the pipes still being intact. Farmers protest these reports, following concerns after witnessing a significant decline in the health of their livestock. Since reporting this issue, farmers have since claimed 'water treatment officials' have visited their properties following the increase in affected livestock. Veryfew reports have been released leading to farmers speculating if the water treatment officals were legitimate, in thhe little that has been published, the chemicals found are inconsistent with previous statements issued by authorities.\n",
        "Outrage among residents affected has reached boiling point. A petition calling for independent inquiry has gathered over 2,000 signatures from the resdients and surrounding areas with the total growing quicky. Farmers lead the petition, for the health of their animals and for some acknowledgement by government bodies that this is bigger than the town. The environmental implications cannot be ignored.  \n",
        "Older residents of the valley many whom worked in the facory themselves support claims of the farmers. A gentlemen who also wishes to remain anonymous worked within the factory for many years between 1920-1930 claimed that the where the pipes ran through the basements, given the size of the blast it would be impossible for them too remain in tact. Attempts to obtain floor plans or structural blueprints of the factory have failed. Records have been labelled as lost, sealed, or they never existed. One local said 'It's like the place was built to disapear'.\n",
        "\n",
        "A second local has also reported seeing a strange man on the night of the blast, stumbling through the village. \n",
        "\n",
        "As of writing, no one has been held responsible. No final report has been published, but the mystery grows fueled by the passion of the valleys residents.\n",
        "\n",
        "********************************************************************",
        "\n"

    };

    public string[] NEWPAGE =
    {
        "The Old Post\n",
        "\n",
        "\n",
        "\n",
        "\n",
        "\n",
        "\n",
        "\n",
        "\n",
        "\n",
        "\n",
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
            if (controller.currentPlayer.data.currentChapter == 2 && !controller.currentPlayer.data.sideObjSubTwo_OneComplete)
            {
                controller.UpdateObjective("sideTwoSubOne");
            }

            StartCoroutine(LoadWeb(AdminPasswords));
        }
        else if (searchInput.text.ToLower() == "the old post" || searchInput.text.ToLower() == "J G Joiner" || searchInput.text.ToLower() == "J. G. Joiner" || searchInput.text.ToLower() == "J.G.Joiner" || searchInput.text.ToLower() == "JG Joiner" || searchInput.text.ToLower() == "JGJoiner")
        {
            if(controller.currentPlayer.data.currentChapter == 2 && !controller.currentPlayer.data.sideObjSubOne_OneComplete)
            {
                controller.UpdateObjective("sideOneSubOne");
            }
            StartCoroutine(LoadWeb(OldHeadlines));
        }
        else
        {
            webText.text = "ERROR 404: Page Not Found\n Try searching again\n Use more specific words or phrases in related to your search";
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
