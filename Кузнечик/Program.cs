using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Кузнечик;

namespace Кузнечик
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("\n\nДля зашифровки файла введите 1, для текста - 2, Расшифровать файл -3");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        EncryptFile();
                        break;
                    case 2:
                        EncryptText();
                        break;
                }
            } while (true);

        }

        static void EncryptFile()
        {
            Kuznechik Kuz = new Kuznechik();                            //Создание экземпляра класса Кузнечик 
            Console.Write("Введите путь к файлу для зашифрования: ");
            byte[] fileToEncrypt = File.ReadAllBytes(Console.ReadLine());
            //Console.Write("Введите пароль: ");                                
            byte[] password = Encoding.Default.GetBytes("01234567890123456789012345678901");        //Пароль должен быть 256 бит (32 символа)
            byte[] EncryptedFile = Kuz.KuzEncript(fileToEncrypt, password); //Получение массива байт зашифрованного файла
            File.WriteAllBytes("Encrypt.enc",EncryptedFile);
            byte[] DecryptedFile = Kuz.KuzDecript(EncryptedFile, password); //Получение массива байт расшифрованного файла
        }

        static void EncryptText()
        {
            Kuznechik Kuz = new Kuznechik();                            //Создание экземпляра класса Кузнечик 
            Console.Write("Введите текст для зашифрования: ");
            string textToEncrypt = Console.ReadLine();
            string password = "01234567890123456789012345678901";                           //Пароль должен быть 256 бит (32 символа)
            byte[] EncryptedText = Kuz.KuzEncript(Encoding.Default.GetBytes(textToEncrypt), Encoding.Default.GetBytes(password)); //Получение массива байт зашифрованного файла
            string EncrText = Encoding.Default.GetString(EncryptedText);
            Console.WriteLine("Зашифрованный текст: " + EncrText);
            byte[] DecryptedFile = Kuz.KuzDecript(EncryptedText, Encoding.Default.GetBytes(password)); //Получение массива байт расшифрованного файла
            string DecryptedText = Encoding.Default.GetString(DecryptedFile);
            Console.WriteLine("Расшифрованный текст: " + DecryptedText);
        }
    }
}
