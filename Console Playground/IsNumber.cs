namespace Console_Playground
{
  public class LC_IsNumber
  {
    public static bool IsNumber(string s) {
        bool isValid = true;
        s = s.ToLower(); //so we only have to deal with e, not E/e
        return IsDecimal(s) || IsInteger(s);
        return isValid;
    }

    private static bool IsDecimal(string s) {
        string[] split = s.Split('.');
        if(split.Length == 0) {
            return false;
        } else if(split.Length == 1 && s[0] == '.') {
            split[0] = TryRemovePositive(split[0]);
            return IsInteger(split[0]);
        } else if (split.Length == 2) {
            split[0] = TryRemovePositive(split[0]);
            split[1] = TryRemovePositive(split[1]);
            return IsInteger(split[0]) && IsInteger(split[1]);
        } 
        return false;
        
    }

    private static bool IsInteger(string s) {
        string[] split = s.Split('e');
        if(split.Length == 0 || split.All(x => String.IsNullOrEmpty(x))) {
            return false;
        } else if(s[0] == 'e') {
            return false;
        } else if (split.Length == 2) {
            split[0] = TryRemovePositive(split[0]);
            split[1] = TryRemovePositive(split[1]);
            return int.TryParse(split[0], out _) && int.TryParse(split[1], out _) && !IsDecimal(split[1]);
        } else if (split.Length == 1) {
            split[0] = TryRemovePositive(split[0]);
            return int.TryParse(split[0], out _);
        } 
        return false;
    }

    private static string TryRemovePositive(string s) {
        if(s.Length >= 2 && s[0] == '+') {
            s = s.Substring(1, s.Length-1);
        }
        return s;
    }
  }
}
