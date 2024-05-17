﻿/// <summary>
/// System.
/// </summary>
using System;
/// <summary>
/// System.Collections.Generic.
/// </summary>
using System.Collections.Generic;
/// <summary>
/// System.IO.
/// </summary>
using System.IO;
/// <summary>
/// System.Text.
/// </summary>
using System.Text;
/// <summary>
/// System.Linq.
/// </summary>
using System.Linq;
/// <summary>
/// OtpNet.
/// </summary>
using OtpNet;

namespace FitnessLibrary {
/// <summary>
/// Represents a member record.
/// </summary>
struct MemberRecord {
    /// <summary>
    /// Member ID.
    /// </summary>
    public string memberID;

    /// <summary>
    /// Full name of the member.
    /// </summary>
    public string fullName;

    /// <summary>
    /// Birth date of the member.
    /// </summary>
    public string birthDate;

    /// <summary>
    /// Phone number of the member.
    /// </summary>
    public string phoneNumber;

    /// <summary>
    /// Date of first registration.
    /// </summary>
    public string firstRegistrationDate;
}

/// <summary>
/// Represents a subscription record.
/// </summary>
struct SubscriptionRecord {
    /// <summary>
    /// Member ID associated with the subscription.
    /// </summary>
    public string memberID;

    /// <summary>
    /// Starting date of the subscription.
    /// </summary>
    public string startingDate;

    /// <summary>
    /// Finishing date of the subscription.
    /// </summary>
    public string finishingDate;

    /// <summary>
    /// Tier of the subscription.
    /// </summary>
    public string subscriptionTier;
}

/// <summary>
/// Represents a class record.
/// </summary>
struct ClassRecord {
    /// <summary>
    /// Tutor of the class.
    /// </summary>
    public string tutor;

    /// <summary>
    /// Date of the class.
    /// </summary>
    public string date;

    /// <summary>
    /// Starting hour of the class.
    /// </summary>
    public string startingHour;

    /// <summary>
    /// Finishing hour of the class.
    /// </summary>
    public string finishingHour;

    /// <summary>
    /// List of students in the class.
    /// </summary>
    public string studentList;
}

/// <summary>
/// Represents a payment record.
/// </summary>
struct PaymentRecord {
    /// <summary>
    /// Member ID associated with the payment.
    /// </summary>
    public string memberID;

    /// <summary>
    /// Amount paid.
    /// </summary>
    public string paidAmount;

    /// <summary>
    /// Date of the payment.
    /// </summary>
    public string paymentDate;

    /// <summary>
    /// Date of the next payment.
    /// </summary>
    public string nextPaymentDate;
}


/// <summary>
/// Struct for login menu.
/// </summary>
struct LoginMenuVariables {
    /// <summary>
    /// A variable to control app's running state.
    /// </summary>
    public bool run;
    /// <summary>
    /// A variable for menu navigation.
    /// </summary>
    public int loginMenuLogin;
    /// <summary>
    /// A variable for menu navigation.
    /// </summary>
    public int loginMenuRegister;
    /// <summary>
    /// A variable for menu navigation.
    /// </summary>
    public int loginMenuPasswordReset;
    /// <summary>
    /// A variable for menu navigation.
    /// </summary>
    public int loginMenuGuest;
    /// <summary>
    /// A variable for menu navigation.
    /// </summary>
    public int loginMenuExit;

    /// <summary>
    /// Constructor.
    /// </summary>
    public LoginMenuVariables() {
        run = true;
        loginMenuLogin = 1;
        loginMenuRegister = 2;
        loginMenuPasswordReset = 3;
        loginMenuGuest = 4;
        loginMenuExit = 5;
    }
};

/// <summary>
/// Struct for main menu.
/// </summary>
struct MainMenuVariables {
    /// <summary>
    /// A variable to control app's running state.
    /// </summary>
    public bool loggedIn;
    /// <summary>
    /// A variable for menu navigation.
    /// </summary>
    public int MainMenuMember;
    /// <summary>
    /// A variable for menu navigation.
    /// </summary>
    public int MainMenuSubs;
    /// <summary>
    /// A variable for menu navigation.
    /// </summary>
    public int MainMenuClass;
    /// <summary>
    /// A variable for menu navigation.
    /// </summary>
    public int MainMenuPayment;
    /// <summary>
    /// A variable for menu navigation.
    /// </summary>
    public int MainMenuLogOut;

    /// <summary>
    /// Constructor.
    /// </summary>
    public MainMenuVariables() {
        loggedIn = true;
        MainMenuMember = 1;
        MainMenuSubs = 2;
        MainMenuClass = 3;
        MainMenuPayment = 4;
        MainMenuLogOut = 5;
    }
};

/// <summary>
/// Struct for sub menus.
/// </summary>
struct SubMenuVariables {
    /// <summary>
    /// A variable for menu navigation.
    /// </summary>
    public int SubMenuShow;
    /// <summary>
    /// A variable for menu navigation.
    /// </summary>
    public int SubMenuAdd;
    /// <summary>
    /// A variable for menu navigation.
    /// </summary>
    public int SubMenuEdit;
    /// <summary>
    /// A variable for menu navigation.
    /// </summary>
    public int SubMenuDelete;
    /// <summary>
    /// A variable for menu navigation.
    /// </summary>
    public int SubMenuReturn;

    /// <summary>
    /// Constructor.
    /// </summary>
    public SubMenuVariables() {
        SubMenuShow = 1;
        SubMenuAdd = 2;
        SubMenuEdit = 3;
        SubMenuDelete = 4;
        SubMenuReturn = 5;
    }
};


/// <summary>
/// Huffman tree node class.
/// </summary>
public class Node
{
    /// <summary>
    /// Character data stored in the node.
    /// </summary>
    public char Data; 
    /// <summary>
    /// frequency of the character.
    /// </summary>
    public int freq;
    /// <summary>
    /// Left child node.
    /// </summary>
    public Node Left;
    /// <summary>
    /// Right child node.
    /// </summary>
    public Node Right;

