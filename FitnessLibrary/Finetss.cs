using System;
using System.Collections.Generic;
using System.IO;

namespace FitnessLibrary {
public class Fitness {
    /// <summary>
/// Huffman tree node class.
/// </summary>
public class Node
{
    /// <summary>
    /// Character data stored in the node.
    /// </summary>
    public char Data { get; set; }
    /// <summary>
    /// Frequency of the character.
    /// </summary>
    public int Freq { get; set; }
    /// <summary>
    /// Left child node.
    /// </summary>
    public Node Left { get; set; }
    /// <summary>
    /// Right child node.
    /// </summary>
    public Node Right { get; set; }

    /// <summary>
    /// Constructs a new Node object.
    /// </summary>
    /// <param name="data">Character stored in the node.</param>
    /// <param name="freq">Frequency of the character.</param>
    public Node(char data, int freq)
    {
        Data = data;
        Freq = freq;
        Left = null;
        Right = null;
    }
}

/// <summary>
/// Comparison class for the priority queue.
/// </summary>
public class Compare : IComparer<Node>
{
    /// <summary>
    /// Compares two Node objects based on their frequencies.
    /// </summary>
    /// <param name="a">First Node object.</param>
    /// <param name="b">Second Node object.</param>
    /// <returns>true if frequency of 'a' is less than frequency of 'b', else false.</returns>
    public int CompareNodes(Node a, Node b)
    {
        if (a.Freq == b.Freq)
            return a.Data.CompareTo(b.Data); // If frequencies are equal, order by character

        return a.Freq.CompareTo(b.Freq);
    }
}

/// <summary>
/// Huffman encoding and decoding class.
/// </summary>
public class Huffman
{
    /// <summary>
    /// Calculates frequency of characters in the input text.
    /// </summary>
    /// <param name="text">Input text.</param>
    /// <returns>Dictionary containing character frequencies.</returns>
    public Dictionary<char, int> CalculateFrequency(string text)
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
    /// <param name="freqMap">Frequency map of characters.</param>
    /// <returns>Root of the Huffman tree.</returns>
    public Node BuildHuffmanTree(Dictionary<char, int> freqMap)
    {
        PriorityQueue<Node> pq = new PriorityQueue<Node>(new Compare().CompareNodes);

        // Create leaf nodes and add them to the priority queue
        foreach (var entry in freqMap)
        {
            pq.Enqueue(new Node(entry.Key, entry.Value));
        }

        // Merge nodes until there's only one node left in the queue
        while (pq.Count > 1)
        {
            Node left = pq.Dequeue();
            Node right = pq.Dequeue();
            // Create a new internal node with combined frequency
            Node newNode = new Node('$', left.Freq + right.Freq);
            newNode.Left = left;
            newNode.Right = right;
            // Add the new node back to the priority queue
            pq.Enqueue(newNode);
        }

        // Return the root of the Huffman tree
        return pq.Dequeue();
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

        // Traverse left and right
        BuildCodes(root.Left, code + "0", codes);
        BuildCodes(root.Right, code + "1", codes);
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
                encodedText += codes['_'];
            }
            else
            {
                encodedText += codes[ch];
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
    public string Decode(string encodedText, Node root)
    {
        string decodedText = "";
        Node current = root;

        foreach (char bit in encodedText)
        {
            if (bit == '0')
            {
                current = current.Left;
            }
            else
            {
                current = current.Right;
            }

            if (current.Left == null && current.Right == null)
            {
                decodedText += current.Data;
                current = root; // Reset current to root for next character
            }
        }

        return decodedText;
    }
}

/// <summary>
/// Priority queue implementation.
/// </summary>
/// <typeparam name="T">Type of elements in the queue.</typeparam>
public class PriorityQueue<T>
{
    private List<T> data;
    private IComparer<T> comparer;

    public int Count { get { return data.Count; } }

    public PriorityQueue(IComparer<T> comparer)
    {
        this.data = new List<T>();
        this.comparer = comparer;
    }

