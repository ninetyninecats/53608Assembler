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
            if (arg2 is not null)
                throw new Exception("Invalid ADD instruction");
            AssembleArithmeticInstruction(ArithmeticOpcode.ADD, arg1);
            break;
        case "SUB":
            if (arg2 is not null)
                throw new Exception("Invalid ADD instruction");
            AssembleArithmeticInstruction(ArithmeticOpcode.SUB, arg1);
            break;
        case "MUL":
            if (arg2 is not null)
                throw new Exception("Invalid ADD instruction");
            AssembleArithmeticInstruction(ArithmeticOpcode.MUL, arg1);
            break;
        case "SMUL":
            if (arg2 is not null)
                throw new Exception("Invalid ADD instruction");
            AssembleArithmeticInstruction(ArithmeticOpcode.SMUL, arg1);
            break;
        case "DIV":
            if (arg2 is not null)
                throw new Exception("Invalid ADD instruction");
            AssembleArithmeticInstruction(ArithmeticOpcode.DIV, arg1);
            break;
        case "SDIV":
            if (arg2 is not null)
                throw new Exception("Invalid ADD instruction");
            AssembleArithmeticInstruction(ArithmeticOpcode.SDIV, arg1);
            break;
        case "NGT":
            if (arg2 is null)
                throw new Exception("Invalid ADD instruction");
            AssembleArithmeticInstruction(ArithmeticOpcode.NGT, arg1);
            break;
        default:
            throw new Exception("Unknown operation" + opcode);
        }
    }
    public static void AssembleArithmeticInstruction(ArithmeticOpcode opcode,
                                                     string argument) {
        switch (argument[0]) {
        case '#':
            output.WriteByte((byte)(0b10000110 + (int)opcode * 8));
            output.WriteByte(Convert.FromHexString(argument.Substring(1))[0]);
            break;
        case '$':
            if (argument.Substring(1).Length != 4)
                throw new Exception("Address must have 4 hexadecimal digits");
            output.WriteByte((byte)(0b10000101 + (int)opcode * 8));
            output.WriteByte((byte)Convert.ToInt16(
                Convert.FromHexString(argument.Substring(1))[0] * 256 +
                Convert.FromHexString(argument.Substring(1))[1]));
            output.WriteByte(
                (byte)(Convert.ToInt16(
                           Convert.FromHexString(argument.Substring(1))[0] *
                               256 +
                           Convert.FromHexString(argument.Substring(1))[1]) >>
                       8));
            break;
        case 'A':
            output.WriteByte((byte)(0b10000000 + (int)opcode * 8));
            break;

        case 'B':
            output.WriteByte((byte)(0b10000001 + (int)opcode * 8));
            break;

        case 'C':
            output.WriteByte((byte)(0b10000010 + (int)opcode * 8));
            break;

        case 'D':
            output.WriteByte((byte)(0b10000011 + (int)opcode * 8));
            break;
        case 'P':
            output.WriteByte((byte)(0b10000100 + (int)opcode * 8));
            break;

        default:
            throw new Exception("Unknown argument");
        }
    }
}
public enum ArithmeticOpcode {
    ADD,
    SUB,
    MUL,
    SMUL,
    DIV,
    SDIV,
    NGT

}