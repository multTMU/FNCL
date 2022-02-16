using System;
using System.Windows.Forms;
using GlobalHelpersDefaults;

namespace GuiWidgets
{
    public partial class ParticleSelector : UserControl
    {
        private Particle particle;

        public ParticleSelector()
        {
            InitializeComponent();
            particle = Particle.Undetermined;
        }

        public void DisableBothOption()
        {
            rbBoth.Enabled = false;
        }

        public Particle GetParticle()
        {
            return particle;
        }

        private void rbNeutron_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNeutron.Checked)
            {
                particle = Particle.Neutron;
            }
        }

        public void SetDefault(Particle defaultParticle)
        {
            particle = defaultParticle;
            switch (particle)
            {
                case Particle.Undetermined:
                    break;
                case Particle.Neutron:
                    rbNeutron.Checked = true;
                    break;
                case Particle.Photon:
                    rbPhoton.Checked = true;
                    break;
                case Particle.NeutronAndPhoton:
                    rbBoth.Checked = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void rbPhoton_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPhoton.Checked)
            {
                particle = Particle.Photon;
            }
        }

        private void rbBoth_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBoth.Checked)
            {
                particle = Particle.NeutronAndPhoton;
            }
        }

        public void SetParticle(Particle particleToUse)
        {
            SetDefault(particleToUse);
        }
    }
}
