using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomainLayer.Models.ThinkEE;
using RavenTech_ERP.Helpers;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.WinForms.Controls;

namespace RavenTech_ERP.Views.UserControls.ThinkEE;
public partial class QuestionsControl : UserControl
{
    private readonly int _number;
    private Question _question;
    private List<RadioButtonAdv> choiceButtons;
    public event EventHandler<ChoiceSelectedEventArgs> ChoiceSelected;
    private Choice _selectedChoice;
    public QuestionsControl(int number, Question question)
    {
        InitializeComponent();

        this._number = number;
        this._question = question;
        choiceButtons = new List<RadioButtonAdv> { btnChoice1, btnChoice2, btnChoice3, btnChoice4 };


        foreach (var btn in choiceButtons)
        {
            btn.CheckChanged += Choice_CheckedChanged;
        }
        LoadQuestion();
    }
    public void SelectChoice(Choice choice)
    {
        foreach (var btn in choiceButtons)
        {
            if (btn.Tag == choice)
            {
                btn.Checked = true;
            }
            else
            {
                btn.Checked = false;
            }
        }
    }

    protected virtual void OnChoiceSelected(Choice choice)
    {
        ChoiceSelected?.Invoke(this, new ChoiceSelectedEventArgs { SelectedChoice = choice });
    }

    private void Choice_CheckedChanged(object sender, EventArgs e)
    {
        var radioBtn = sender as RadioButtonAdv;
        if (radioBtn != null && radioBtn.Checked && radioBtn.Tag is Choice choice)
        {
            _selectedChoice = choice;
            OnChoiceSelected(choice);
        }
    }

    private void LoadQuestion()
    {
        lblQuestionNo.Text = $"Question # {_number}";
        lblQuestionText.Text = _question.Text;

        var choicesList = _question.Choices.ToList();

        for (int i = 0; i < choiceButtons.Count; i++)
        {
            if (i < choicesList.Count)
            {
                choiceButtons[i].Tag = choicesList[i];
                choiceButtons[i].Text = choicesList[i].Text;
                //choiceButtons[i].Checked = choicesList[i].
                choiceButtons[i].Visible = true;
            }
            else
            {
                // Hide unused buttons if there are fewer than 4 choices
                choiceButtons[i].Visible = false;
            }

        }
    }
}
