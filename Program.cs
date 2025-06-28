// This is an assembler for my assembly language
//     Copyright (C) 2025  536Cats

//     This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.

//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.

//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <https://www.gnu.org/licenses/>.

public class Assembler {
    public static FileStream output;
    public static void Main(string[] args) {
        if (args.Length <= 0) {
            Console.WriteLine("Please run the program with the file path " +
                              "passed in as an argument");
            System.Environment.Exit(1);
        }
        output = File.Open("output.53608", FileMode.Create);
        string[] code = File.ReadAllLines(args[0]);
        foreach (string instruction in code)
            AssembleInstruction(instruction.Split(' '));
        output.Close();
    }
    public static void AssembleInstruction(string[] instruction) {
        string opcode = instruction[0];
        string? arg1 = instruction.Length >= 2 ? instruction[1] : null;
        string? arg2 = instruction.Length >= 3 ? instruction[2] : null;
        switch (opcode) {
        case "ADD":
            byte constant;
            short address;
            if (arg1[0] == '#') {
                constant = Convert.FromHexString(
                    arg1.Substring(1))[0]; // Converts hex string to single byte
                Console.WriteLine(constant);
            }
            if (arg1[0] == '$') {
                if (arg1.Substring(1).Length != 4)
                    throw new Exception(
                        "Address must have 4 hexadecimal digits");
                address = Convert.ToInt16(Convert.FromHexString(
                    arg1.Substring(1))); // Converts hex string to single byte
                Console.WriteLine(address);
            }
            if (arg1 == "A") {
                output.WriteByte(0b10000000);
            }
            if (arg1 == "B") {
                output.WriteByte(0b10000001);
            }
            if (arg1 == "C") {
                output.WriteByte(0b10000010);
            }
            if (arg1 == "D") {
                output.WriteByte(0b10000011);
            }

            break;
        default:
            throw new Exception("Unknown operation" + opcode);
        }
    }
}