﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FitnessLibrary {
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
    private List<T> data;
    private readonly IComparer<T> comparer;
    public int Count
    {
        get { return data.Count; }
    }

    public PriorityQueue(IComparer<T> comparer)
    {
        data = new List<T>();
        this.comparer = comparer;
    }

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

    public T Dequeue()
    {
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
                Console.WriteLine("Character '_' is missing in the codes dictionary");
        }
        else
        {
            if (codes.ContainsKey(ch))
                encodedText += codes[ch];
            else
                Console.WriteLine("Character '" + ch + "' is missing in the codes dictionary");
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

        public static Node ReadTreeFromFile(StreamReader reader)
        {
            int marker = reader.Read();
    
            if (marker == -1)
            {
                Console.WriteLine("End of file reached!");
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
                Console.WriteLine("Invalid marker in file!");
                return null;
            }
        }
}

public class SHA1
{
    public static string CalculateSHA1(string input)
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

public class Fitness {

private static Huffman huffman = new Huffman();

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
    // Create a 2D array to store the length of the LCS for substrings of text1 and text2
    int[,] dp = new int[m + 1, n + 1];

    // Fill the dp table using bottom-up dynamic programming approach
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

    // Reconstruct the LCS from dp table
    int x = m, y = n;
    string lcs = "";

    while (x > 0 && y > 0)
    {
        if (text1[x - 1] == text2[y - 1])
        {
            lcs = text1[x - 1] + lcs;
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

    return lcs;
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
            // Get the size of the file
            long fileSize = fileStream.Length;
            // Read the entire file into a byte array
            byte[] buffer = new byte[fileSize];
            int bytesRead = fileStream.Read(buffer, 0, buffer.Length);
            // Convert the byte array to a string
            string content = System.Text.Encoding.Default.GetString(buffer, 0, bytesRead);
            // Decode the content
            using (StreamReader inFile = new StreamReader(fileName + "_huffman.bin"))
            {
                Node root = Huffman.ReadTreeFromFile(inFile);
                string decodedText = huffman.Decode(content, root);
                // Split decoded text into lines
                string[] lines = decodedText.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                // Iterate through lines
                foreach (string line in lines)
                {
                    string recordLCS = LCS(line, text);
                    double similarity = ((double)recordLCS.Length / (double)line.Length) * 100;
                    double limit = 85;

                    if (similarity >= limit)
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

    return -1;
}
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
                Console.WriteLine(decodedText);
            }

            return decodedText;
        }
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine("File operation failed, There is no record");
        return "-1";
    }
    catch (IOException)
    {
        Console.WriteLine("File operation failed, There is no record");
        return "-1";
    }
}

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
            Console.WriteLine("File operation failed, There is no record");
            return "-1";
        }
        catch (IOException)
        {
            Console.WriteLine("File operation failed, There is no record");
            return "-1";
        }
    }

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
            Console.WriteLine("\nYou can only edit existing lines");
            return -1;
        }

        string newFileContent = string.Join("", lines);
        FileWrite(fileName, newFileContent, false);
        Console.WriteLine("\nData successfully edited");
        return 0;
    }

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
            Console.WriteLine("\nYou can only erase existing lines");
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
        Console.WriteLine("\nData successfully deleted");
        return 0;
    }
}
}
