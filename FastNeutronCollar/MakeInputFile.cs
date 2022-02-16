using System;
using System.Collections.Generic;
using System.IO;
using GlobalHelpers;

namespace FastNeutronCollar
{
    public class MakeInputFile
    {
        private readonly string mcnPinputFile;
        private readonly List<string> description;
        private StreamWriter stream;

        private readonly List<IComponentSpecification> components;

        //private readonly ParticleImportance particleImportance;
        private readonly int nParticles;
        private const string END_OF_FILE = "END OF FILE";
        private const string SOURCE_CARD = "SOURCES";
        private const string TRANSFORM_CARD = "TRANSFORMATIONS";
        private const string SURFACE_CARD = "SURFACES";

        private const string CELL_CARD = "CELLS";

        //  private readonly PoliMiSource poliMiSource;
        private SourceSpecification sourceSpecification;

        private readonly bool useComponentSource;

        public MakeInputFile(string MCNPinputFile, List<string> Description, List<IComponentSpecification> Components,
            int NumParticlesToRun) //, Particle ParticleInProblem )//= GlobalDefaults.ParticleInProblem)
        {
            mcnPinputFile = MCNPinputFile;
            description = Description;
            components = Components;
            nParticles = NumParticlesToRun;
            //   particleImportance = Particle;
            useComponentSource = true;
            //SetDefaultParticle()
            //  SetParticleForProblem(ParticleInProblem);
        }

        //private void SetParticleForProblem(Particle particleInProblem)
        //{
        //    GlobalDefaults.SetParticleImportance(particleInProblem);
        //}

        public MakeInputFile(string MCNPinputFile, List<string> Description, List<IComponentSpecification> Components,
            SourceSpecification sourceTerm,
            int NumParticlesToRun) //  Particle ParticleInProblem)// = GlobalDefaults.ParticleInProblem)
        {
            mcnPinputFile = MCNPinputFile;
            description = Description;
            components = Components;
            nParticles = NumParticlesToRun;
            //   particleImportance = Particle;
            sourceSpecification = sourceTerm;
            useComponentSource = false;
            // SetParticleForProblem(ParticleInProblem);
        } //

        public void WriteFile()
        {
            stream = new StreamWriter(mcnPinputFile);

            WriteHeader();
            MakeComponents();
            WriteCells();
            BlankLineDelimiter();

            WriteSurfaces();
            BlankLineDelimiter();

            WriteSource();

            WriteMaterials();
            WriteTransformations();
            WriteDataCard();
            WritePoliMi();
            BlankLineDelimiter();

            WriteEndOfFile();

            stream.Close();
        }

        //public List<int> GetDetectorCells()
        //{
        //    return PoliMiInputHelper.GetAllDetectorsForPoliMi();
        //}

        private void WriteEndOfFile()
        {
            WriteToStream(MCNPformatHelper.GetCommentLine(END_OF_FILE));
        }

        private void WriteDataCard()
        {
            WriteToStream(DataCardHelper.GetDataCard(nParticles, GlobalDefaults.ParticleInProblem));
        }

        private void WriteSource()
        {
            WriteToStream(MCNPformatHelper.GetCommentLine(SOURCE_CARD));
            if (useComponentSource)
            {
                GetSourceFromComponent();
            }

            //else
            //{
            WriteSourceBySpecification();
            // }
        }

        private void GetSourceFromComponent()
        {
            foreach (var s in components)
            {
                if (s.HasSourceTerm())
                {
                    sourceSpecification = s.GetSource();
                    break;
                }
            }
        }

        private void WriteSourceBySpecification()
        {
            WriteToStream(MCNPformatHelper.FormatLines(sourceSpecification.SourceDefinition));
        }

        private void BlankLineDelimiter()
        {
            stream.WriteLine(string.Empty);
        }

        private void WritePoliMi()
        {
            //if (useComponentSource)
            //{
            //    WriteToStream(PoliMiInputHelper.GetPoliMiLinesSource(poliMiSource));
            //}
            //else
            //{
            WriteToStream(PoliMiMPPostInputHelper.GetPoliMiLinesSource(sourceSpecification.SourcePoliMi));
            //}
        }

