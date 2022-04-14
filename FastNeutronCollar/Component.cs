using System.Collections.Generic;
using GeometrySampling;
using GlobalHelpers;

namespace FastNeutronCollar
{
    public interface IComponentSpecification
    {
        void MakeComponent();
        List<string> GetCells();
        List<string> GetSurfaces();
        List<string> GetTransformations();
        List<string> GetExternalSurfaces();
        SourceSpecification GetSource();
        bool HasSourceTerm();
    }

    public abstract class Component : IComponentSpecification
    {
        protected readonly string comment;
        protected List<string> ExternalSurfaces;
        protected readonly int primaryIndex;
        protected List<IComponentSpecification> subComponents;
        protected MyPoint3D center;
        protected readonly bool topLevel;
        protected bool hasSourceTerm;
        protected PoliMiSource poliMiSource;

        private List<string> Cells;
        private List<string> Surfaces;
        private List<string> Transformations;

        private const int MAKE_INTERIOR = -1;
        private const char UNION = ':';
        private const char GROUP_LEFT = '(';
        private const char GROUP_RIGHT = ')';
        private const char COMPLIMENT = '#';

        public Component(int mcnpIndex, string Comment, bool TopLevel = false)
        {
            primaryIndex = mcnpIndex;
            comment = Comment;
            topLevel = TopLevel;
            poliMiSource = PoliMiSource.None;
        }

        public void MakeComponent()
        {
            InitializeLists();
            InitializeSubComponents();
            RunSubComponents();
            Surfaces.AddRange(MakeSurfaces());
            Cells.AddRange(MakeCells());
            Transformations.AddRange(MakeTransformations());
            ExternalSurfaces.AddRange(MakeExternalSurfaces());
        }

        public List<string> GetCells()
        {
            return Cells;
        }

        public List<string> GetSurfaces()
        {
            return Surfaces;
        }

        public List<string> GetTransformations()
        {
            return Transformations;
        }

        public List<string> GetExternalSurfaces()
        {
            return ExternalSurfaces;
        }

        public virtual SourceSpecification GetSource()
        {
            foreach (var c in subComponents)
            {
                if (c.HasSourceTerm())
                {
                    return c.GetSource();
                }
            }

            return SourcesHelper.NoSource;
        }

        public bool HasSourceTerm()
        {
            foreach (var c in subComponents)
            {
                if (c.HasSourceTerm())
                {
                    return true;
                }
            }

            return hasSourceTerm;
        }

        public string GetComments(bool withInLineComment = true, string additionalComment = "")
        {
            if (withInLineComment)
            {
                return MCNPformatHelper.GetInLineComment(comment + " " + additionalComment);
            }

            return comment;
        }

        //protected bool IsPoliMiSourceDefined()
        //{
        //    return poliMiSource != PoliMiSource.None;
        //}

        //protected virtual SourceSpecification MakeSources()
        //{
        //    SourceSpecification sourceTerm = new SourceSpecification();
        //    foreach (var comp in subComponents)
        //    {
        //        if (comp.HasSourceTerm())
        //        {
        //            sourceTerm = comp.GetSource();
        //            break;
        //        }
        //    }

        //    return sourceTerm;
        //}

        //protected static string GetSurface(int ine)
        //{

        //}

        protected virtual List<string> MakeExternalSurfaces()
        {
            List<string> external = new List<string>();
            foreach (var comp in subComponents)
            {
                external.AddRange(comp.GetExternalSurfaces());
            }

            return external;
        }

        protected virtual List<string> MakeTransformations()
        {
            List<string> transforms = new List<string>();
            foreach (var comp in subComponents)
            {
                transforms.AddRange(comp.GetTransformations());
            }

            return transforms;
        }

        private void InitializeLists()
        {
            Surfaces = new List<string>();
            Cells = new List<string>();
            Transformations = new List<string>();
            //Sources = new List<string>();
            ExternalSurfaces = new List<string>();
            subComponents = new List<IComponentSpecification>();
        }

        private void RunSubComponents()
        {
            foreach (var comp in subComponents)
            {
                comp.MakeComponent();
            }
        }

        protected virtual void InitializeSubComponents()
        {
        }

        protected virtual List<string> MakeCells()
        {
            List<string> cells = new List<string>();
            if (topLevel)
            {
                cells.Add(GetTopLevelComment());
            }

            foreach (var comp in subComponents)
            {
                cells.AddRange(comp.GetCells());
            }

            return cells;
        }

        protected string GetTopLevelComment()
        {
            return MCNPformatHelper.GetCommentLine(GetComments(false));
        }

        protected virtual List<string> MakeSurfaces()
        {
            List<string> surfaces = new List<string>();
            if (topLevel)
            {
                surfaces.Add(GetTopLevelComment());
            }

            foreach (var comp in subComponents)
            {
                surfaces.AddRange(comp.GetSurfaces());
            }

            return surfaces;
        }

        protected int GetInteriorIndexBase(int addToBaseIndex = 0)
        {
            return GetInside(GetIndex(addToBaseIndex));
        }

        protected int GetInside(int indexOfSurface)
        {
            return MAKE_INTERIOR * indexOfSurface;
        }

        protected int GetIndex(int addToBaseIndex = 0)
        {
            return (primaryIndex + addToBaseIndex);
        }

        protected string GetCellImportanceAndComments(string additionalComment = "")
        {
            return " " + UniverseAndImportanceHelper.UniverseAndImportance() + " " +
                   GetComments(additionalComment: additionalComment);
        }

        protected static string GetCompliment(int complimentSurface)
        {
            return COMPLIMENT.ToString() + complimentSurface;
        }

        protected static string GetUnion(List<int> unionSurfaces)
        {
            string union = GROUP_LEFT.ToString();
            foreach (var u in unionSurfaces)
            {
                union += u + UNION.ToString();
            }

            union = union.TrimEnd(UNION);
            union += GROUP_RIGHT.ToString();
            return union;
        }
    }
}
