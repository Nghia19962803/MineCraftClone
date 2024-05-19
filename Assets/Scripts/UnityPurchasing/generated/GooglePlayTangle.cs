// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("oblbAQ7KDVUbmb/Nyp2phE0vXMZ5JrPo70Azo73OVAN5McCZhRqG2gD8652/UsEhX4bi4XOB8Prpx2JcH+vtQzzk/+jwdNU/gAkYM9T8Ws7LYZghooZkKJt0GMixdAO9ORG0mgcPJij3NJ1BbG7X7Pbirw78U1Y/6r31SR1dAa4w7n2KxEQj8EaNi8j1R8Tn9cjDzO9DjUMyyMTExMDFxivKQFuwT4CtjJ5mrwXlerDKYe7cSm/2isWvN2VydAfoZpwgBsznL7nu3PHPti4PQsnUQiEX+ZFj259VO3rXfoP33nMOCMtlsTvXCSj5zMnF/3/buNg+zvVkDiOetNnR8QBt/YFHxMrF9UfEz8dHxMTFCvzLth/5ShFhWm3M+cxOxMfGxMXE");
        private static int[] order = new int[] { 12,10,8,7,13,5,11,12,8,11,13,12,12,13,14 };
        private static int key = 197;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