    /// <summary>
    /// Constructs a new Node object.
    /// </summary>
    /// <param name="Data">Character stored in the node.</param>
    /// <param name="freq">frequency of the character.</param>
    public Node(char Data, int freq) 
    { 
        Left = Right = null; 
        this.Data = Data; 
        this.freq = freq;
    } 
}

/// <summary>
/// Compare Class for frequency map.
/// </summary>
public class CompareNode : IComparer<Node>
{
    /// <summary>
    /// Compare function for frequency map.
    /// </summary>
    public int Compare(Node x, Node y)
    {
        int freqComparison = x.freq.CompareTo(y.freq);

        if (freqComparison == 0)
        {
            return string.Compare(x.Data.ToString(), y.Data.ToString(), StringComparison.OrdinalIgnoreCase);
        }
        else
        {
            return freqComparison;
        }
    }
}

/// <summary>
/// Huffman encoding and decoding class.
/// </summary>
public class Huffman
{
/// <summary>
/// PriorityQueue for huffman tree.
/// </summary>
public class PriorityQueue<T>
{
    /// <summary>
    /// list for huffman data.
    /// </summary>
    private List<T> data;
    /// <summary>
    /// comparer class for huffman.
    /// </summary>
    private readonly IComparer<T> comparer;
    /// <summary>
    /// count getter.
    /// </summary>
    public int Count
    {
        get { return data.Count; }
    }
    /// <summary>
    /// PriorityQueue function.
    /// </summary>
    /// <param name="comparer">comparer class object.</param>
    public PriorityQueue(IComparer<T> comparer)
    {
        data = new List<T>();
        this.comparer = comparer;
    }
    /// <summary>
    /// Enqueue function.
    /// </summary>
    /// <param name="item">item.</param>
    public void Enqueue(T item)
    {
        data.Add(item);
        int i = data.Count - 1;
        while (i > 0 && comparer.Compare(data[i], data[(i - 1) / 2]) < 0)
        {
            T tmp = data[i];
            data[i] = data[(i - 1) / 2];
            data[(i - 1) / 2] = tmp;
            i = (i - 1) / 2;
        }
    }
    /// <summary>
    /// Dequeue function.
    /// </summary>
    public T Dequeue()
    {
        if (data.Count == 0)
        {
            throw new InvalidOperationException("Cannot dequeue from an empty queue.");
        }

        T ret = data[0];
        data[0] = data[data.Count - 1];
        data.RemoveAt(data.Count - 1);
        int i = 0;
        while ((2 * i + 1) < data.Count)
        {
            int j = 2 * i + 1;
            if ((2 * i + 2) < data.Count && comparer.Compare(data[2 * i + 2], data[j]) < 0)
            {
                j = 2 * i + 2;
            }

            if (comparer.Compare(data[i], data[j]) <= 0)
            {
                break;
            }

            T tmp = data[i];
            data[i] = data[j];
            data[j] = tmp;
            i = j;
        }

        return ret;
    }
    /// <summary>
    /// Peek function.
    /// </summary>
    public T Peek()
    {
        return data[0];
    }
}
    /// <summary>
    /// Calculates frequency of characters in the input text.
    /// </summary>
    /// <param name="text">Input text.</param>
    /// <returns>Dictionary containing character frequencies.</returns>
public Dictionary<char, int> Calculatefrequency(string text)
    {
        Dictionary<char, int> freqMap = new Dictionary<char, int>();

        foreach (char ch in text)
        {
            if (ch == ' ')
            {
                if (freqMap.ContainsKey('_'))
                    freqMap['_']++;
                else
                    freqMap['_'] = 1;
            }
            else
            {
                if (freqMap.ContainsKey(ch))
                    freqMap[ch]++;
                else
                    freqMap[ch] = 1;
            }
        }

        return freqMap;
    }

