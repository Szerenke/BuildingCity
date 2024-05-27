using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildManager : MonoBehaviour
{
    [SerializeField] protected List<Button> addButtons;
    [SerializeField] protected TextMeshProUGUI elemetsCountText;

    [SerializeField] protected GameObject bench;
    [SerializeField] protected GameObject lamp;
    [SerializeField] protected GameObject tree;

    private int benchCount = 0;
    private int lampCount = 0;
    private int treeCount = 0;
    private string prefabName;

    // Start is called before the first frame update
    void Start()
    {
        SetElemetCountText();

        foreach (Button button in addButtons)
        {
            button.onClick.AddListener(() => AddPrefab(button));
        }
    }
    
    void AddPrefab(Button button)
    {
        prefabName = button.tag.ToString();

        switch (prefabName)
        {
            case "bench":
                benchCount = CreatePrefabObject(bench, benchCount, Consts.BenchLimit);
                break;
            case "lamp":
                lampCount = CreatePrefabObject(lamp, lampCount, Consts.LampLimit);
                break;
            case "tree":
                treeCount = CreatePrefabObject(tree, treeCount, Consts.TreeLimit);
                break;
            default: break;
        }

        SetElemetCountText();
    }

    int CreatePrefabObject(GameObject gameObject, int count, int limit)
    {
        if (count < limit)
        {
            Instantiate(gameObject, gameObject.transform.position, gameObject.transform.rotation);
            count++;
        }
        return count;
    }

    void SetElemetCountText()
    {
        elemetsCountText.text = string.Format("Trees: {0}/{1}\nLamps: {2}/{3}\nBenches: {4}/{5}",
            treeCount, Consts.TreeLimit, lampCount, Consts.LampLimit, benchCount, Consts.BenchLimit);
    }

}
