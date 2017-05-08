using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUIText : MonoBehaviour
{
    public Text honorText;

    public Text copperText;
    public Text tinText;
    public Text ironText;
    public Text coalText;
    public Text steelText;
    public Text goldText;
    public Text titaniumText;
    public Text diamondText;
    public Text meteoriteText;

    public Text logsText;
    public Text oakLogsText;
    public Text willowLogsText;
    public Text yewLogsText;
    public Text elderLogsText;

    public Text concreteText;
    public Text bricksText;

    public Text happinessText;
    public Text cultureText;
    public Text scienceText;

    void Update ()
	{
	    honorText.text = "Arbitrary Numbers : " + ResourceContainer.Instance.Honor.ToString();

        copperText.text = "Copper : " + ResourceContainer.Instance.Copper.ToString();
        tinText.text = "Tin : " + ResourceContainer.Instance.Tin.ToString();
        ironText.text = "Iron : " + ResourceContainer.Instance.Iron.ToString();
        coalText.text = "Coal : " + ResourceContainer.Instance.Coal.ToString();
        steelText.text = "Steel : " + ResourceContainer.Instance.Steel.ToString();
        goldText.text = "Gold : " + ResourceContainer.Instance.Gold.ToString();
        titaniumText.text = "Titanium : " + ResourceContainer.Instance.Titanium.ToString();
        diamondText.text = "Diamond : " + ResourceContainer.Instance.Diamond.ToString();
        meteoriteText.text = "Meteorite : " + ResourceContainer.Instance.Meteorite.ToString();

        logsText.text = "Logs : " + ResourceContainer.Instance.Logs.ToString();
        oakLogsText.text = "Oak Logs : " + ResourceContainer.Instance.OakLogs.ToString();
        willowLogsText.text = "Willow Logs : " + ResourceContainer.Instance.WillowLogs.ToString();
        yewLogsText.text = "Yew Logs : " + ResourceContainer.Instance.YewLogs.ToString();
        elderLogsText.text = "Elder Logs : " + ResourceContainer.Instance.ElderLogs.ToString();

        concreteText.text = "Concrete : " + ResourceContainer.Instance.Concrete.ToString();
        bricksText.text = "Bricks : " + ResourceContainer.Instance.Bricks.ToString();

        happinessText.text = "Happiness : " + ResourceContainer.Instance.Happiness.ToString();
        cultureText.text = "Culture : " + ResourceContainer.Instance.Culture.ToString();
        scienceText.text = "Science : " + ResourceContainer.Instance.Science.ToString();

    }
}
