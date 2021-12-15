namespace Criptograft;

public class Program
{
    private const string TenantId = "AE75DE45-4856-4793-BAFF-437A67A348E7";

    public static void Main()
    {
        var password = "UMASENHAQUALQUER";
        var encrypted = password.Encrypy(TenantId.ToLower().Replace("-", ""));
        Console.WriteLine($"Senha criptografada = {encrypted}");

        var decrypted = encrypted.Decrypt(TenantId.ToLower().Replace("-", ""));
        Console.WriteLine($"Senha descriptografada = {decrypted}");
    }
}

public static class Helper 
{
    public static string Encrypy(this string plainText, string key)
        => AesOperation.Encrypy(key, plainText);

    public static string Decrypt(this string plainText, string key)
        => AesOperation.Decrypt(key, plainText);
}