    public void Enqueue(T item)
    {
        data.Add(item);
        int childIndex = data.Count - 1;
        while (childIndex > 0)
        {
            int parentIndex = (childIndex - 1) / 2;
            if (comparer.CompareNodes(data[childIndex], data[parentIndex]) >= 0)
                break;
            T tmp = data[childIndex];
            data[childIndex] = data[parentIndex];
            data[parentIndex] = tmp;
            childIndex = parentIndex;
        }
    }

    public T Dequeue()
    {
        int lastIndex = data.Count - 1;
        T frontItem = data[0];
        data[0] = data[lastIndex];
        data.RemoveAt(lastIndex);

        --lastIndex;
        int parentIndex = 0;
        while (true)
        {
            int childIndex = parentIndex * 2 + 1;
            if (childIndex > lastIndex)
                break;
            int rightChildIndex = childIndex + 1;
            if (rightChildIndex <= lastIndex && comparer.CompareNodes(data[rightChildIndex], data[childIndex]) < 0)
                childIndex = rightChildIndex;
            if (comparer.CompareNodes(data[parentIndex], data[childIndex]) <= 0)
                break;
            T tmp = data[parentIndex];
            data[parentIndex] = data[childIndex];
            data[childIndex] = tmp;
            parentIndex = childIndex;
        }
        return frontItem;
    }

    public T Peek()
    {
        T frontItem = data[0];
        return frontItem;
    }
}
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
            // Read the entire file into a string
            byte[] buffer = new byte[fileSize];
            fileStream.Read(buffer, 0, buffer.Length);
            string content = System.Text.Encoding.Default.GetString(buffer);
            // Close the file
            fileStream.Close();
            // Decode the content
            using (FileStream huffmanFileStream = new FileStream(fileName + "_huffman.bin", FileMode.Open, FileAccess.Read))
            {
                Node root = ReadTreeFromFile(huffmanFileStream);
                string decodedText = Decode(content, root);
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

        Dictionary<char, int> freqMap = CalculateFrequency(text);
        Node root = BuildHuffmanTree(freqMap);
        Dictionary<char, string> codes = new Dictionary<char, string>();
        BuildCodes(root, "", codes);
        string encodedText = Encode(text, codes);

        using (FileStream outFile = new FileStream(fileName + ".bin", FileMode.Create, FileAccess.Write))
        {
            foreach (char i in encodedText)
            {
                outFile.WriteByte((byte)i);
            }
        }

        using (FileStream outFileHuffman = new FileStream(fileName + "_huffman.bin", FileMode.Create, FileAccess.Write))
        {
            WriteTreeToFile(outFileHuffman, root);
        }

        return 0;
    }

    public static string FileRead(string fileName, bool printToConsole)
    {
        try
        {
            using (FileStream myFile = new FileStream(fileName + ".bin", FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[myFile.Length];
                myFile.Read(buffer, 0, buffer.Length);
                string content = System.Text.Encoding.Default.GetString(buffer);

                using (FileStream inFile = new FileStream(fileName + "_huffman.bin", FileMode.Open, FileAccess.Read))
                {
                    Node root = ReadTreeFromFile(inFile);
                    string decodedText = Decode(content, root);

                    if (printToConsole)
                    {
                        Console.WriteLine(decodedText);
                    }

                    return decodedText;
                }
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
        char mode = 'N';
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
        char mode = 'N';
        string fileContent = FileRead(fileName, mode);

        if (fileContent == "-1")
        {
            return -1;
        }

        string[] lines = fileContent.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        int lineCount = lines.Length; // A variable for an if statement to check if the line that the user wants to edit exists

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
        char mode = 'N';
        string fileContent = FileRead(fileName, mode);

        if (fileContent == "-1")
        {
            return -1;
        }

        string[] lines = fileContent.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        int lineCount = lines.Length; // A variable for an if statement to check if the line that the user wants to edit exists

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

        string newFileContent = string.Join("\n", newLines);
        FileWrite(fileName, newFileContent, false);
        Console.WriteLine("\nData successfully deleted");
        return 0;
    }
}
}
