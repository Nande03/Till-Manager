"use strict";
// ReadFile.ts
Object.defineProperty(exports, "__esModule", { value: true });
var fs = require("fs");
var ReadFile = /** @class */ (function () {
    function ReadFile() {
    }
    ReadFile.main = function () {
        // Read transactions from input file
        var inputFilePath = 'input.txt';
        var transactions = fs.readFileSync(inputFilePath, 'utf8').split('\n').map(function (line) { return line.trim(); });
        // Prepare transactions for Java
        var javaInput = JSON.stringify(transactions);
        // Write the transactions in a format that Java can understand to a temporary file
        var javaInputFilePath = '../java/java_input.json';
        fs.writeFileSync(javaInputFilePath, javaInput);
        console.log("Transactions prepared for Java. Executing Java code...");
    };
    return ReadFile;
}());
// Call the main method
ReadFile.main();
