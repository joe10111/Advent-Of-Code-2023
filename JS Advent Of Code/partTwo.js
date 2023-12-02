const fs = require('fs');
const filePath = "/Users/joe/Projects/AdventOfCode/AdventOfCode/Day1P1Input.txt";

const digitWordsMap = {
    'one': '1', 'two': '2', 'three': '3', 'four': '4',
    'five': '5', 'six': '6', 'seven': '7', 'eight': '8',
    'nine': '9'
};

function replaceNumberWordsInString(line) {
    let result = line;
    for (const [word, number] of Object.entries(digitWordsMap)) {
        const regex = new RegExp(word, 'gi');
        result = result.replace(regex, number);
    }
    return result;
}

function parseCalibrationValueFrom(line) {
    const transformedLine = replaceNumberWordsInString(line);
    const digits = transformedLine.match(/\d/g);

    if (digits && digits.length >= 2) {
        return parseInt(digits[0] + digits[digits.length - 1], 10);
    } else if (digits && digits.length === 1) {
        return parseInt(digits[0] + digits[0], 10);
    }
    return 0;
}

fs.readFile(filePath, 'utf8', (err, data) => {
    if (err) {
        console.error(err);
        return;
    }

    const totalCalibrationValue = data.split('\n')
                                      .map(parseCalibrationValueFrom)
                                      .reduce((sum, val) => sum + val, 0);

    console.log(`Total Calibration Value: ${totalCalibrationValue}`);
});
