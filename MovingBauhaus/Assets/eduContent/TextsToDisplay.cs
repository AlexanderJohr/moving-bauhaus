using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextsToDisplay : MonoBehaviour {

    public Text displayText;
    public GameObject textBtn;
    List<string> texts = new List<string>();
    int countColl;

    private void Start()
    {
        countColl = 0;

        texts.Add("Wassily (Vasily) Wassilyevich Kandinsky was born in Moscow in 1866 to well educated, upper-class parents of mixed ethnic origins.");
        texts.Add("In 1921 Kandinsky accepted Walter Gropius’ invitation to teach at the Bauhaus in Berlin. His artistic philosophy turned toward the significance of geometric elements.");
        texts.Add("For Kandinsky horizontal lines provide a calm, cold tonality to the basic plane. Vertical lines impart a calm, warm tonality.");
        texts.Add("He strove to convey profound spirituality and the depth of human emotion through a universal visual language of abstract forms and colors that transcended cultural and physical boundaries.");
        texts.Add("'Of all the arts, abstract painting is the most difficult.It demands that you know how to draw well, that you have a heightened sensitivity for composition and for colors, and that you be a true poet.This last is essential.' - Wassily Kandinsky");
    }

    public void DisplayText ()
    {
        displayText.alignment = TextAnchor.UpperLeft;
        displayText.text = texts[countColl];
        //AddCode to print text here
        countColl = countColl + 1;
        textBtn.SetActive(true);
    }
    public void endDisplayText()
    {
        displayText.text = "";
        textBtn.SetActive(false);

    }

}
