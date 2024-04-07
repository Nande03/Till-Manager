import java.util.ArrayList;
import java.util.List;

public class ProcessTransactions {

    public static void main(String[] args) {
        // Sample input data
        String[] transactions = {
                "Fresh full cream milk R30;Free range large eggs R24,R20-R20-R20",
                // Add more transactions here...
        };

        // Process transactions and print the output
        String[] output = processTransactions(transactions);
        for (String line : output) {
            System.out.println(line);
        }
    }

    private static String[] processTransactions(String[] transactions) {
        List<String> output = new ArrayList<>();

        for (String transaction : transactions) {
            try {
                String[] parts = transaction.split(";");
                String[] items = parts[0].split(",");
                int amountPaid = parseAmountPaid(parts[1]);

                int transactionTotal = calculateTransactionTotal(items);
                int changeTotal = amountPaid - transactionTotal;
                String changeBreakdown = getChangeBreakdown(changeTotal);

                String transactionOutput = String.format("Total: %d, Paid: %d, Change: %d, Breakdown: %s",
                        transactionTotal, amountPaid, changeTotal, changeBreakdown);
                output.add(transactionOutput);
            } catch (NumberFormatException | ArrayIndexOutOfBoundsException e) {
                output.add("Error processing transaction: " + e.getMessage());
            }
        }

        return output.toArray(new String[0]);
    }

    private static int parseAmountPaid(String amountPart) {
        String[] amounts = amountPart.split(",");
        int total = 0;
        for (String amount : amounts) {
            String trimmedAmount = amount.trim();
            if (trimmedAmount.startsWith("R")) {
                total += Integer.parseInt(trimmedAmount.split("-")[0].substring(1));
            }
        }
        return total;
    }

    private static int calculateTransactionTotal(String[] items) {
        int total = 0;
        for (String item : items) {
            total += Integer.parseInt(item.trim().split(" ")[item.trim().split(" ").length - 1].substring(1));
        }
        return total;
    }

    private static String getChangeBreakdown(int changeTotal) {
        // Implement change breakdown logic here
        return "Change breakdown";
    }
}