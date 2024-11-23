using System.Security.Cryptography;
using System.Text;

namespace do_an_nhom_15.Utilities
{
    public class Function
    {

        public static string TitleSlugGenerationAlias(string title)
        {
            return SlugGenerator.SlugGenerator.GenerateSlug(title);
        }

    }
}
