using System.Security.Cryptography;

class ManagedAesSample
{
    public static void Main()
    {
        Console.WriteLine("Enter text that needs to be encrypted..");
        var data = Console.ReadLine();
        EncryptAesManaged(data);
        Console.ReadLine();
    }
    static void EncryptAesManaged(string raw)
    {
        try
        {
            using var aes = new AesManaged();
            byte[] encrypted = Encrypt(raw, aes.Key, aes.IV);
            Console.WriteLine($"Encrypted data: {System.Text.Encoding.UTF8.GetString(encrypted)}");
            string decrypted = Decrypt(encrypted, aes.Key, aes.IV);
            Console.WriteLine($"Decrypted data: {decrypted}");
        }
        catch (Exception exp)
        {
            Console.WriteLine(exp.Message);
        }
        Console.ReadKey();
    }
    static byte[] Encrypt(string plainText, byte[] Key, byte[] IV)
    {
        byte[] encrypted;
        using (var aes = new AesManaged())
        {
            var encryptor = aes.CreateEncryptor(Key, IV);
            using var ms = new MemoryStream();
            using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
            using (var sw = new StreamWriter(cs))
                sw.Write(plainText);
            encrypted = ms.ToArray();
        }
        // Return encrypted data    
        return encrypted;
    }
    static string Decrypt(byte[] cipherText, byte[] key, byte[] iv)
    {
        string plaintext = null;
        // Create AesManaged    
        using (var aes = new AesManaged())
        {
            // Create a decryptor    
            var decryptor = aes.CreateDecryptor(key, iv);
            // Create the streams used for decryption.    
            using var ms = new MemoryStream(cipherText);
            // Create crypto stream    
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            // Read crypto stream    
            using var reader = new StreamReader(cs);
            plaintext = reader.ReadToEnd();
        }
        return plaintext;
    }
}