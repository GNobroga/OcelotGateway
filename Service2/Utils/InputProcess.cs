namespace Service2.Utils;

public static class InputProcess 
{
    public static string ApplyMask(string value)
    {
        char[] mask = { '0', '0', '0', '0', '-', '0' };

        value = new string(value.Trim().Where(char.IsDigit).ToArray());

        char last = value[^1];

        int diff = mask.Length - value.Length;
        int currentIndex = diff == mask.Length - 1 ? mask.Length - 1 : diff - 1;
        string newValue = value.Substring(0, value.Length - 1);

        if (!string.IsNullOrEmpty(newValue))
        {
            char[] split = new string(newValue.Reverse().ToArray()).ToCharArray();
            int splitIndex = 0;

            // Gambiarra do Biel
            for (int i = currentIndex + 1; i < mask.Length; i++)
            {
                if (split.Length <= splitIndex)
                    break;

                if (mask[i] == '-')
                {
                    mask[i + 1] = split[splitIndex];
                }
                else
                {
                    mask[i] = split[splitIndex];
                }
                splitIndex++;
            }
        }

        mask[currentIndex] = last;

        return new string(mask);
    }
}