using System;
using System.ComponentModel.DataAnnotations;

namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class FinalThesisReview
    {
        [Required]
        public int FormId { get; set; }
        public string TitleCompability { get; set; }
        public string ThesisStructureComment { get; set; }
        public string NewProblem { get; set; }
        public string SourcesUse { get; set; }
        public string FormalWorkSide { get; set; }
        public string WayToUse { get; set; }
        public string SubstantiveThesisGrade { get; set; }
        public string ThesisGrade { get; set; } = "Brak";

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FormDate { get; set; } = null;
        public ThesisStatus FormStatus { get; set; }
        public FinalThesis FinalThesis { get; set; }
    }
}