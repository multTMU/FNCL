using System;
using System.Windows.Forms;
using GuiInterface;

namespace GuiWidgets
{
    public partial class PulseFileInformation : UserControl
    {
        public PulseFileInformation()
        {
            InitializeComponent();
        }

        public void SetCreation(DateTime dateTime)
        {
            labelCreation.Text = dateTime.ToString();
        }

        public void SetSize(int sizeMB)
        {
            labelSizeMB.Text = sizeMB.ToString();
        }

        public void SetNumberPulses(int numberPulses)
        {
            labelNumberPulses.Text = numberPulses.ToString();
        }

        public void SetCountTime(double countTime)
        {
            labelCountTime.Text = MultiplicityInterfaceHelper.ConvertNanoSecToSeconds(countTime).ToString();
        }

        public void SetPulseType(string pulseType)
        {
            labelPulseFileType.Text = pulseType;
        }

        public void SetNumberPulsesFiltered(int numberPulses)
        {
            labelFilterNumberPulses.Text = numberPulses.ToString();
        }

        public void SetCountTimeFiltered(double countTime)
        {
            labelFilterCountTime.Text = MultiplicityInterfaceHelper.ConvertNanoSecToSeconds(countTime).ToString();
        }
    }
}
