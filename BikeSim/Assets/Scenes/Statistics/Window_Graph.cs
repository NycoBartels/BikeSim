using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class Window_Graph : MonoBehaviour
{

    [SerializeField] private Sprite circleSprite;

    private RectTransform labelTemplateX;
    private RectTransform labelTemplateY;

    private RectTransform dashTemplateX;
    private RectTransform dashTemplateY;

    private RectTransform graphContainer;
    private void Awake() {
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();
        dashTemplateX = graphContainer.Find("dashTemplateX").GetComponent<RectTransform>();
        dashTemplateY = graphContainer.Find("dashTemplateY").GetComponent<RectTransform>();

        List<int> valueList = new List<int>() { 70, 12, 18, 68, 43, 21, 62, 36 };

        List<int> scoreList = 

        ShowGraph(valueList);
        ShowGraph(scoreList);
    }

    private GameObject CreateCircle(Vector2 anchoredPosition) {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(11, 11);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);

        return gameObject;
    }

    private void ShowGraph(List<int> valueList) {
        //graph show multiplier
        float graphHeight = graphContainer.sizeDelta.y;
        float yMaximum = 100f; //define top height of graph
        float xSize = 50f;

        GameObject lastCircleGameObject = null;
        for (int i = 0; i < valueList.Count; i++) {
            float xPosition = xSize + i * xSize;
            float yPosition = (valueList[i] / yMaximum) * graphHeight;
            GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));

            if (lastCircleGameObject != null) {
                CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
            }

            lastCircleGameObject = circleGameObject;

            //spawn x axis labels
            RectTransform labelX = Instantiate(labelTemplateX);
            labelX.SetParent(graphContainer, false);
            labelX.gameObject.SetActive(true);
            labelX.anchoredPosition = new Vector2(xPosition, -20f);
            labelX.GetComponent<Text>().text = i.ToString();

            //spawn dash X lines 
            RectTransform dashX = Instantiate(dashTemplateX);
            dashX.SetParent(graphContainer, false);
            dashX.gameObject.SetActive(true);
            dashX.anchoredPosition = new Vector2(xPosition, -20f);
        }

        //spawn y axis labels
        int separatorCount = 10;
        for (int i = 0; i <= separatorCount; i++) {
            RectTransform labelY = Instantiate(labelTemplateX);
            labelY.SetParent(graphContainer, false);
            labelY.gameObject.SetActive(true);
            float normalizedValue = i * 1f / separatorCount;
            labelY.anchoredPosition = new Vector2(-20f, normalizedValue * graphHeight);
            labelY.GetComponent<Text>().text = Mathf.RoundToInt(normalizedValue * yMaximum).ToString();

            //spawn dash Y lines 
            RectTransform dashY = Instantiate(dashTemplateY);
            dashY.SetParent(graphContainer, false);
            dashY.gameObject.SetActive(true);
            dashY.anchoredPosition = new Vector2(-4f, normalizedValue * graphHeight);
        }
    }

    private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB) {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, .5f);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 3f);
        rectTransform.anchoredPosition = dotPositionA + dir * distance * .5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(dir));
    }

}
