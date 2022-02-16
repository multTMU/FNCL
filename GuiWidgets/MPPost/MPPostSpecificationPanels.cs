using System.Windows.Forms;
using PoliMiRunner;

namespace GuiWidgets.MPPost
{
    public partial class MPPostSpecificationPanels : UserControl
    {
        public MPPostSpecificationPanels()
        {
            InitializeComponent();
        }

        public void SetDetector(MPPostSpecification detector)
        {
            this.captureEvents1.Set(detector.captureEvents);
            this.captureGatedDetector1.Set(detector.captureGatedDetector);
            this.correlations1.Set(detector.correlations);
            this.deadTime1.Set(detector.deadTimeNanoSeconds);
            this.detectorInformation1.Set(detector.detectorInformation);
            this.detectorPulseHeight1.Set(detector.detectorPulseHeight);
            this.fileIO1.Set(detector.fileIO);
            this.generalInfo1.Set(detector.generalInfo);
            this.he3Module1.Set(detector.he3Module);
            this.lightResolution1.Set(detector.lightResolution);
            this.memory1.Set(detector.memory);
            this.organicScintillator1.Set(detector.organicScintillator);
            this.timeResolution1.Set(detector.timeResolution);
            this.pulseGeneration1.Set(detector.pulseGenerationTime);
            this.pulseHeightCorrelation1.Set(detector.pulseHeightCorrelation);
        }

        private MPPostSpecification getDetectorFromForm()
        {
            return new MPPostSpecification
            {
                captureEvents = this.captureEvents1.Get(),
                captureGatedDetector = this.captureGatedDetector1.Get(),
                pulseHeightCorrelation = this.pulseHeightCorrelation1.Get(),
                correlations = this.correlations1.Get(),
                timeResolution = this.timeResolution1.Get(),
                lightResolution = this.lightResolution1.Get(),
                organicScintillator = this.organicScintillator1.Get(),
                deadTimeNanoSeconds = this.deadTime1.Get(),
                pulseGenerationTime = this.pulseGeneration1.Get(),
                detectorPulseHeight = this.detectorPulseHeight1.Get(),
                detectorInformation = this.detectorInformation1.Get(),
                memory = this.memory1.Get(),
                fileIO = this.fileIO1.Get(),
                generalInfo = this.generalInfo1.Get(),
                he3Module = this.he3Module1.Get()
            };
        }

        public MPPostSpecification GetDetector()
        {
            return getDetectorFromForm();
        }
    }
}
