const fileStream = require('fs');

filePath = "/Users/joe/Projects/AdventOfCode/AdventOfCode/Day1P1Input.txt";


// Read the file
fileStream.readFile(filePath, 'utf8', (err, data) => {
    if (err) {
        console.error(err);
        return;
    }

    // Split the data into lines and process each line
    const totalCalibrationValue = data.split('\n').map(line => {
        const digits = line.match(/\d/g); // Extract all digits from the line
        if (digits && digits.length >= 2) {
            // Combine the first and last digit
            return parseInt(digits[0] + digits[digits.length - 1], 10);
        } else if (digits && digits.length === 1) {
            // If only one digit, duplicate it
            return parseInt(digits[0] + digits[0], 10);
        }
        return 0; // Return 0 if no digits are found
    }).reduce((sum, val) => sum + val, 0); // Sum up all the values

    console.log(`Total Calibration Value: ${totalCalibrationValue}`);
});