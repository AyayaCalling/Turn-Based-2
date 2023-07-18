using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUpManager : MonoBehaviour
{
    #region Variables

    public GameObject SkillUpWindow;
    public Restsite restSite;

    public Skill SkillOne;
    public Skill SkillTwo;
    public Skill SkillThree;
    //public Image SkillUpBackground;
    
    //Buttons for Skill 1:
    public Button S1U11; //SKill 1 Upgrade 1.1
    public Button S1U21;
    public Button S1U22;
    public Button S1U23;
    public Button S1U31;
    public Button S1U32;
    public Button S1U33;

    //Buttons for Skill 2:
    public Button S2U11; //SKill 2 Upgrade 1.1
    public Button S2U21;
    public Button S2U22;
    public Button S2U23;
    public Button S2U31;
    public Button S2U32;
    public Button S2U33;

    //Buttons for Skill 3:
    public Button S3U11; //SKill 3 Upgrade 1.1
    public Button S3U21;
    public Button S3U22;
    public Button S3U23;
    public Button S3U31;
    public Button S3U32;
    public Button S3U33;

    #endregion

    #region UI-Management

    public void Awake()
    {
        S1U31.interactable = false;
        S1U32.interactable = false;
        S1U33.interactable = false;
        S2U31.interactable = false;
        S2U32.interactable = false;
        S2U33.interactable = false;
        /*S3U31.interactable = false;
        S3U32.interactable = false;
        S3U33.interactable = false;*/
    }

    public void OpenSkillUp()
    {
        SkillUpWindow.SetActive(true);
    }

    public void CloseSkillUp()
    {
        SkillUpWindow.SetActive(false);
    }

    public void SkillUp(int iD)
    {
        
        switch(iD)
        {
            #region SkillOne
            case 121:
                S1U21.interactable = false;
                S1U22.interactable = false;
                S1U23.interactable = false;
                S1U31.interactable = true;
                S1U32.interactable = true;
                S1U33.interactable = true;
                SkillOne.SetUpgrade(21, true);
                SkillOne.SetManaCost(21);
                Debug.Log("Upgrade applied!");
                break;
            case 122:
                S1U21.interactable = false;
                S1U22.interactable = false;
                S1U23.interactable = false;
                S1U31.interactable = true;
                S1U32.interactable = true;
                S1U33.interactable = true;
                SkillOne.SetUpgrade(22, true);
                SkillOne.SetManaCost(22);
                Debug.Log("Upgrade applied!");
                break;
            case 123:
                S1U21.interactable = false;
                S1U22.interactable = false;
                S1U23.interactable = false;
                S1U31.interactable = true;
                S1U32.interactable = true;
                S1U33.interactable = true;
                SkillOne.SetUpgrade(23, true);
                SkillOne.SetManaCost(23);
                Debug.Log("Upgrade applied!");
                break;
            case 131:
                S1U31.interactable = false;
                S1U32.interactable = false;
                S1U33.interactable = false;
                SkillOne.SetUpgrade(31, true);
                SkillOne.SetManaCost(31);
                Debug.Log("Upgrade applied!");
                break;
            case 132:
                S1U31.interactable = false;
                S1U32.interactable = false;
                S1U33.interactable = false;
                SkillOne.SetUpgrade(32, true);
                SkillOne.SetManaCost(32);
                Debug.Log("Upgrade applied!");
                break;
            case 133:
                S1U31.interactable = false;
                S1U32.interactable = false;
                S1U33.interactable = false;
                SkillOne.SetUpgrade(33, true);
                SkillOne.SetManaCost(33);
                Debug.Log("Upgrade applied!");
                break;
            case 221:
                S2U21.interactable = false;
                S2U22.interactable = false;
                S2U23.interactable = false;
                S2U31.interactable = true;
                S2U32.interactable = true;
                S2U33.interactable = true;
                SkillTwo.SetUpgrade(21, true);
                SkillTwo.SetManaCost(21);
                Debug.Log("Upgrade applied!");
                break;
            case 222:
                S2U21.interactable = false;
                S2U22.interactable = false;
                S2U23.interactable = false;
                S2U31.interactable = true;
                S2U32.interactable = true;
                S2U33.interactable = true;
                SkillTwo.SetUpgrade(22, true);
                SkillTwo.SetManaCost(22);
                Debug.Log("Upgrade applied!");
                break;
            case 223:
                S2U21.interactable = false;
                S2U22.interactable = false;
                S2U23.interactable = false;
                S2U31.interactable = true;
                S2U32.interactable = true;
                S2U33.interactable = true;
                SkillTwo.SetUpgrade(23, true);
                SkillTwo.SetManaCost(23);
                Debug.Log("Upgrade applied!");
                break;
            default:
                Debug.Log("There's no such Skill!");
                return;
            #endregion
        }

        SkillUpWindow.SetActive(false);
        restSite.SkillUpgraded();
    }

    #endregion
}