        private void WriteMaterials()
        {
            WriteToStream(WriterHelper.GetMaterialCard()); //, false);
        }

        private void WriteToStream(string line)
        {
            WriteFormatedToStream(MCNPformatHelper.FormatLines(line));
        }

        private void WriteFormatedToStream(List<string> formatedLines)
        {
            foreach (var f in formatedLines)
            {
                stream.WriteLine(f);
            }
        }

        private void WriteToStream(List<string> lines)
        {
            WriteFormatedToStream(MCNPformatHelper.FormatLines(lines));
        }

        private void WriteTransformations()
        {
            WriteToStream(MCNPformatHelper.GetCommentLine(TRANSFORM_CARD));
            foreach (var c in components)
            {
                List<string> transformations = c.GetTransformations();
                foreach (var t in transformations)
                {
                    if (!string.IsNullOrEmpty(t))
                    {
                        WriteToStream(t);
                    }
                }
            }
        }

        private void WriteSurfaces()
        {
            WriteToStream(MCNPformatHelper.GetCommentLine(SURFACE_CARD));
            WriteWorldSurface();
            foreach (var s in components)
            {
                WriteToStream(MCNPformatHelper.FormatLines(s.GetSurfaces()));
            }
        }

        private void WriteWorldSurface()
        {
            WriteToStream(GlobalDefaults.EXTERNAL_WORLD + " " +
                          McnpSurfaces.GetSphere(GlobalDefaults.CENTER, GlobalDefaults.WORLD_RADIUS) + " " +
                          MCNPformatHelper.GetInLineComment(GlobalDefaults.EXTERNAL_WORLD_COMMENT));
        }

        private void WriteWorldCells()
        {
            WriteToStream(GlobalDefaults.EXTERNAL_WORLD + " " +
                          MaterialManager.GetMaterial(MaterialManager.VOID).ToCell() + " " +
                          GlobalDefaults.EXTERNAL_WORLD + " " +
                          UniverseAndImportanceHelper.UniverseAndImportance(GlobalDefaults.ExternalParticleImportance) +
                          " " +
                          MCNPformatHelper.GetInLineComment(GlobalDefaults.EXTERNAL_WORLD_COMMENT));

            WriteToStream(GlobalDefaults.INTERNAL_WORLD + " " +
                          MaterialManager.GetMaterial(GlobalDefaults.FillMaterial).ToCell() +
                          " -" + GlobalDefaults.EXTERNAL_WORLD + " " + GetExternalBoundaries() + " " +
                          UniverseAndImportanceHelper.UniverseAndImportance(GlobalDefaults.ParticleInProblem) + " " +
                          MCNPformatHelper.GetInLineComment(GlobalDefaults.INTERNAL_WORLD_COMMENT));
        }

        private string GetExternalBoundaries()
        {
            string externalCells = "";
            foreach (var c in components)
            {
                foreach (var s in c.GetExternalSurfaces())
                {
                    externalCells += " " + s;
                }
            }

            return externalCells;
        }

        private void WriteCells()
        {
            WriteToStream(MCNPformatHelper.GetCommentLine(CELL_CARD));
            WriteWorldCells();
            foreach (var s in components)
            {
                WriteToStream(MCNPformatHelper.FormatLines(s.GetCells()));
            }
        }

        private void MakeComponents()
        {
            foreach (var c in components)
            {
                c.MakeComponent();
            }
        }

        private void WriteHeader()
        {
            WriteToStream(
                MCNPformatHelper.GetCommentLine(Environment.UserName.ToString() + " " + DateTime.Now.ToString()));
            WriteToStream(MCNPformatHelper.GetCommentLine(string.Empty));
            foreach (string d in description)
            {
                if (!string.IsNullOrWhiteSpace(d))
                {
                    WriteToStream(MCNPformatHelper.GetCommentLine(d));
                }
            }

            WriteToStream(MCNPformatHelper.GetCommentLine(string.Empty));
        }
    }
}
