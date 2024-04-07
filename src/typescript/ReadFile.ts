import * as fs from 'fs';

class ReadFile {
    public static main(): void {
        // Read transactions from input file
        const inputFilePath = 'input.txt';
        const transactions: string[] = fs.readFileSync(inputFilePath, 'utf8').split('\n').map(line => line.trim());

        // Convert transactions to JSON string
        const jsonTransactions = JSON.stringify(transactions);

        // Write JSON transactions to a file
        const javaInputFilePath = '../java/java_input.json';
        fs.writeFileSync(javaInputFilePath, jsonTransactions);

        console.log("Transactions prepared for Java. Executing Java code...");
    }
}

// Call the main method
ReadFile.main();