    /// <summary>
    /// Builds the Huffman tree based on character frequencies.
    /// </summary>
    /// <param name="freqMap">frequency map of characters.</param>
    /// <returns>Root of the Huffman tree.</returns>
public Node BuildHuffmanTree(Dictionary<char, int> freqMap)
    {
        // Create a min heap & inserts all characters of Data[]
        var root = new PriorityQueue<Node>(new CompareNode());
        
        foreach (var entry in freqMap)
        {
            root.Enqueue(new Node(entry.Key, entry.Value)); // Use Enqueue instead of Add
        }

        // Iterate while size of heap doesn't become 1
        while (root.Count != 1)
        {
            Node top = new Node('$', 0);

            Node Left = root.Dequeue();
            top.Left = Left;

            Node Right = root.Dequeue();
            top.Right = Right;

            top.freq = Left.freq + Right.freq;
            root.Enqueue(top); // Enqueue the new node
        }

        return root.Dequeue(); // Return the root of the Huffman tree
    }

/// <summary>
/// Traverses the Huffman tree and builds the codewords.
/// </summary>
/// <param name="root">Root of the Huffman tree.</param>
/// <param name="code">Current code.</param>
/// <param name="codes">Dictionary to store character codes.</param>
    public void BuildCodes(Node root, string code, Dictionary<char, string> codes)
    {
        if (root == null) return;

        // If leaf node is reached, store the code
        if (root.Data != '$')
        {
            codes[root.Data] = code;

        }

        // Traverse Left and Right
        BuildCodes(root.Left, code + "1", codes);
        BuildCodes(root.Right, code + "0", codes);
    }

/// <summary>
/// Encodes the input text using Huffman codes.
/// </summary>
/// <param name="text">Input text.</param>
/// <param name="codes">Dictionary of character codes.</param>
/// <returns>Encoded text.</returns>
public string Encode(string text, Dictionary<char, string> codes)
{
    string encodedText = "";

    foreach (char ch in text)
    {
        if (ch == ' ')
        {
            if (codes.ContainsKey('_'))
                encodedText += codes['_'];
            else
                Console.Write("Character '_' is missing in the codes dictionary");
        }
        else
        {
            if (codes.ContainsKey(ch))
                encodedText += codes[ch];
            else
                Console.Write("Character '" + ch + "' is missing in the codes dictionary");
        }
    }

    return encodedText;
}

/// <summary>
/// Decodes the encoded text using Huffman codes.
/// </summary>
/// <param name="encodedText">Encoded text.</param>
/// <param name="root">Root of the Huffman tree.</param>
/// <returns>Decoded text.</returns>
public string Decode(string encodedText, Node root) {

  string decodedText = "";
  Node current = root;

  foreach (char bit in encodedText) {
    if (bit == '0') {
      current = current.Right;
    } else {
      current = current.Left;
    }

    if (current.Left == null && current.Right == null){
      decodedText += current.Data;
      current = root; // Reset current to root for next character
    }
  }
  return decodedText;
}
/// <summary>
/// Writes a tree structure to a file using a <see cref="FileStream"/>.
/// </summary>
/// <param name="outFile">The <see cref="FileStream"/> used to write to the file.</param>
/// <param name="node">The root <see cref="Node"/> of the tree to write.</param>
 public static void WriteTreeToFile(FileStream outFile, Node node)
        {
            if (node.Left == null && node.Right == null)
            {
                char data = node.Data;

                if (data == '\n')
                {
                    outFile.WriteByte((byte)'L');
                    outFile.WriteByte((byte)'\\');
                    outFile.WriteByte((byte)'n');
                }
                else if (data == ' ')
                {
                    outFile.WriteByte((byte)'L');
                    outFile.WriteByte((byte)'_');
                }
                else
                {
                    outFile.WriteByte((byte)'L');
                    outFile.WriteByte((byte)data);
                }

                outFile.WriteByte((byte)'|');
                outFile.Write(Encoding.ASCII.GetBytes(node.freq.ToString()), 0, Encoding.ASCII.GetBytes(node.freq.ToString()).Length);
            }
            else
            {
                outFile.WriteByte((byte)'I');
                outFile.WriteByte((byte)node.Data);
                outFile.WriteByte((byte)'|');
                outFile.Write(Encoding.ASCII.GetBytes(node.freq.ToString()), 0, Encoding.ASCII.GetBytes(node.freq.ToString()).Length);
                WriteTreeToFile(outFile, node.Left);
                WriteTreeToFile(outFile, node.Right);
            }
        }
        /// <summary>
        /// Reads a tree structure from a file using a <see cref="StreamReader"/>.
        /// </summary>
        /// <param name="reader">The <see cref="StreamReader"/> used to read from the file.</param>
        /// <returns>A <see cref="Node"/> representing the root of the tree read from the file, or <c>null</c> if the end of the file is reached or an invalid marker is encountered.</returns>
        public static Node ReadTreeFromFile(StreamReader reader)
        {
            int marker = reader.Read();
    
            if (marker == -1)
            {
                Console.Write("End of file reached!");
                return null;
            }

            char markerChar = (char)marker;

            if (markerChar == 'L')
            {
                int data = reader.Read();
                char character = (char)data;

                if (character == '\\' && reader.Peek() == 'n')
                {
                    reader.Read(); // Consume the 'n' character
                    character = '\n'; // Replace with newline character
                }

                if (character == '_')
                {
                    character = ' '; // Replace with space character
                }

                reader.Read(); // Ignore the delimiter
                string freqStr = "";
                while (reader.Peek() != 'L' && reader.Peek() != 'I' && reader.Peek() != -1)
                {
                    freqStr += (char)reader.Read();
                }
                int freq = int.Parse(freqStr);
                return new Node(character, freq);
            }
            else if (markerChar == 'I')
            {
                int data = reader.Read();
                char character = (char)data;
                reader.Read(); // Ignore the delimiter
                string freqStr = "";
                while (reader.Peek() != 'L' && reader.Peek() != 'I' && reader.Peek() != -1)
                {
                    freqStr += (char)reader.Read();
                }
                int freq = int.Parse(freqStr);
                Node internalNode = new Node(character, freq);
                internalNode.Left = ReadTreeFromFile(reader);
                internalNode.Right = ReadTreeFromFile(reader);
                return internalNode;
            }
            else
            {
                Console.Write("Invalid marker in file!");
                return null;
            }
        }
}
/// <summary>
/// SHA1 class.
/// </summary>
public class SHA1
{   
    /// <summary>
    /// convert text to sha1.
    /// </summary>
    /// <param name="input">string to convert.</param>
    public string CalculateSHA1(string input)
    {
        // Convert input string to bytes
        byte[] data = Encoding.UTF8.GetBytes(input);

        // Initialize variables
        uint h0 = 0x67452301;
        uint h1 = 0xEFCDAB89;
        uint h2 = 0x98BADCFE;
        uint h3 = 0x10325476;
        uint h4 = 0xC3D2E1F0;

        // Pre-processing: append padding bits and length
        long originalLength = data.Length * 8;
        int paddingLength = 64 - ((data.Length + 8) % 64); // Adjust padding calculation
        if (paddingLength == 0)
            paddingLength = 64;

        byte[] padding = new byte[paddingLength];
        padding[0] = 0x80;

        // Append a single '1' bit
        Array.Resize(ref data, data.Length + paddingLength);
        Array.Copy(padding, 0, data, data.Length - paddingLength, paddingLength);

        // Append original length in bits as a 64-bit big-endian integer
        byte[] lengthBytes = BitConverter.GetBytes(originalLength);
        Array.Resize(ref data, data.Length + 8);
        Array.Copy(lengthBytes, 0, data, data.Length - 8, 8);

        // Process the message in successive 512-bit chunks
        for (int i = 0; i < data.Length; i += 64)
        {
            uint[] w = new uint[80];

            // Break chunk into sixteen 32-bit big-endian words w[i]
            for (int j = 0; j < 16; j++)
            {
                w[j] = (uint)((data[i + j * 4] << 24) |
                               (data[i + j * 4 + 1] << 16) |
                               (data[i + j * 4 + 2] << 8) |
                               (data[i + j * 4 + 3]));
            }

            // Extend the sixteen 32-bit words into eighty 32-bit words
            for (int j = 16; j < 80; j++)
            {
                w[j] = (w[j - 3] ^ w[j - 8] ^ w[j - 14] ^ w[j - 16]);
                w[j] = (w[j] << 1) | (w[j] >> 31); // Left rotate by 1 bit
            }

            // Initialize hash value for this chunk
            uint a = h0;
            uint b = h1;
            uint c = h2;
            uint d = h3;
            uint e = h4;

            // Main loop
            for (int j = 0; j < 80; j++)
            {
                uint f, k;
                if (j < 20)
                {
                    f = (b & c) | ((~b) & d);
                    k = 0x5A827999;
                }
                else if (j < 40)
                {
                    f = b ^ c ^ d;
                    k = 0x6ED9EBA1;
                }
                else if (j < 60)
                {
                    f = (b & c) | (b & d) | (c & d);
                    k = 0x8F1BBCDC;
                }
                else
                {
                    f = b ^ c ^ d;
                    k = 0xCA62C1D6;
                }

                uint temp = ((a << 5) | (a >> 27)) + f + e + k + w[j];
                e = d;
                d = c;
                c = ((b << 30) | (b >> 2));
                b = a;
                a = temp;
            }

            // Add this chunk's hash to result so far
            h0 += a;
            h1 += b;
            h2 += c;
            h3 += d;
            h4 += e;
        }

        // Produce the final hash value (big-endian)
        byte[] hashBytes = new byte[20];
        Array.Copy(BitConverter.GetBytes(h0), 0, hashBytes, 0, 4);
        Array.Copy(BitConverter.GetBytes(h1), 0, hashBytes, 4, 4);
        Array.Copy(BitConverter.GetBytes(h2), 0, hashBytes, 8, 4);
        Array.Copy(BitConverter.GetBytes(h3), 0, hashBytes, 12, 4);
        Array.Copy(BitConverter.GetBytes(h4), 0, hashBytes, 16, 4);

        // Convert hash bytes to string
        string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

        return hashString;
    }
}
/// <summary>
/// Fitness class.
/// </summary>
public class Fitness {
/// <summary>
/// huffman class object.
/// </summary>
private static Huffman huffman = new Huffman();
/// <summary>
/// sha1 class object.
/// </summary>
private static SHA1 sha1 = new SHA1();

/// <summary>
/// Finds the longest common subsequence (LCS) of two input strings.
/// </summary>
/// <param name="text1">The first input string.</param>
/// <param name="text2">The second input string.</param>
/// <returns>The longest common subsequence of the input strings.</returns>
public static string LCS(string text1, string text2)
{
    int m = text1.Length;
    int n = text2.Length;

    // Added edge case handling
    if (m == 0 || n == 0) return string.Empty;

    int[,] dp = new int[m + 1, n + 1];

    for (int i = 1; i <= m; ++i)
    {
        for (int j = 1; j <= n; ++j)
        {
            if (text1[i - 1] == text2[j - 1])
            {
                dp[i, j] = dp[i - 1, j - 1] + 1;
            }
            else
            {
                dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
            }
        }
    }

    int x = m, y = n;
    StringBuilder lcs = new StringBuilder(); // Changed to StringBuilder for efficiency

    while (x > 0 && y > 0)
    {
        if (text1[x - 1] == text2[y - 1])
        {
            lcs.Insert(0, text1[x - 1]); // Using StringBuilder for efficient string concatenation
            --x;
            --y;
        }
        else if (dp[x - 1, y] > dp[x, y - 1])
        {
            --x;
        }
        else
        {
            --y;
        }
    }

    return lcs.ToString();
}

/// <summary>
/// Finds if file has a record that has a high LCS with text.
/// </summary>
/// <param name="text">The input string.</param>
/// <param name="fileName">The file name.</param>
/// <returns>0 on success, -1 on fail.</returns>
public static int CheckLCS(string text, string fileName)
{
    try
    {
        using (FileStream fileStream = new FileStream(fileName + ".bin", FileMode.Open, FileAccess.Read))
        {
            long fileSize = fileStream.Length;
            byte[] buffer = new byte[fileSize];
            int bytesRead = fileStream.Read(buffer, 0, buffer.Length);
            string content = Encoding.Default.GetString(buffer, 0, bytesRead);

            using (StreamReader inFile = new StreamReader(fileName + "_huffman.bin"))
            {   
                Huffman huffman = new Huffman();
                Node root = Huffman.ReadTreeFromFile(inFile);
                string decodedText = huffman.Decode(content, root); // Ensure proper method reference

                string[] lines = decodedText.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lines)
                {
                    string recordLCS = LCS(line, text);
                    double similarity = ((double)recordLCS.Length / line.Length) * 100;

                    if (similarity >= 85)
                    {
                        return 0;
                    }
                }
            }
        }
    }
    catch (FileNotFoundException)
    {
        return -1;
    }
    catch (IOException)
    {
        return -1;
    }
    catch (Exception) // Added general exception handling
    {
        return -1;
    }

