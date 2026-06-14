using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGPanel : MonoBehaviour
{
    private static int CurrentPageIndex;
    private const int TotalPages=7;
    private const int TotalSlots = 28;
    private const int SlotsPerPage = TotalSlots / TotalPages;
    private int VisualIndex;
    private int TrueIndex;
    private GameObject CGBoxPrefab;
    private List<CGContainer> CGContainers;
    private AllCGs CGs;
    private void OnEnable()
    {
        CurrentPageIndex = 0;
        EventBus.Subscribe<RequestPageUpEvent>(PrevPage);
        EventBus.Subscribe<RequestPageDownEvent>(NextPage);
        CGBoxPrefab = Resources.Load<GameObject>("Prefab/CGContainer");
        CGs =Resources.Load<AllCGs>("AllCGs");
        CreatBox();
    }
    private void OnDisable()
    {
        EventBus.UnSubscribe<RequestPageUpEvent>(PrevPage);
        EventBus.UnSubscribe<RequestPageDownEvent>(NextPage);
        ClearBox();
    }
    private void Refresh()
    {
        for (int i = 0; i < SlotsPerPage; i++)
        {
            TrueIndex = VisualIndexToTrueIndex(CurrentPageIndex,i);
            if (TrueIndex < CGs.CGs.Count)
            {
                CGContainers[i].SetCG(CGs.CGs[TrueIndex]);
                Debug.Log($"TrueIndex:{TrueIndex}");
            }
            else
            {
                CGContainers[i].SetCG(null);
            }
        }
    }
    public int VisualIndexToTrueIndex(int currentPage,int Vindex)
    {
        return(currentPage * SlotsPerPage + Vindex);
    }
    public int TrueIndexToVisualIndex(int Tindex)
    {
        return (Tindex % SlotsPerPage);
    }
    public void NextPage(RequestPageDownEvent e)
    {
        if(CurrentPageIndex < TotalPages - 1)
        {
            CurrentPageIndex++;
        }
        Refresh();
    }
    public void PrevPage(RequestPageUpEvent e)
    {
        if (CurrentPageIndex > 0)
        {
            CurrentPageIndex--;
        }
        Refresh();
    }
    private void CreatBox()
    {
        CGContainers = new List<CGContainer>();//逻辑对象，CGBox脚本的对象列表
        for(short i = 0; i < SlotsPerPage; i++)
        {
            GameObject box = Instantiate(CGBoxPrefab, transform); //根据预制体克隆的物理对象gameObject
            CGContainer cgBox = box.GetComponent<CGContainer>();//一个具体逻辑对象实例
            CGContainers.Add(cgBox);//把具体对象实例加进列表
        }
        Refresh();
    }
    private void ClearBox()
    {
        if (CGContainers == null)
        {
            Debug.Log("CGContainers is null");
            return;
        }
        foreach(var box in CGContainers)
        {
            Destroy(box.gameObject);
        }
        CGContainers.Clear();
    }
}
