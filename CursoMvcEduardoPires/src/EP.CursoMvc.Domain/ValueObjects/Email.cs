using System.Text.RegularExpressions;

namespace EP.CursoMvc.Domain.ValueObjects
{
    public class Email
    {
        public static bool Validar(string email)
        {
            return Regex.IsMatch(email,
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9-])?)\Z",RegexOptions.IgnoreCase);
        }
    }
}