    return -1;
}
/// <summary>
/// Writes text to a file, encoding it using Huffman coding, and saves the Huffman tree to another file.
/// </summary>
/// <param name="fileName">The name of the file to write the encoded text to.</param>
/// <param name="text">The text to encode and write.</param>
/// <param name="isFileNew">Indicates whether the file is new. If <c>true</c>, prefixes the text with "1-)" and a newline.</param>
/// <returns>Returns 0 upon successful completion.</returns>
public static int FileWrite(string fileName, string text, bool isFileNew)
{
    if (isFileNew)
    {
        text = "1-)" + text + "\n";
    }

    Dictionary<char, int> freqMap = huffman.Calculatefrequency(text);
    Node root = huffman.BuildHuffmanTree(freqMap);
    Dictionary<char, string> codes = new Dictionary<char, string>();
    huffman.BuildCodes(root, "", codes);
    string encodedText = huffman.Encode(text, codes);

    // Write encoded text directly to the file
    File.WriteAllText(fileName + ".bin", encodedText);

    // Write Huffman tree to another file if needed
    using (FileStream outFileHuffman = new FileStream(fileName + "_huffman.bin", FileMode.Create, FileAccess.Write))
    {
        Huffman.WriteTreeToFile(outFileHuffman, root);
    }

    return 0;
}
/// <summary>
/// Reads encoded text from a file, decodes it using the Huffman tree, and optionally prints the decoded text to the console.
/// </summary>
/// <param name="fileName">The name of the file to read the encoded text from.</param>
/// <param name="printToConsole">Indicates whether to print the decoded text to the console.</param>
/// <returns>The decoded text, or "-1" if a file operation fails.</returns>
public static string FileRead(string fileName, bool printToConsole)
{   
    Huffman huffman = new Huffman();
    try
    {
        // Read encoded text directly from the file
        string encodedText = File.ReadAllText(fileName + ".bin");

        // Read Huffman tree from another file if needed
        using (StreamReader inFile = new StreamReader(fileName + "_huffman.bin"))
        {
            Node root = Huffman.ReadTreeFromFile(inFile);
            string decodedText = huffman.Decode(encodedText, root);

            if (printToConsole)
            {
                Console.Write(decodedText);
            }

            return decodedText;
        }
    }
    catch (FileNotFoundException)
    {
        Console.Write("File operation failed, There is no record");
        return "-1";
    }
    catch (IOException)
    {
        Console.Write("File operation failed, There is no record");
        return "-1";
    }
}
/// <summary>
/// Reads the content of a binary file and returns it as a string.
/// </summary>
/// <param name="fileName">The name of the file to read.</param>
/// <returns>The content of the file, or "-1" if the file is not found or an IO error occurs.</returns>
    public static string FileReadForTest(string fileName)
    {
        try
        {
            using (FileStream myFile = new FileStream(fileName + ".bin", FileMode.Open, FileAccess.Read))
            {
                string content = "";

                int ch;
                while ((ch = myFile.ReadByte()) != -1)
                {
                    if (ch == '\r') continue; // Skip '\r'

                    content += (char)ch;
                }

                return content;
            }
        }
        catch (FileNotFoundException)
        {
            Console.Write("File operation failed, There is no record");
            return "-1";
        }
        catch (IOException)
        {
            Console.Write("File operation failed, There is no record");
            return "-1";
        }
    }
/// <summary>
/// Appends text to a file, updating line numbers accordingly.
/// </summary>
/// <param name="fileName">The name of the file to append to.</param>
/// <param name="text">The text to append.</param>
/// <returns>Returns 0 upon successful completion, or -1 if an error occurs.</returns>
    public static int FileAppend(string fileName, string text)
    {
        bool mode = false;
        string fileContent = FileRead(fileName, mode);

        if (fileContent == "-1")
        {
            return -1;
        }

        string lastLine = "";
        string currentLine = "";

        foreach (char i in fileContent)
        {
            if (i == '\n')
            {
                currentLine += i;
                lastLine = currentLine;
                currentLine = "";
                continue;
            }

            currentLine += i;
        }

        int pos = lastLine.IndexOf("-)"); // Finds the location of "-)" in the last line
        int lineNumber = int.Parse(lastLine.Substring(0, pos)) + 1; // Finds the number for the appended line
        text = lineNumber + "-)" + text + "\n";
        fileContent += text;
        FileWrite(fileName, fileContent, false);
        return 0;
    }
/// <summary>
/// Edits a specific line in a file.
/// </summary>
/// <param name="fileName">The name of the file to edit.</param>
/// <param name="lineNumberToEdit">The line number to edit.</param>
/// <param name="newLine">The new content for the specified line.</param>
/// <returns>Returns 0 upon successful completion, or -1 if an error occurs or the line number is invalid.</returns>
    public static int FileEdit(string fileName, int lineNumberToEdit, string newLine)
    {
        bool mode = false;
        string fileContent = FileRead(fileName, mode);

        if (fileContent == "-1")
        {
            return -1;
        }

        string[] lines = fileContent.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        int lineCount = lines.Length; // A variable for an if statement to check if the line that the user wants to edit exists
        for (int i = 0; i < lineCount; i++)
        {
            if (!lines[i].EndsWith("\n"))
            {
                lines[i] += "\n";
            }
        }
        if (lineNumberToEdit > 0 && lineNumberToEdit <= lineCount)
        {
            lines[lineNumberToEdit - 1] = lineNumberToEdit + "-)" + newLine + "\n"; // Changes a member of Lines array to a new line with its line number
        }
        else
        {
            Console.Write("\nYou can only edit existing lines");
            return -1;
        }

        string newFileContent = string.Join("", lines);
        FileWrite(fileName, newFileContent, false);
        Console.Write("\nData successfully edited");
        return 0;
    }
/// <summary>
/// Deletes a specific line from a file.
/// </summary>
/// <param name="fileName">The name of the file to edit.</param>
/// <param name="lineNumberToDelete">The line number to delete.</param>
/// <returns>Returns 0 upon successful completion, or -1 if an error occurs or the line number is invalid.</returns>
    public static int FileLineDelete(string fileName, int lineNumberToDelete)
    {
        bool mode = false;
        string fileContent = FileRead(fileName, mode);

        if (fileContent == "-1")
        {
            return -1;
        }

        string[] lines = fileContent.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        int lineCount = lines.Length; // A variable for an if statement to check if the line that the user wants to edit exists
        for (int i = 0; i < lineCount; i++)
        {
            if (!lines[i].EndsWith("\n"))
            {
                lines[i] += "\n";
            }
        }
        if (lineNumberToDelete > 0 && lineNumberToDelete <= lineCount)
        {
            // Shift elements to "erase" the line at lineNumberToDelete
            for (int i = lineNumberToDelete - 1; i < lineCount - 1; ++i)
            {
                lines[i] = lines[i + 1];
            }

            Array.Resize(ref lines, lineCount - 1); // Clears the last element of lines so the same thing wouldn't write to the file twice
        }
        else
        {
            Console.Write("\nYou can only erase existing lines");
            return -1;
        }

        List<string> newLines = new List<string>();

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            int pos = line.IndexOf("-)"); // Finds the position of "-)"
            int lineNumber = int.Parse(line.Substring(0, pos)); // Finds each line's line number

            if (lineNumber > lineNumberToDelete) // Decreases a line's line number if it's bigger than the deleted line's line number
            {
                line = (lineNumber - 1) + line.Substring(pos);
            }

            newLines.Add(line);
        }

