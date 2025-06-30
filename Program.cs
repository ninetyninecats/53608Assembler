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
            if (arg1 is null || arg2 is not null)
                throw new Exception("Invalid ADD instruction");
            AssembleArithmeticInstruction(ArithmeticOpcode.ADD, arg1);
            break;
        case "SUB":
            if (arg2 is not null)
                throw new Exception("Invalid SUB instruction");
            AssembleArithmeticInstruction(ArithmeticOpcode.SUB, arg1);
            break;
        case "MUL":
            if (arg2 is not null)
                throw new Exception("Invalid MUL instruction");
            AssembleArithmeticInstruction(ArithmeticOpcode.MUL, arg1);
            break;
        case "SMUL":
            if (arg2 is not null)
                throw new Exception("Invalid SMUL instruction");
            AssembleArithmeticInstruction(ArithmeticOpcode.SMUL, arg1);
            break;
        case "DIV":
            if (arg2 is not null)
                throw new Exception("Invalid DIV instruction");
            AssembleArithmeticInstruction(ArithmeticOpcode.DIV, arg1);
            break;
        case "SDIV":
            if (arg2 is not null)
                throw new Exception("Invalid SDIV instruction");
            AssembleArithmeticInstruction(ArithmeticOpcode.SDIV, arg1);
            break;
        case "NGT":
            if (arg2 is not null)
                throw new Exception("Invalid NGT instruction");
            AssembleArithmeticInstruction(ArithmeticOpcode.NGT, arg1);
            break;
        case "AND":
            if (arg2 is not null)
                throw new Exception("Invalid AND instruction");
            AssembleBitwiseInstruction(BitwiseOpcode.AND, arg1);
            break;
        case "OR":
            if (arg2 is not null)
                throw new Exception("Invalid OR instruction");
            AssembleBitwiseInstruction(BitwiseOpcode.OR, arg1);
            break;
        case "XOR":
            if (arg2 is not null)
                throw new Exception("Invalid XOR instruction");
            AssembleBitwiseInstruction(BitwiseOpcode.XOR, arg1);
            break;
        case "NOT":
            if (arg2 is null)
                throw new Exception("Invalid NOT instruction");
            AssembleBitwiseInstruction(BitwiseOpcode.NOT, arg1);
            break;
        case "SHL":
            if (arg2 is not null)
                throw new Exception("Invalid SHL instruction");
            AssembleBitwiseInstruction(BitwiseOpcode.SHL, arg1);
            break;
        case "SHR":
            if (arg2 is not null)
                throw new Exception("Invalid SHR instruction");
            AssembleBitwiseInstruction(BitwiseOpcode.SHR, arg1);
            break;
        case "ROL":
            if (arg2 is not null)
                throw new Exception("Invalid ROL instruction");
            AssembleBitwiseInstruction(BitwiseOpcode.ROL, arg1);
            break;
        case "ROR":
            if (arg2 is not null)
                throw new Exception("Invalid ROR instruction");
            AssembleBitwiseInstruction(BitwiseOpcode.ROR, arg1);
            break;
        case "LOD":
            if (arg1 is null || arg2 is null)
                throw new Exception("Invalid LOD instruction");
            AssembleLoadInstruction(arg1, arg2);
            break;
        default:
            throw new Exception("Unknown operation " + opcode);
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
    public static void AssembleBitwiseInstruction(BitwiseOpcode opcode,
                                                  string argument) {
        switch (argument[0]) {
        case '#':
            output.WriteByte((byte)(0b11000110 + (int)opcode * 8));
            output.WriteByte(Convert.FromHexString(argument[1..])[0]);
            break;
        case '$':
            if (argument.Substring(1).Length != 4)
                throw new Exception("Address must have 4 hexadecimal digits");
            output.WriteByte((byte)(0b11000101 + (int)opcode * 8));
            output.WriteByte((byte)Convert.ToInt16(
                Convert.FromHexString(argument[1..])[0] * 256 +
                Convert.FromHexString(argument[1..])[1]));
            output.WriteByte(
                (byte)(Convert.ToInt16(
                           Convert.FromHexString(argument[1..])[0] * 256 +
                           Convert.FromHexString(argument[1..])[1]) >>
                       8));
            break;
        case 'A':
            output.WriteByte((byte)(0b11000000 + (int)opcode * 8));
            break;

        case 'B':
            output.WriteByte((byte)(0b11000001 + (int)opcode * 8));
            break;

        case 'C':
            output.WriteByte((byte)(0b11000010 + (int)opcode * 8));
            break;

        case 'D':
            output.WriteByte((byte)(0b11000011 + (int)opcode * 8));
            break;
        case 'P':
            output.WriteByte((byte)(0b11000100 + (int)opcode * 8));
            break;

        default:
            throw new Exception("Unknown argument");
        }
    }
    public static void AssembleLoadInstruction(string arg1, string arg2) {
        if (arg2.Length != 1)
            throw new Exception("Invalid second argument for load instruction");
        if (arg1[0] == '#') {
            switch (arg2[0]) {
            case 'A':
                output.WriteByte(0b01000000);
                output.WriteByte(Convert.FromHexString(arg1[1..])[0]);

                break;
            case 'B':
                output.WriteByte(0b01000001);
                output.WriteByte(Convert.FromHexString(arg1[1..])[0]);

                break;
            case 'C':
                output.WriteByte(0b01000010);
                output.WriteByte(Convert.FromHexString(arg1[1..])[0]);

                break;
            case 'D':
                output.WriteByte(0b01000011);
                output.WriteByte((byte)Convert.ToInt16(
                    Convert.FromHexString(arg1[1..])[0] * 256 +
                    Convert.FromHexString(arg1[1..])[1]));
                output.WriteByte(
                    (byte)(Convert.ToInt16(
                               Convert.FromHexString(arg1[1..])[0] * 256 +
                               Convert.FromHexString(arg1[1..])[1]) >>
                           8));

                break;
            }

        } else if (arg1[0] == '$') {

        } else
            throw new Exception("Invalid first argument for load instruction");
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
public enum BitwiseOpcode {
    AND,
    OR,
    XOR,
    NOT,
    SHL,
    SHR,
    ROL,
    ROR

}