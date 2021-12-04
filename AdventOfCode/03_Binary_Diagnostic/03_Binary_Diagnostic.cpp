#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <bitset>
#include <conio.h>

using namespace std;

unsigned int dataWidth = 0u;


unsigned int buildMaskFromDataLength() {
    unsigned int mask = 0u;
    for (unsigned int i = 0; i < dataWidth; i++) {
        mask = mask << 1;
        mask |= 1;
    }
    return mask;
}


bool findMostCommonBit(std::vector<unsigned int> input, unsigned int mask) {
    int countOnes = 0;
    int countZeros = 0;

    for (unsigned int val : input) {

        if ((val & mask) == 0) {
            countZeros++;
        }
        else
        {
            countOnes++;
        }
    }
    return countOnes > countZeros ? 1 : 0;
}


bool findLeastCommonBit(std::vector<unsigned int> input, unsigned int mask) {
    return !findMostCommonBit(input, mask);
}


unsigned int assembleGamma(std::vector<unsigned int> input) {
    unsigned int value = 0x0u;

    for (unsigned int i = 0; i < dataWidth; i++) {
        unsigned int position = dataWidth - 1 - i;
        value |= findMostCommonBit(input, 1 << position) << position;
    }
    return value & buildMaskFromDataLength();
}


unsigned int assembleEpsilon(std::vector<unsigned int> input) {
    return (~assembleGamma(input)) & buildMaskFromDataLength();
}


void printResultTask1(unsigned int gamma, unsigned int epsilon) {
    cout << "Task1: gamma: " << gamma << " / epsilon: " << epsilon << " / product " << gamma * epsilon << endl;
}


void waitForKeyPress() {
    cout << "Press any key to continue..." << endl;
    _getch();
}


vector<unsigned int> readFileContent(string filename)
{
    std::ifstream myfile;
    myfile.open(filename);

    std::vector<unsigned int> fileContent;
    string line;

    while (getline(myfile, line)) {
        unsigned int lineLength = line.length();
        if (dataWidth < lineLength)
            dataWidth = lineLength;
        fileContent.push_back(static_cast<unsigned int>(std::stoi(line, nullptr, 2)));
    }
    return fileContent;
}


int main()
{
    vector<unsigned int> fileContent = readFileContent("input.txt");
    printResultTask1(assembleGamma(fileContent), assembleEpsilon(fileContent));
    waitForKeyPress();
}