        string newFileContent = string.Join("", newLines);
        FileWrite(fileName, newFileContent, false);
        Console.Write("\nData successfully deleted");
        return 0;
    }
/// <summary>
/// Registers a new user by saving their hashed username, password, and recovery key to a file.
/// </summary>
/// <param name="newUsername">The username to register.</param>
/// <param name="newPassword">The password for the new user.</param>
/// <param name="newRecoveryKey">The recovery key for the new user.</param>
/// <param name="userFile">The file to save the user information to.</param>
/// <returns>Returns 0 upon successful completion.</returns>
public static int UserRegister(string newUsername, string newPassword, string newRecoveryKey, string userFile)
    {
        newUsername = sha1.CalculateSHA1(newUsername);
        newPassword = sha1.CalculateSHA1(newPassword);
        newRecoveryKey = sha1.CalculateSHA1(newRecoveryKey);
        string loginInfo = $"{newUsername}/{newPassword}/{newRecoveryKey}";
        FileWrite(userFile, loginInfo, false);
        return 0;
    }

/// <summary>
/// Logs in a user by verifying their hashed username and password against stored data.
/// </summary>
/// <param name="username">The username to log in with.</param>
/// <param name="password">The password to log in with.</param>
/// <param name="userFile">The file containing the user information.</param>
/// <returns>Returns 0 if login is successful, or -1 if login fails.</returns>
public static int UserLogin(string username, string password, string userFile)
    {
        bool mode = false;
        string fileContent = FileRead(userFile, mode);
        if (fileContent == "-1")
        {
            return -1;
        }

        string[] parts = fileContent.Split('/');
        if (parts.Length < 3)
        {
            return -1;
        }

        string usernameRead = parts[0];
        string passwordRead = parts[1];

        if (sha1.CalculateSHA1(username) == usernameRead && sha1.CalculateSHA1(password) == passwordRead)
        {
            Console.Write("\nLogin Successful");
            return 0;
        }
        else
        {
            Console.Write("\nWrong username or password");
            return -1;
        }
    }
