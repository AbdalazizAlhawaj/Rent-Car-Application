namespace RentCarApp.Services
{
    //  الفئة الساكنة للتحقق من البيانات 
    public static class Validator
    {
        public static bool ValidateNonEmpty(string s) => !string.IsNullOrWhiteSpace(s);
        public static bool ValidatePositive(double value) => value > 0;
    }
}
