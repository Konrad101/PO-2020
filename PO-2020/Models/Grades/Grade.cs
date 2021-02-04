namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public enum Grade
    {
        Grade20, Grade30, Grade35, Grade40, Grade45, Grade50, Grade55, None
    }

    public class GradeConverter
    {
        public static double ParseGrade(Grade grade)
        {
            switch (grade)
            {
                case Grade.Grade20:
                    return 2.0;
                case Grade.Grade30:
                    return 3.0;
                case Grade.Grade35:
                    return 3.5;
                case Grade.Grade40:
                    return 4.0;
                case Grade.Grade45:
                    return 4.5;
                case Grade.Grade50:
                    return 5.0;
                case Grade.Grade55:
                    return 5.5;
                default:
                    return 0;
            }

        }

        public static Grade GetGrade(float gradeValue)
        {
            switch (gradeValue)
            {
                case 2:
                    return Grade.Grade20;
                case 3.0f:
                    return Grade.Grade30;
                case 3.5f:
                    return Grade.Grade35;
                case 4.0f:
                    return Grade.Grade40;
                case 4.5f:
                    return Grade.Grade45;
                case 5.0f:
                    return Grade.Grade50;
                case 5.5f:
                    return Grade.Grade55;
                default:
                    return Grade.None;
            }

        }

        public static Grade GetGradeString(string gradeValue)
        {
            switch (gradeValue)
            {
                case "Grade20":
                    return Grade.Grade20;
                case "Grade30":
                    return Grade.Grade30;
                case "Grade35":
                    return Grade.Grade35;
                case "Grade40":
                    return Grade.Grade40;
                case "Grade45":
                    return Grade.Grade45;
                case "Grade50":
                    return Grade.Grade50;
                case "Grade55":
                    return Grade.Grade55;
                default:
                    return Grade.None;
            }

        }
    }
}
