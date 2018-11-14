using System.Collections.Generic;

namespace MultiLinkBuilder
{
    public static class Builder
    {
        public static IEnumerable<string> BuildMultiLink(string baseUrl, int startNo, int endNo)
        {
            var jIndex = baseUrl.IndexOf("$");
            var jLength = 0;
            while (baseUrl[jIndex + jLength] == '$')
            {
                jLength++;
            }
            var b = baseUrl.Substring(0, jIndex);
            var e = baseUrl.Substring(jIndex + jLength);
            for (int i = startNo; i <= endNo; i++)
            {
                yield return b + i.ToString($"D{jLength}") + e;
            }
        }
    }
}
