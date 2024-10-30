namespace TaskBoardApp_v3.Data.Common
{
    public static class DataConstants
    {
        public const int TaskTitleMinLength = 5;
        public const int TaskTitleMaxLength = 70;

        public const int TaskDesrriptionMinLength = 10;
        public const int TaskDescriptionMaxLength = 1000;

        public const string TaskInputLengthErrorMsg = "{0} should be between {2} and {1} charcters long.";
        public const string TaskDateTimeFormat = "dd/MM/yyyy HH:mm";

        public const int BoardNameMinLength = 3;
        public const int BoardNameMaxLength = 30;

        public const string MissingBoardErrorMsg = "Board does not exist!";
    }
}
