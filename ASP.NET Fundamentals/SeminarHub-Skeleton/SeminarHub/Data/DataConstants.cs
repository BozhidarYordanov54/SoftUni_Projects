namespace SeminarHub.Data
{
    public class DataConstants
    {
        public class SeminarConstants
        {
            public const int TopicMinLength = 3;
            public const int TopicMaxLength = 100;

            public const int LecturerMinLength = 5;
            public const int LecturerMaxLength = 60;

            public const int DetailsMinLength = 10;
            public const int DetailsMaxLength = 500;

            public const string DateFormat = "dd.MM.yyyy HH:mm";

            public const int DurationMin = 30;
            public const int DurationMax = 180;
        }

        public class CategoryConstants
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
        }

        public class ErrorMessages
        {
            public const string RequiredFieldErrorMessage = "The {0} field is required.";
            public const string LengthErrorMessage = "The {0} must be at least {2} characters long.";
            public const string DurationErrorMessage = "The {0} must be between {1} and {2} minutes.";
        }
    }
}