/// <summary>
/// Changes a user's password by verifying the recovery key and updating the stored data.
/// </summary>
/// <param name="recoveryKey">The recovery key for the user.</param>
/// <param name="newPassword">The new password for the user.</param>
/// <param name="userFile">The file containing the user information.</param>
/// <returns>Returns 0 if the password is successfully changed, or -1 if the recovery key is incorrect or other errors occur.</returns>
    public static int UserChangePassword(string recoveryKey, string newPassword, string userFile)
    {
        bool mode = false;
        string fileContent = FileRead(userFile, mode);
        if (fileContent == "-1")
        {
            Console.Write("\nThere is no user info. Please register first.");
            return -1;
        }

        string[] parts = fileContent.Split('/');
        if (parts.Length < 3)
        {
            return -1;
        }

        string usernameRead = parts[0];
        string recoveryKeyRead = parts[2];

        if (sha1.CalculateSHA1(recoveryKey) == recoveryKeyRead)
        {
            Console.Write("\nRecovery Key Approved");
            string newLoginInfo = $"{usernameRead}/{sha1.CalculateSHA1(newPassword)}/{recoveryKeyRead}";
            FileWrite(userFile, newLoginInfo, false);
            Console.Write("\nPassword changed successfully");
            return 0;
        }
        else
        {
            Console.Write("\nWrong Recovery Key");
            return -1;
        }
    }

    /// <summary>
    /// Main entry point of app.
    /// </summary>
    public void mainApp()
    {
        LoginMenuVariables loginMenuChoice = new LoginMenuVariables();

        while (loginMenuChoice.run)
        {
            Console.Write("\n--------Login Menu--------\n" +
                          "1-)Login\n" +
                          "2-)Register\n" +
                          "3-)Change Password\n" +
                          "4-)Login as a Guest\n" +
                          "5-)Exit\n" +
                          "Please enter a choice:");
            int choiceLoginMenu;
            if (!int.TryParse(Console.ReadLine(), out choiceLoginMenu))
            {
                Console.Write("Invalid input.");
                continue;
            }

            if (choiceLoginMenu == loginMenuChoice.loginMenuLogin)
            {
                LoginMenu(false);
            }
            else if (choiceLoginMenu == loginMenuChoice.loginMenuRegister)
            {
                RegisterMenu();
            }
            else if (choiceLoginMenu == loginMenuChoice.loginMenuPasswordReset)
            {
                ChangePasswordMenu();
            }
            else if (choiceLoginMenu == loginMenuChoice.loginMenuGuest)
            {
                MainMenu(true);
            }
            else if (choiceLoginMenu == loginMenuChoice.loginMenuExit)
            {
                loginMenuChoice.run = false;
            }
            else
            {
                Console.Write("Please input a correct choice.");
            }
        }
    }

    /// <summary>
    /// Login menu.
    /// </summary>
    /// <param name="isUnitTesting">A bool to check if it is unit testing.</param>
    /// <returns>0.</returns>
    public static int LoginMenu(bool isUnitTesting)
    {
        string userName;
        string password;
        string userFile = "user";
        Console.Write("\nPlease enter your username:");
        userName = Console.ReadLine();
        Console.Write("\nPlease enter your password:");
        password = Console.ReadLine();

        if (UserLogin(userName, password, userFile) == 0)
        {

            var key = KeyGeneration.GenerateRandomKey(20);

            var base32String = Base32Encoding.ToString(key);
            var base32Bytes = Base32Encoding.ToBytes(base32String);

            var Otp = new Totp(base32Bytes).ToString();

            string userInputOtp;

            Console.Write("\nPlease enter single use code that we send you:");

            if (isUnitTesting)
            {
                userInputOtp = Otp;
            }
            else
            {
                Console.Write($"\n{Otp} is the code, this is just the simulation of scenario:");
                userInputOtp = Console.ReadLine();
            }

            if (userInputOtp == Otp)
            {
                MainMenu(false);
            }
        }

        return 0;
    }

    /// <summary>
    /// Register menu.
    /// </summary>
    /// <returns>0.</returns>
    public static int RegisterMenu()
    {
        string userName;
        string password;
        string recoveryKey;
        string userFile = "user";
        string warning;
        Console.Write("\nPlease enter your new username:");
        userName = Console.ReadLine();
        Console.Write("\nPlease enter your new password:");
        password = Console.ReadLine();
        Console.Write("\nPlease enter your new recovery key:");
        recoveryKey = Console.ReadLine();
        Console.Write("\n------------WARNING------------" +
                      "\nThis process will delete all previous records, do you still wish to proceed?[Y/n]:");
        warning = Console.ReadLine();

        if (warning == "Y")
        {
            UserRegister(userName, password, recoveryKey, userFile);
        }
        else
        {
            Console.Write("\nProcess terminated.");
        }

        return 0;
    }

    /// <summary>
    /// Change password menu.
    /// </summary>
    /// <returns>0.</returns>
    public static int ChangePasswordMenu()
    {
        string password;
        string recoveryKey;
        string userFile = "user";
        Console.Write("\nPlease enter your recovery key:");
        recoveryKey = Console.ReadLine();
        Console.Write("\nPlease enter your new password:");
        password = Console.ReadLine();
        UserChangePassword(recoveryKey, password, userFile);
        return 0;
    }

    /// <summary>
    /// Main menu.
    /// </summary>
    /// <param name="isGuestMode">A bool to check if user entered with guest mode.</param>
    /// <returns>0.</returns>
    public static int MainMenu(bool isGuestMode)
    {
        MainMenuVariables MainMenuChoice = new MainMenuVariables();
        while (true)
        {
            Console.Write("\n--------Main Menu--------" +
                          "\n1-)Member Management" +
                          "\n2-)Subscription Tracking" +
                          "\n3-)Class Management" +
                          "\n4-)Payment Processing" +
                          "\n5-)Log out" +
                          "\nPlease enter a choice:");
            int choiceMainMenu;
            if (!int.TryParse(Console.ReadLine(), out choiceMainMenu))
            {
                Console.Write("Invalid input.");
                continue;
            }

            if (choiceMainMenu == MainMenuChoice.MainMenuMember)
            {
                MemberMenu(isGuestMode);
            }
            else if (choiceMainMenu == MainMenuChoice.MainMenuSubs)
            {
                SubsMenu(isGuestMode);
            }
            else if (choiceMainMenu == MainMenuChoice.MainMenuClass)
            {
                ClassMenu(isGuestMode);
            }
            else if (choiceMainMenu == MainMenuChoice.MainMenuPayment)
            {
                PaymentMenu(isGuestMode);
            }
            else if (choiceMainMenu == MainMenuChoice.MainMenuLogOut)
            {
                break;
            }
            else
            {
                Console.Write("\nPlease input a correct choice.");
            }
        }

        return 0;
    }

    /// <summary>
    /// Member menu.
    /// </summary>
    /// <param name="isGuestMode">A bool to check if user entered with guest mode.</param>
    /// <returns>0.</returns>
    public static int MemberMenu(bool isGuestMode)
    {
        SubMenuVariables SubMenu = new SubMenuVariables();
        while (true)
        {
            Console.Write("\n--------Memberships Menu--------" +
                          "\n1-)Show Memberships" +
                          "\n2-)Add Membership" +
                          "\n3-)Edit Memberships" +
                          "\n4-)Delete Memberships" +
                          "\n5-)Return to Main Menu" +
                          "\nPlease enter a choice:");
            int choiceMember;
            if (!int.TryParse(Console.ReadLine(), out choiceMember))
            {
                Console.Write("Invalid input.");
                continue;
            }

            if (choiceMember == SubMenu.SubMenuShow)
            {
                Console.Write("\n--------------Membership Records--------------\n");
                FileRead("member_records", true);
                continue;
            }
            else if (isGuestMode && (choiceMember == SubMenu.SubMenuAdd || choiceMember == SubMenu.SubMenuEdit || choiceMember == SubMenu.SubMenuDelete))
            {
                Console.Write("\nYou can only see records while in guest mode.");
                continue;
            }
            else if (choiceMember == SubMenu.SubMenuAdd)
            {
                AddMemberRecord();
                continue;
            }
            else if (choiceMember == SubMenu.SubMenuEdit)
            {
                EditMemberRecord();
                continue;
            }
            else if (choiceMember == SubMenu.SubMenuDelete)
            {
                DeleteMemberRecord();
                continue;
            }
            else if (choiceMember == SubMenu.SubMenuReturn)
            {
                break;
            }
            else
            {
                Console.Write("\nPlease input a correct choice.");
                continue;
            }
        }

        return 0;
    }
    /// <summary>
    /// Adds a new member record by collecting details from the user and writing to a file.
    /// </summary>
    /// <returns>Returns 0 upon successful completion.</returns>
    static int AddMemberRecord()
    {
        MemberRecord member;
        Console.Write("\nPlease enter memberID: ");
        member.memberID = Console.ReadLine();
        Console.Write("\nPlease enter full name: ");
        member.fullName = Console.ReadLine();
        Console.Write("\nPlease enter birth date: ");
        member.birthDate = Console.ReadLine();
        Console.Write("\nPlease enter phone number: ");
        member.phoneNumber = Console.ReadLine();
        Console.Write("\nPlease enter first registration date: ");
        member.firstRegistrationDate = Console.ReadLine();

        StringBuilder formattedRecord = new StringBuilder();
        formattedRecord.Append("MemberID:").Append(member.memberID)
                       .Append(" / Full name:").Append(member.fullName)
                       .Append(" / Birth date:").Append(member.birthDate)
                       .Append(" / Phone number:").Append(member.phoneNumber)
                       .Append(" / First registration date:").Append(member.firstRegistrationDate);
        string result = formattedRecord.ToString();

        if (CheckLCS(result, "member_records") == 0)
        {
            Console.Write("\nThere is a very similar record, Do you wish to add new record anyway?[Y/n]: ");
            char choice = Console.ReadKey().KeyChar;
            if (choice != 'Y')
            {
                return 0;
            }
        }

        string fileName = "member_records.bin";
        if (!File.Exists(fileName))
        {
            FileWrite("member_records", result, true);
        }
        else
        {
            FileAppend("member_records", result);
        }
        return 0;
    }

    /// <summary>
    /// Edits an existing member record by collecting new details from the user.
    /// </summary>
    /// <returns>Returns 0 upon successful completion, or -1 if the record number is invalid.</returns>
    static int EditMemberRecord()
    {
        MemberRecord member;
        int recordNumberToEdit;

        Console.Write("\nPlease enter record number to edit: ");
        recordNumberToEdit = int.Parse(Console.ReadLine());

        Console.Write("\nPlease enter memberID: ");
        member.memberID = Console.ReadLine();

        Console.Write("\nPlease enter full name: ");
        member.fullName = Console.ReadLine();

        Console.Write("\nPlease enter birth date: ");
        member.birthDate = Console.ReadLine();

        Console.Write("\nPlease enter phone number: ");
        member.phoneNumber = Console.ReadLine();

        Console.Write("\nPlease enter first registration date: ");
        member.firstRegistrationDate = Console.ReadLine();

        StringBuilder formattedRecord = new StringBuilder();
        formattedRecord.Append("MemberID:").Append(member.memberID)
                       .Append(" / Full name:").Append(member.fullName)
                       .Append(" / Birth date:").Append(member.birthDate)
                       .Append(" / Phone number:").Append(member.phoneNumber)
                       .Append(" / First registration date:").Append(member.firstRegistrationDate);
        string result = formattedRecord.ToString();

        if (FileEdit("member_records", recordNumberToEdit, result) == 0)
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }

    /// <summary>   
    /// Deletes an existing member record by its record number.
    /// </summary>
    /// <returns>Returns 0 upon successful completion, or -1 if the record number is invalid.</returns>
    static int DeleteMemberRecord()
    {
        Console.Write("\nPlease enter record number to delete: ");
        int recordNumberToDelete = int.Parse(Console.ReadLine());

        if (FileLineDelete("member_records", recordNumberToDelete) == 0)
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }

    /// <summary>
    /// Subscriptions menu.
    /// </summary>
    /// <param name="isGuestMode">A bool to check if user entered with guest mode.</param>
    /// <returns>0.</returns>
    public static int SubsMenu(bool isGuestMode)
    {
        SubMenuVariables SubMenu = new SubMenuVariables();
        while (true)
        {
            Console.Write("\n--------Subscriptions Menu--------" +
                          "\n1-)Show Subscriptions" +
                          "\n2-)Add Subscription" +
                          "\n3-)Edit Subscriptions" +
                          "\n4-)Delete Subscriptions" +
                          "\n5-)Return to Main Menu" +
                          "\nPlease enter a choice:");
            int choiceSub;
            if (!int.TryParse(Console.ReadLine(), out choiceSub))
            {
                Console.Write("Invalid input.");
                continue;
            }

            if (choiceSub == SubMenu.SubMenuShow)
            {
                Console.Write("\n--------------Membership Records--------------\n");
                FileRead("subscription_records", true);
                continue;
            }
            else if (isGuestMode && (choiceSub == SubMenu.SubMenuAdd || choiceSub == SubMenu.SubMenuEdit || choiceSub == SubMenu.SubMenuDelete))
            {
                Console.Write("\nYou can only see records while in guest mode.");
                continue;
            }
            else if (choiceSub == SubMenu.SubMenuAdd)
            {
                AddSubsRecord();
                continue;
            }
            else if (choiceSub == SubMenu.SubMenuEdit)
            {
                EditSubsRecord();
                continue;
            }
            else if (choiceSub == SubMenu.SubMenuDelete)
            {
                DeleteSubsRecord();
                continue;
            }
            else if (choiceSub == SubMenu.SubMenuReturn)
            {
                break;
            }
            else
            {
                Console.Write("\nPlease input a correct choice.");
                continue;
            }
        }

        return 0;
    }
    /// <summary>
    /// Adds a new member record by collecting details from the user and writing to a file.
    /// </summary>
    /// <returns>Returns 0 upon successful completion.</returns>
    static int AddSubsRecord(){
        SubscriptionRecord sub;
        Console.Write("\nPlease enter memberID: ");
        sub.memberID = Console.ReadLine();
        Console.Write("\nPlease enter starting date: ");
        sub.startingDate = Console.ReadLine();
        Console.Write("\nPlease enter finishing date: ");
        sub.finishingDate = Console.ReadLine();
        Console.Write("\nPlease enter subscription tier: ");
        sub.subscriptionTier = Console.ReadLine();
        

        StringBuilder formattedRecord = new StringBuilder();
        formattedRecord.Append("MemberID:").Append(sub.memberID)
                       .Append(" / Starting Date:").Append(sub.startingDate)
                       .Append(" / Finishing Date:").Append(sub.finishingDate)
                       .Append(" / Subscription Tier:").Append(sub.subscriptionTier);
        string result = formattedRecord.ToString();

        if (CheckLCS(result, "subscription_records") == 0)
        {
            Console.Write("\nThere is a very similar record, Do you wish to add new record anyway?[Y/n]: ");
            char choice = Console.ReadKey().KeyChar;
            if (choice != 'Y')
            {
                return 0;
            }
        }

        string fileName = "subscription_records.bin";
        if (!File.Exists(fileName))
        {
            FileWrite("subscription_records", result, true);
        }
        else
        {
            FileAppend("subscription_records", result);
        }
         return 0;
    }
    /// <summary>
    /// Edits an existing member record by collecting new details from the user.
    /// </summary>
    /// <returns>Returns 0 upon successful completion, or -1 if the record number is invalid </returns>
    static int EditSubsRecord(){
        SubscriptionRecord sub;
        int recordNumberToEdit;

        Console.Write("\nPlease enter record number to edit: ");
        recordNumberToEdit = int.Parse(Console.ReadLine());

        Console.Write("\nPlease enter memberID: ");
        sub.memberID = Console.ReadLine();
        Console.Write("\nPlease enter starting date: ");
        sub.startingDate = Console.ReadLine();
        Console.Write("\nPlease enter finishing date: ");
        sub.finishingDate = Console.ReadLine();
        Console.Write("\nPlease enter subscription tier: ");
        sub.subscriptionTier = Console.ReadLine();
        

        StringBuilder formattedRecord = new StringBuilder();
        formattedRecord.Append("MemberID:").Append(sub.memberID)
                       .Append(" / Starting Date:").Append(sub.startingDate)
                       .Append(" / Finishing Date:").Append(sub.finishingDate)
                       .Append(" / Subscription Tier:").Append(sub.subscriptionTier);
        string result = formattedRecord.ToString();
         if(FileEdit("subscription_records",recordNumberToEdit,result) == 0)
         {
            return 0;
         }
         else
         {
            return -1;
         }
    }
    /// <summary>   
    /// Deletes an existing member record by its record number.
    /// </summary>
    /// <returns>Returns 0 upon successful completion, or -1 if the record number is invalid.</returns>
    static int DeleteSubsRecord(){
        Console.Write("\nPlease enter record number to delete: ");
        int recordNumberToDelete = int.Parse(Console.ReadLine());

        if (FileLineDelete("subscription_records", recordNumberToDelete) == 0)
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }
    /// <summary>
    /// Class menu.
    /// </summary>
    /// <param name="isGuestMode">A bool to check if user entered with guest mode.</param>
    /// <returns>0.</returns>
    public static int ClassMenu(bool isGuestMode)
    {
        SubMenuVariables SubMenu = new SubMenuVariables();
        while (true)
        {
            Console.Write("\n--------Classes Menu--------" +
                          "\n1-)Show Classes" +
                          "\n2-)Add Class" +
                          "\n3-)Edit Classes" +
                          "\n4-)Delete Classes" +
                          "\n5-)Return to Main Menu" +
                          "\nPlease enter a choice:");
            int choiceClass;
            if (!int.TryParse(Console.ReadLine(), out choiceClass))
            {
                Console.Write("Invalid input.");
                continue;
            }

            if (choiceClass == SubMenu.SubMenuShow)
            {
                Console.Write("\n--------------Class Records--------------\n");
                FileRead("class_records", true);
                continue;
            }
            else if (isGuestMode && (choiceClass == SubMenu.SubMenuAdd || choiceClass == SubMenu.SubMenuEdit || choiceClass == SubMenu.SubMenuDelete))
            {
                Console.Write("\nYou can only see records while in guest mode.");
                continue;
            }
            else if (choiceClass == SubMenu.SubMenuAdd)
            {
                AddClassRecord();
                continue;
            }
            else if (choiceClass == SubMenu.SubMenuEdit)
            {
                EditClassRecord();
                continue;
            }
            else if (choiceClass == SubMenu.SubMenuDelete)
            {
                DeleteClassRecord();
                continue;
            }
            else if (choiceClass == SubMenu.SubMenuReturn)
            {
                break;
            }
            else
            {
                Console.Write("\nPlease input a correct choice.");
                continue;
            }
        }

        return 0;
    }
    /// <summary>
    /// Adds a new member record by collecting details from the user and writing to a file.
    /// </summary>
    /// <returns>Returns 0 upon successful completion.</returns>
    static int AddClassRecord(){
        ClassRecord classes;

        Console.Write("\nPlease enter tutor: ");
        classes.tutor = Console.ReadLine();
        Console.Write("\nPlease enter date: ");
        classes.date = Console.ReadLine();
        Console.Write("\nPlease enter starting hour: ");
        classes.startingHour = Console.ReadLine();
        Console.Write("\nPlease enter finishing hour: ");
        classes.finishingHour = Console.ReadLine();
        Console.Write("\nPlease enter student list: ");
        classes.studentList = Console.ReadLine();

        StringBuilder formattedRecord = new StringBuilder();
        formattedRecord.Append("Tutor:").Append(classes.tutor)
                       .Append(" / Date:").Append(classes.date)
                       .Append(" / Starting Hour:").Append(classes.startingHour)
                       .Append(" / Finishing Hour:").Append(classes.finishingHour)
                       .Append(" / Student List:").Append(classes.tutor);
        string result = formattedRecord.ToString();

        

        if (CheckLCS(result, "class_records") == 0)
        {
            Console.Write("\nThere is a very similar record, Do you wish to add new record anyway?[Y/n]: ");
            char choice = Console.ReadKey().KeyChar;
            if (choice != 'Y')
            {
                return 0;
            }
        }

        string fileName = "class_records.bin";
        if (!File.Exists(fileName))
        {
            FileWrite("class_records", result, true);
        }
        else
        {
            FileAppend("class_records", result);
        }
         return 0;
    }
    /// <summary>
    /// Edits an existing member record by collecting new details from the user.
    /// </summary>
    /// <returns>Returns 0 upon successful completion, or -1 if the record number is invalid </returns>
    static int EditClassRecord(){

        ClassRecord classes;

        int recordNumberToEdit;

        Console.Write("\nPlease enter record number to edit: ");
        recordNumberToEdit = int.Parse(Console.ReadLine());

        Console.Write("\nPlease enter tutor: ");
        classes.tutor = Console.ReadLine();
        Console.Write("\nPlease enter date: ");
        classes.date = Console.ReadLine();
        Console.Write("\nPlease enter starting hour: ");
        classes.startingHour = Console.ReadLine();
        Console.Write("\nPlease enter finishing hour: ");
        classes.finishingHour = Console.ReadLine();
        Console.Write("\nPlease enter student list: ");
        classes.studentList = Console.ReadLine();

        StringBuilder formattedRecord = new StringBuilder();
        formattedRecord.Append("Tutor:").Append(classes.tutor)
                       .Append(" / Date:").Append(classes.date)
                       .Append(" / Starting Hour:").Append(classes.startingHour)
                       .Append(" / Finishing Hour:").Append(classes.finishingHour)
                       .Append(" / Student List:").Append(classes.tutor);
        string result = formattedRecord.ToString();

        if(FileEdit("class_records",recordNumberToEdit,result) == 0)
        {
         return 0;
        }
        else 
        {
          return -1;
        }
    }
    /// <summary>   
    /// Deletes an existing member record by its record number.
    /// </summary>
    /// <returns>Returns 0 upon successful completion, or -1 if the record number is invalid.</returns>
    static int DeleteClassRecord(){
        Console.Write("\nPlease enter record number to delete: ");
        int recordNumberToDelete = int.Parse(Console.ReadLine());

        if (FileLineDelete("class_records", recordNumberToDelete) == 0)
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }

    /// <summary>
    /// Payment menu.
    /// </summary>
    /// <param name="isGuestMode">A bool to check if user entered with guest mode.</param>
    /// <returns>0.</returns>
    public static int PaymentMenu(bool isGuestMode)
    {
        SubMenuVariables SubMenu = new SubMenuVariables();
        while (true)
        {
            Console.Write("\n--------Payments Menu--------" +
                          "\n1-)Show Payments" +
                          "\n2-)Add Payment" +
                          "\n3-)Edit Payments" +
                          "\n4-)Delete Payments" +
                          "\n7-)Return to Main Menu" +
                          "\nPlease enter a choice:");
            int choicePayment;
            if (!int.TryParse(Console.ReadLine(), out choicePayment))
            {
                Console.Write("Invalid input.");
                continue;
            }

            if (choicePayment == SubMenu.SubMenuShow)
            {
                Console.Write("\n--------------Payment Records--------------\n");
                FileRead("payment_records", true);
                continue;
            }
            else if (isGuestMode && (choicePayment == SubMenu.SubMenuAdd || choicePayment == SubMenu.SubMenuEdit || choicePayment == SubMenu.SubMenuDelete))
            {
                Console.Write("\nYou can only see records while in guest mode.");
                continue;
            }
            else if (choicePayment == SubMenu.SubMenuAdd)
            {
                AddPaymentRecord();
                continue;
            }
            else if (choicePayment == SubMenu.SubMenuEdit)
            {
                EditPaymentRecord();
                continue;
            }
            else if (choicePayment == SubMenu.SubMenuDelete)
            {
                DeletePaymentRecord();
                continue;
            }
            else if (choicePayment == SubMenu.SubMenuReturn)
            {
                break;
            }
            else
            {
                Console.Write("\nPlease input a correct choice.");
                continue;
            }
        }

        return 0;
    }
    /// <summary>
    /// Adds a new member record by collecting details from the user and writing to a file.
    /// </summary>
    /// <returns>Returns 0 upon successful completion.</returns>
    static int AddPaymentRecord(){
        PaymentRecord payment;
        Console.Write("\nPlease enter memberID: ");
        payment.memberID = Console.ReadLine();
        Console.Write("\nPlease enter paid amount: ");
        payment.paidAmount = Console.ReadLine();
        Console.Write("\nPlease enter payment date: ");
        payment.paymentDate = Console.ReadLine();
        Console.Write("\nPlease enter next payment date: ");
        payment.nextPaymentDate = Console.ReadLine();
        

        StringBuilder formattedRecord = new StringBuilder();
        formattedRecord.Append("MemberID:").Append(payment.memberID)
                       .Append(" / Paid Amount:").Append(payment.paidAmount)
                       .Append(" / Payment date:").Append(payment.paymentDate)
                       .Append(" / Next Payment date:").Append(payment.nextPaymentDate);
        string result = formattedRecord.ToString();

        if (CheckLCS(result, "payment_records") == 0)
        {
            Console.Write("\nThere is a very similar record, Do you wish to add new record anyway?[Y/n]: ");
            char choice = Console.ReadKey().KeyChar;
            if (choice != 'Y')
            {
                return 0;
            }
        }

        string fileName = "payment_records.bin";
        if (!File.Exists(fileName))
        {
            FileWrite("payment_records", result, true);
        }
        else
        {
            FileAppend("payment_records", result);
        }
         return 0;
    }
    /// <summary>
    /// Edits an existing member record by collecting new details from the user.
    /// </summary>
    /// <returns>Returns 0 upon successful completion, or -1 if the record number is invalid </returns>
    static int EditPaymentRecord(){
        PaymentRecord payment;
        int recordNumberToEdit;

        Console.Write("\nPlease enter record number to edit: ");
        recordNumberToEdit = int.Parse(Console.ReadLine());

         Console.Write("\nPlease enter memberID: ");
        payment.memberID = Console.ReadLine();
        Console.Write("\nPlease enter paid amount: ");
        payment.paidAmount = Console.ReadLine();
        Console.Write("\nPlease enter payment date: ");
        payment.paymentDate = Console.ReadLine();
        Console.Write("\nPlease enter next payment date: ");
        payment.nextPaymentDate = Console.ReadLine();
        

        StringBuilder formattedRecord = new StringBuilder();
        formattedRecord.Append("MemberID:").Append(payment.memberID)
                       .Append(" / Paid Amount:").Append(payment.paidAmount)
                       .Append(" / Payment date:").Append(payment.paymentDate)
                       .Append(" / Next Payment date:").Append(payment.nextPaymentDate);
        string result = formattedRecord.ToString();
        if(FileEdit("payment_records",recordNumberToEdit,result) == 0)
        {
            return 0;
        }
        else 
        {
           return -1;
        }
    }
    /// <summary>   
    /// Deletes an existing member record by its record number.
    /// </summary>
    /// <returns>Returns 0 upon successful completion, or -1 if the record number is invalid.</returns>
    static int DeletePaymentRecord(){
        
        Console.Write("\nPlease enter record number to delete: ");
        int recordNumberToDelete = int.Parse(Console.ReadLine());

        if (FileLineDelete("payment_records", recordNumberToDelete) == 0)
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }

}
}
