using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

public class TillManager {
    public static void Main(string[] args) {
        // Read the output from Java program
        string[] transactions = ReadTransactionsFromJava();

        // Process transactions and get the output
        string[] output = ProcessTransactions(transactions);

        // Write the formatted output to an output file
        WriteOutputToFile(output);

        Console.WriteLine("Output written to output.txt");
    }

    private static string[] ReadTransactionsFromJava() {
        string javaInputFilePath = "C:/nande/OneDrive/Desktop/Till Manager/src/java/java_input.json"; // Update the path to point to the correct directory
        Console.WriteLine("Java input file path: " + javaInputFilePath);
        try {
            string jsonString = File.ReadAllText(javaInputFilePath);
            JArray transactionsArray = JArray.Parse(jsonString);
            List<string> transactions = new List<string>();

            foreach (JToken transactionToken in transactionsArray) {
                string transaction = (string)transactionToken;
                transactions.Add(transaction);
            }

            Console.WriteLine("Number of transactions read: " + transactions.Count);
            return transactions.ToArray();
        } catch (Exception ex) {
            Console.WriteLine("Error reading transactions from Java input file: " + ex.Message);
            return new string[0]; // Return an empty array if there's an error
        }
    }

    private static string[] ProcessTransactions(string[] transactions) {
        List<string> output = new List<string>();
        foreach (string transaction in transactions) {
            try {
                Console.WriteLine("Processing transaction: " + transaction);

                // Split the transaction into items and amount paid
                string[] parts = transaction.Split('-');
                string[] items = parts[0].Split(';');
                string[] amountsPaid = parts[1].Split('-')[1].Split(',');

                // Calculate total transaction cost
                int transactionTotal = 0;
                foreach (string item in items) {
                    string[] itemParts = item.Trim().Split(' ');
                    transactionTotal += int.Parse(itemParts[itemParts.Length - 1].Substring(1));
                }

                // Calculate total amount paid
                int amountPaid = 0;
                foreach (string amount in amountsPaid) {
                    amountPaid += int.Parse(amount.Substring(1));
                }

                // Calculate change
                int changeTotal = amountPaid - transactionTotal;

                // Format change breakdown
                string changeBreakdown = GetChangeBreakdown(changeTotal);

                // Format output
                string transactionOutput = string.Format("Total: {0}, Paid: {1}, Change: {2}, Breakdown: {3}",
                    transactionTotal, amountPaid, changeTotal, changeBreakdown);

                output.Add(transactionOutput);

            } catch (Exception ex) {
                Console.WriteLine("Error processing transaction: " + ex.Message);
            }
        }
        return output.ToArray();
    }

    private static string GetChangeBreakdown(int changeTotal) {
        // Implement change breakdown logic here
        return "Change breakdown";
    }

    private static void WriteOutputToFile(string[] output) {
        string outputFilePath = "output.txt"; // Store output file in the same directory
        try {
            File.WriteAllLines(outputFilePath, output);
        } catch (Exception ex) {
            Console.WriteLine("Error writing output to file: " + ex.Message);
        }
    }
}