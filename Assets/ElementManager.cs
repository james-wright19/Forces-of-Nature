using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementManager : MonoBehaviour
{
    public static ElementManager current;

    public int waterLevel;
    public int fireLevel;
    public int earthLevel;
    public int windLevel;

    public int waterLevelChange;
    public int fireLevelChange;
    public int earthLevelChange;
    public int windLevelChange;

    public Text waterText;
    public Text fireText;
    public Text earthText;
    public Text windText;

    public Image waterImage;
    public Image fireImage;
    public Image earthImage;
    public Image windImage;

    public Image waterUp;
    public Image waterDown;
    public Image fireUp;
    public Image fireDown;
    public Image earthUp;
    public Image earthDown;
    public Image windUp;
    public Image windDown;

    public Camera mainCamera;

    void Start()
    {
        if (current)
        {
            Destroy(gameObject);
        }
        else
        {
            current = this;
        }
        mainCamera = Camera.main;
    }

    void Update()
    {
        if(waterLevel > 5)
        {
            GameOver.current.OnGameOver("Area is flooded.");
        }
        if (waterLevel < 0)
        {
            GameOver.current.OnGameOver("Drought comes over the area.");
        }
        if (fireLevel > 5)
        {
            GameOver.current.OnGameOver("You have created hell.");
        }
        if (fireLevel < 0)
        {
            GameOver.current.OnGameOver("The land is too cold to live in.");
        }
        if (earthLevel > 5)
        {
            GameOver.current.OnGameOver("You have been swallowed by the earth.");
        }
        if (earthLevel < 0)
        {
            GameOver.current.OnGameOver("Everything is bland and boring.");
        }
        if (windLevel > 5)
        {
            GameOver.current.OnGameOver("You have been blown away.");
        }
        if (windLevel < 0)
        {
            GameOver.current.OnGameOver("There is no air to breathe.");
        }




        mainCamera.backgroundColor = (new Color(1,0,0) * fireLevel * fireLevel / 5 + new Color(0, 0, 1) * waterLevel * waterLevel / 5 + new Color(0, 1, 0) * earthLevel * earthLevel / 5 + new Color(0.7f, 0.7f, 0.7f) * windLevel * windLevel / 5) / 4;

        waterText.text = waterLevel + "/5";
        fireText.text = fireLevel + "/5";
        windText.text = windLevel + "/5";
        earthText.text = earthLevel + "/5";

        waterImage.fillAmount = waterLevel / 5f;
        fireImage.fillAmount = fireLevel / 5f;
        windImage.fillAmount = windLevel / 5f;
        earthImage.fillAmount = earthLevel / 5f;
        

        if (waterLevel == 5 || waterLevel == 0)
        {
            waterText.color = Color.red;
        }
        else
        {
            waterText.color = Color.black;
        }

        if (fireLevel == 5 || fireLevel == 0)
        {
            fireText.color = Color.red;
        }
        else
        {
            fireText.color = Color.black;
        }

        if (earthLevel == 5 || earthLevel == 0)
        {
            earthText.color = Color.red;
        }
        else
        {
            earthText.color = Color.black;
        }

        if (windLevel == 5 || windLevel == 0)
        {
            Debug.Log("");
            windText.color = Color.red;
        }
        else
        {
            windText.color = Color.black;
        }

        float arrowPosition = 20 + Mathf.Abs(Mathf.Sin(Time.fixedTime * 5) * 5);

        fireUp.rectTransform.localPosition = new Vector3(fireUp.rectTransform.localPosition.x, arrowPosition, fireUp.rectTransform.localPosition.z);
        waterUp.rectTransform.localPosition = new Vector3(waterUp.rectTransform.localPosition.x, arrowPosition, waterUp.rectTransform.localPosition.z);
        earthUp.rectTransform.localPosition = new Vector3(earthUp.rectTransform.localPosition.x, arrowPosition, earthUp.rectTransform.localPosition.z);
        windUp.rectTransform.localPosition = new Vector3(windUp.rectTransform.localPosition.x, arrowPosition, windUp.rectTransform.localPosition.z);
        fireDown.rectTransform.localPosition = new Vector3(fireDown.rectTransform.localPosition.x, -arrowPosition, fireDown.rectTransform.localPosition.z);
        waterDown.rectTransform.localPosition = new Vector3(waterDown.rectTransform.localPosition.x, -arrowPosition, waterDown.rectTransform.localPosition.z);
        earthDown.rectTransform.localPosition = new Vector3(earthDown.rectTransform.localPosition.x, -arrowPosition, earthDown.rectTransform.localPosition.z);
        windDown.rectTransform.localPosition = new Vector3(windDown.rectTransform.localPosition.x, -arrowPosition, windDown.rectTransform.localPosition.z);

        if (fireLevelChange > 0)
        {
            fireDown.gameObject.SetActive(true);
            fireUp.gameObject.SetActive(false);
        }
        else if (fireLevelChange < 0)
        {
            fireDown.gameObject.SetActive(false);
            fireUp.gameObject.SetActive(true);
        }
        else
        {
            fireDown.gameObject.SetActive(false);
            fireUp.gameObject.SetActive(false);
        }
        if (waterLevelChange > 0)
        {
            waterDown.gameObject.SetActive(true);
            waterUp.gameObject.SetActive(false);
        }
        else if (waterLevelChange < 0)
        {
            waterDown.gameObject.SetActive(false);
            waterUp.gameObject.SetActive(true);

        }
        else
        {
            waterDown.gameObject.SetActive(false);
            waterUp.gameObject.SetActive(false);
        }
        if (earthLevelChange > 0)
        {
            earthDown.gameObject.SetActive(true);
            earthUp.gameObject.SetActive(false);
        }
        else if (earthLevelChange < 0)
        {
            earthDown.gameObject.SetActive(false);
            earthUp.gameObject.SetActive(true);
        }
        else
        {
            earthDown.gameObject.SetActive(false);
            earthUp.gameObject.SetActive(false);
        }
        if (windLevelChange > 0)
        {
            windDown.gameObject.SetActive(true);
            windUp.gameObject.SetActive(false);
        }
        else if (windLevelChange < 0)
        {
            windDown.gameObject.SetActive(false);
            windUp.gameObject.SetActive(true);
        }
        else
        {
            windDown.gameObject.SetActive(false);
            windUp.gameObject.SetActive(false);
        }
    }

    public void ChangeFireValue(int numberToAdd)
    {
        fireLevel += numberToAdd;
    }
    public void ChangeWaterValue(int numberToAdd)
    {
        waterLevel += numberToAdd;
    }
    public void ChangeWindValue(int numberToAdd)
    {
        windLevel += numberToAdd;
    }
    public void ChangeEarthValue(int numberToAdd)
    {
        earthLevel += numberToAdd;
    }

    public void TickNaturalErosion()
    {
        waterLevel += waterLevelChange;
        fireLevel += fireLevelChange;
        windLevel += windLevelChange;
        earthLevel += earthLevelChange;

        waterLevelChange = Random.Range(-1, 2);
        fireLevelChange = Random.Range(-1, 2);
        windLevelChange = Random.Range(-1, 2);
        earthLevelChange = Random.Range(-1, 2);
    }
}
