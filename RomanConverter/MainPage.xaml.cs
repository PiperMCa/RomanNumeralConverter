
using Roman;
namespace RomanConverter;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }
    
    private void BtnClear_OnClicked(object sender, EventArgs e)
    {
        txtInput.Text = "";
        lblOutput.Text = "---";
    }

    private void TxtInput_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        Converter converter = new Converter(); // Week 4
        string strResult;
        if (Int32.TryParse(txtInput.Text, out int number))
        {
            // Number to Roman
            strResult = converter.NumberToRoman(number);

        }
        else
        {
            // Roman to Number
            strResult = converter.RomanToNumber(txtInput.Text).ToString();

        }

        var xxx = strResult.Length;
        if (strResult == "-1")
        {
            strResult = "This cannot be converted. Please enter a whole number or a proper Roman Numeral";
        }

        int yyy = lblOutput.Text.Length;
        if (yyy > 48) 
        {
            int notMPos = strResult.LastIndexOf("M");
            if (notMPos != 0)
            {
                // Shortening numeral length
                string rest = strResult.Substring(notMPos + 1);
                strResult = "M^" + (notMPos + 1) + rest;
            }
            else
            {
                lblOutput.Text = "Value is too large to display";   
            }
        }
        lblOutput.Text = strResult;
    }
}